using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kaburra
{
    internal class HomePage
    {
        public bool ExistInListView(ListView listView, string itemText)
        {
            foreach (ListViewItem listViewItem in listView.Items)
            {
                if (listViewItem.Text.ToLower().Trim().Equals(itemText))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsValidMailFormat(string email)
        {
            return email.Contains('@');
        }
        public void AddToListView(ListView listView, string itemText)
        {
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.Text = itemText;
            listView.Items.Add(listViewItem);
        }
        public string ComputeMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2")); // Format as hexadecimal
                }
                return sb.ToString();
            }
        }
        //
        public void SaveConfig(Config config)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(config);
                File.WriteAllText(Marker.ConfigFile, jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Config LoadConfig()
        {
            try
            {
                string jsonString = File.ReadAllText(Marker.ConfigFile);
                Config cfg = JsonSerializer.Deserialize<Config>(jsonString);
                return cfg;
            }
            catch (Exception ex)
            {
                Form1.Instance.Logging("Warning:", "LoadConfig: " +  ex.Message);
            }
            return null;
        }
    }
}
