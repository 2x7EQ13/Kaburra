using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaburra
{
    struct Maildata //sử dụng cho cả MSent và MOpen, MSent thì reqeustip == empty
    {
        public string Sender;
        public string Target;
        public string Subject;
        public string Exec;
        public string Time;
        public string RequestIP;

        public Maildata(string sender, string target, string subject, string exec, string time, string requestIP = "")
        {
            Sender = sender;
            Target = target;
            Subject = subject;
            Exec = exec;
            Time = time;
            RequestIP = requestIP;

    }
    }
    internal class DatabaseIO
    {
        public SQLiteConnection Connection = null;
        public bool CreateDataDirectory()
        {
            try
            {
                System.IO.Directory.CreateDirectory("Database");
                return true;
            }
            catch (Exception ex)
            {
                Form1.Instance.Logging("Error:", ex.Message);
            }
            return false;
        }

        public bool InitDatabaseConn()
        {
            try
            {
                string databasePath = @"Database\EmailDatabase.sqlite"; // Specify the database file name
                Connection = new SQLiteConnection($"Data Source={databasePath};Version=3;");
                Connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Form1.Instance.Logging("Error:", ex.Message);
            }
            return false;
        }
        public void CreateDatabaseAndTable()
        {
            int tmpResult = 0;
            SQLiteCommand command = Connection.CreateCommand();
            command.CommandText = @" CREATE TABLE IF NOT EXISTS MailSubject (
                        ID TEXT PRIMARY KEY,
                        OriginalName TEXT
                    );
                ";
            tmpResult = command.ExecuteNonQuery();
            command.CommandText = @" CREATE TABLE IF NOT EXISTS Attachment (
                        ID TEXT PRIMARY KEY,
                        OriginalName TEXT
                    );
                ";
            tmpResult = command.ExecuteNonQuery();
            command.CommandText = @" CREATE TABLE IF NOT EXISTS EmailAddress (
                        ID TEXT PRIMARY KEY,
                        OriginalName TEXT
                    );
                ";
            command.ExecuteNonQuery();

            command.CommandText = @" CREATE TABLE IF NOT EXISTS MOpen (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Sender TEXT,
                        Target TEXT,
                        Subject TEXT,
                        Exec TEXT,
                        RequestIP TEXT,
                        Time TEXT
                    );
                ";
            command.ExecuteNonQuery();
            command.CommandText = @" CREATE TABLE IF NOT EXISTS MSent (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Sender TEXT,
                        Target TEXT,
                        Subject TEXT,
                        Exec TEXT,
                        Time TEXT
                    );
                ";
            command.ExecuteNonQuery();
        }
        public long CountSent(bool total = true)
        {
            string query = $"SELECT COUNT(*) FROM MSent";
            if(!total)
            {
                query = $"SELECT COUNT(*) FROM (SELECT DISTINCT Target, Subject FROM MSent);";
            }
            long result = 0;
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, Connection))
                {
                    result = (long)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Form1.Instance.Logging("Error:", ex.Message);
            }
            return result;
        }
        public long CountOpen(bool total = false)
        {
            string query = $"SELECT COUNT(*) FROM (SELECT DISTINCT Target, Subject FROM MOpen);";
            if(total)
            {
                query = $"SELECT COUNT(*) FROM MOpen;";
            }
            long result = 0;
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, Connection))
                {
                    result = (long)command.ExecuteScalar();
                }
            }catch(Exception ex)
            {
                Form1.Instance.Logging("Error:", ex.Message);
            }
            return result;
        }
        public long GetTotalAttachment()
        {
            string query = $"SELECT COUNT(*) FROM MSent WHERE LENGTH(Exec) > 0;";
            long result = 0;
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, Connection))
                {
                    result = (long)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Form1.Instance.Logging("Error:", ex.Message);
            }
            return result;
        }
        public string GetMostOpenSubject()
        {
            string query = @"SELECT Subject, COUNT(*) as frequency FROM MOpen GROUP BY Subject ORDER BY frequency DESC LIMIT 1;";
            string result = "";
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, Connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = reader.GetString(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Form1.Instance.Logging("Error:", "GetMostOpenSubject: " + ex.Message);
            }
            return result;
        }
        public string GetMostOpenAtt()
        {
            string query = @"SELECT Exec, COUNT(*) as frequency FROM MOpen WHERE LENGTH(Exec) > 0 GROUP BY Exec ORDER BY frequency DESC LIMIT 1;";
            string result = "";
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, Connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = reader["Exec"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Form1.Instance.Logging("Error:", "GetMostOpenSubject: " + ex.Message);
            }
            return result;
        }
        public long CountExec()
        {
            string query = $"SELECT COUNT(*) FROM (SELECT DISTINCT Target, Subject FROM MOpen WHERE LENGTH(Exec) > 0);";
            long result = 0;
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, Connection))
                {
                    result = (long)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Form1.Instance.Logging("Error:", ex.Message);
            }
            return result;
        }

        public long CountExecRecord(string filter, bool total = true)
        {
            string query = $"SELECT COUNT(*) FROM MOpen WHERE LENGTH(Exec) > 0;";
            if(!total)
            {
                query = $"SELECT COUNT(*) FROM MOpen WHERE Exec LIKE '%{filter}%';";
            }
            long result = 0;
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, Connection))
                {
                    result = (long)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Form1.Instance.Logging("Error:", ex.Message);
            }
            return result;
        }
        public DataTable QueryMail(string tbName, string emailCol = "", string email = "")
        {
            string query;
            if (email.Length > 0)
            {
                //xử lý query với filter
                query = $"SELECT * FROM {tbName} WHERE {emailCol} LIKE @value";
            }
            else
            {
                //lấy tất cả các records
                query = $"SELECT * FROM {tbName}";
            }
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, Connection))
                {
                    if (email.Length > 0)
                    {
                        command.Parameters.AddWithValue("@value", "%" + email + "%");
                    }
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch(Exception ex)
            {
                Form1.Instance.Logging("Error:", ex.Message);
            }
            return null;
        }
        public string QueryOrigName(string tbName, string col, string val)
        {
            string query = $"SELECT * FROM {tbName} WHERE {col} = @value";
            SQLiteCommand command = new SQLiteCommand(query, Connection);
            command.Parameters.AddWithValue($"@value", val);
            string result = "";
            try
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = reader.GetString(1); // Get the Name
                    }
                }
            }
            catch (Exception ex)
            {
                Form1.Instance.Logging("Error:", "QueryOrigName: " + ex.Message);
                Form1.Instance.Logging("Error:", command.CommandText);
            }
            return result;
        }
        public string QuerySender(string target, string subject)
        {
            string query = "SELECT * FROM MSent WHERE Target = @value1 AND Subject = @value2 LIMIT 1";
            string sender = "";
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, Connection))
                {
                    command.Parameters.AddWithValue("@value1", target);
                    command.Parameters.AddWithValue("@value2", subject);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sender = reader.GetString(1); //lấy record Sender trong MSent
                        }
                    }
                }
                }catch(Exception ex)
                {
                    Form1.Instance.Logging("Error:", "QuerySender: " + ex.Message);
                }
            return sender;
        }
        public List<Maildata> QueryMailData(string tbName, string col, string e_Hash, bool selectAll = false)
        {
            List < Maildata > mdata = new List<Maildata>();
            string query = "";
            if(selectAll)
            {
                query = $"SELECT COUNT(*) FROM {tbName}";
            }
            else
            {
                query = $"SELECT COUNT(*) FROM {tbName} WHERE {col} = @value";
            }
            SQLiteCommand command = new SQLiteCommand(query, Connection);
            if(!selectAll)
            {
                command.Parameters.AddWithValue($"@value", e_Hash);
            }
            try
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int key = reader.GetInt32(0);
                        string emailID = reader.GetString(1);
                        string subject = reader.GetString(2);
                        string execID = reader.GetString(3);
                        string time = reader.GetString(4);
                        string rqIP = reader.GetString(5);
                        mdata.Add(new Maildata(emailID, subject, execID, time, rqIP));
                    }
                }
            }
            catch (Exception ex)
            {
                Form1.Instance.Logging("Error:", ex.Message);
            }
            return mdata;
        }
        public bool CheckRecordExist(string tbName, string col, string val)
        {
            string query = $"SELECT COUNT(*) FROM {tbName} WHERE {col} = @value";
            SQLiteCommand command = new SQLiteCommand(query, Connection);
            command.Parameters.AddWithValue($"@{col}", val);
            long count = (long)command.ExecuteScalar();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool InsertTBTwoRecord(string tbName, string col1, string col2, string val1, string val2)
        {
            string query = $"INSERT OR IGNORE INTO {tbName} ({col1}, {col2}) VALUES (@{col1}, @{col2})";
            SQLiteCommand command = new SQLiteCommand(query, Connection);
            command.Parameters.AddWithValue($"@{col1}", val1);
            command.Parameters.AddWithValue($"@{col2}", val2);
            if (ExecSQLQuery(command) == 0)
            {
                return false;
            }
            return true;
        }
        public bool InsertExecMail(string sender, string target, string subject, string exec, string rqIP, string rqTime)
        {
            //xảy ra khi target user mở email, exec attachment
            string query = "INSERT INTO MOpen (Sender, Target, Subject, Exec, RequestIP, Time) VALUES (@Sender, @Target, @Subject, @Exec, @RequestIP, @Time)";
            SQLiteCommand command = new SQLiteCommand(query, Connection);
            command.Parameters.AddWithValue("@Sender", sender);
            command.Parameters.AddWithValue("@Target", target);
            command.Parameters.AddWithValue("@Subject", subject);
            command.Parameters.AddWithValue("@Exec", exec);
            command.Parameters.AddWithValue("@RequestIP", rqIP);
            command.Parameters.AddWithValue("@Time", rqTime);
            if (ExecSQLQuery(command) == 0)
            {
                return false;
            }
            return true;
        }

        public bool InsertSentMail(string sender, string target, string subject, string exec)
        {
            string query = "INSERT INTO MSent (Sender, Target, Subject, Exec, Time) VALUES (@Sender, @Target, @Subject, @Exec, @Time)";
            SQLiteCommand command = new SQLiteCommand(query, Connection);
            command.Parameters.AddWithValue("@Sender", sender);
            command.Parameters.AddWithValue("@Target", target);
            command.Parameters.AddWithValue("@Subject", subject);
            command.Parameters.AddWithValue("@Exec", exec);
            command.Parameters.AddWithValue("@Time", GetDateTime());
            if(ExecSQLQuery(command) == 0)
            {
                return false;
            }
            return true;
        }

        public int ExecSQLQuery(SQLiteCommand command)
        {
            try
            {
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                Form1.Instance.Logging("Error:", "ExecSQLQuery: " +  ex.Message);
                Form1.Instance.Logging("Error:", command.CommandText);
            }
            return 0;
        }

        public string GetDateTime()
        {
            DateTime now = DateTime.Now;
            return now.ToString("dd/MMM/yyyy:HH:mm:ss");
        }

        //Close database
        ~DatabaseIO()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}
