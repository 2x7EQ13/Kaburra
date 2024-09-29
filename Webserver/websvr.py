import http.server
import socketserver
import ssl
import logging
import threading
import cgi
import os
import sys
from datetime import datetime

# Configure logging
logging.basicConfig(filename='weblog.log', level=logging.INFO, format='%(message)s')

class CustomHTTPRequestHandler(http.server.SimpleHTTPRequestHandler):
    def log_request(self, code='-', size='-'):
        # Log only GET requests that contain '/tracking/' in the URI
        if self.command == 'GET' and '/kaburra/track/' in self.path:
            client_ip = self.client_address[0]
            request_time = datetime.now().strftime('%d/%m/%Y:%H:%M:%S')
            uri = self.path
            logging.info(f"{client_ip} {request_time} {uri}")   #separate by space

    def do_GET(self):
        # Check if the request is for the log file
        if self.path == '/kaburra/getlog':
            self.send_response(200)
            self.send_header('Content-type', 'text/plain')
            self.end_headers()
            with open('weblog.log', 'r') as log_file:
                self.wfile.write(log_file.read().encode())

        elif self.path == '/kaburra/clearlog':
            self.send_response(200)
            self.end_headers()
            self.wfile.write(b'200 OK: Log cleared.')
            # Empty the weblog.log file
            open('weblog.log', 'w').close()  # Truncate the log file

        elif self.path.startswith('/kaburra/download/'):
            # Handle file download
            filename = self.path[len('/kaburra/download/'):]  # Extract filename from the path
            if os.path.isfile(filename):
                self.send_response(200)
                self.send_header('Content-Type', 'application/octet-stream')
                self.send_header('Content-Disposition', f'attachment; filename="{os.path.basename(filename)}"')
                self.end_headers()
                with open(filename, 'rb') as file_to_send:
                    self.wfile.write(file_to_send.read())
            else:
                self.send_response(404)
                self.end_headers()
                self.wfile.write(b'404 Not Found: File does not exist.')
        else:
            # Respond with 404 for all other requests
            self.send_response(404)
            self.end_headers()
            self.wfile.write(b'404 Not Found')
    def do_POST(self):
        if self.path == 'kaburra/upload/files':
            # Handle file upload
            content_type, params = cgi.parse_header(self.headers['Content-Type'])
            if content_type == 'multipart/form-data':
                form = cgi.FieldStorage(
                    fp=self.rfile,
                    environ={'REQUEST_METHOD': 'POST'},
                    headers=self.headers
                )
                #print(f"Process the uploaded file")
                # Process the uploaded file
                if 'file' in form:
                    file_item = form['file']
                    #print(f"Start uploading {file_item.filename}")
                    if file_item.filename:
                        # Save the file to the current directory
                        with open(os.path.join(os.getcwd(), file_item.filename), 'wb') as output_file:
                            output_file.write(file_item.file.read())
                        self.send_response(200)
                        self.end_headers()
                        self.wfile.write(b'File uploaded successfully.')
                    else:
                        self.send_response(400)
                        self.end_headers()
                        self.wfile.write(b'No file was uploaded.')
                else:
                    self.send_response(400)
                    self.end_headers()
                    self.wfile.write(b'Invalid form data.')
            else:
                self.send_response(400)
                self.end_headers()
                self.wfile.write(b'Content-Type must be multipart/form-data.')
        else:
            # Respond with 404 for all other POST requests
            self.send_response(404)
            self.end_headers()
            self.wfile.write(b'404 Not Found')

def run_http_server(port):
    httpd = socketserver.TCPServer(("", port), CustomHTTPRequestHandler)
    print(f"HTTP Server running on port {port}")
    httpd.serve_forever()

def run_https_server(port, keyfile, certfile):
    httpd = socketserver.TCPServer(("", port), CustomHTTPRequestHandler)
    
    # Create an SSL context
    context = ssl.create_default_context(ssl.Purpose.CLIENT_AUTH)
    context.load_cert_chain(certfile=certfile, keyfile=keyfile)
    
    # Wrap the socket with the SSL context
    httpd.socket = context.wrap_socket(httpd.socket, server_side=True)
    
    print(f"HTTPS Server running on port {port}")
    httpd.serve_forever()

if __name__ == "__main__":
    # Define ports
    HTTP_PORT = 80
    HTTPS_PORT = 443
    # Get the list of command-line arguments
    arguments = sys.argv
    if len(arguments) == 3:
        HTTP_PORT = int(arguments[1])
        HTTPS_PORT = int(arguments[2])
        print(f"Use custom port {HTTP_PORT}/{HTTPS_PORT}")

    # SSL certificate paths
    KEYFILE = "./server-key.key"
    CERTFILE = "./server-cert.crt"

    # Start HTTP server in a separate thread
    http_thread = threading.Thread(target=run_http_server, args=(HTTP_PORT,))
    http_thread.start()

    # Start HTTPS server
    run_https_server(HTTPS_PORT, KEYFILE, CERTFILE)
