![file_small](https://github.com/user-attachments/assets/383219d3-1bac-4d8f-8f1b-2047a7a9d92e)

Kaburra is a project that supports phishing attack testing.

Its main purpose is to assess the awareness level of personnel within companies and organizations.

It helps system managers evaluate after conducting training courses on social engineering awareness. The emails and fake malware are designed to resemble the techniques currently used by ransomware gangs and APT groups.
All activities take place in a sandbox, and **you should also work with the SysAdmin and Security Team before proceeding.**

_Kaburra is derived from Kookaburra, a type of kingfisher that does not eat fish_

## Main functions

  * Use ~~available phishing email templates~~ or create your own through Ms Word, and send them to one or multiple targets with one click.

  * Track which emails are opened and which attachments are executed.

  * **Support statistics to assess the overall level of awareness.**

**PE uses SparringRAT:** [https://github.com/2x7EQ13/SparringRAT]

## How to create HTML emails with MS Word

1. Use MS Word to compose the email body content just like a regular document: with text, images, etc.
2. File ==> Save As ==> Save As Type: **Web Page, Filtered**
3. Use **Kaburra** to open this file; it will automatically convert the img tags to base64 for display in the email body.

_MS Word will create a folder with the same name as the saved file; this folder contains the media necessary for the HTML file. If you move the file elsewhere, always remember to copy both._

_If you have difficulty creating a suitable email for testing, you can contact me at **2x7eq13@proton.me**. I can support you in creating an email that fits the environment you want to test. Please use your company email so I can verify that you work for that place._

## Installation:

**Server:**

Public server with python3 and a domain that has verified SSL. _Use Let's Encrypt if you want it for free._

Upload the Webserver folder to the server, replacing **server-cert.crt** and **server-key.key** with the **cert/key** pair obtained when registering with Let's Encrypt.

 ```console
  sudo apt-get update
  sudo apt install python3
  cd Webserver
  pip3 install httpserver
  sudo python3 websvr.py
 ```

**Admin**

Download and Install Webview2 Runtime: this is for mail preview before send.

[https://developer.microsoft.com/en-us/microsoft-edge/webview2/?form=MA13LH#download]

.NET 6 Desktop Runtime

[https://dotnet.microsoft.com/en-us/download/dotnet/6.0]

1.  Run Kaburra.exe

2.  Fill Sender Setting info and "Check"

3.  Fill Payload Setting and "Send"

# Demo

## Home

![Home](https://github.com/user-attachments/assets/48d68a6e-19ea-45c5-9e45-224e346c109b)

## Result

![Result](https://github.com/user-attachments/assets/8be9e1f6-25b0-41d6-8b59-0b6c658c69f7)

## Statistic

![Statis](https://github.com/user-attachments/assets/b645c841-07fd-45eb-a558-7f3373f1192e)

# Attachments in campaign

![macros](https://github.com/user-attachments/assets/b547e0cb-75de-4c94-9704-f3d2e230d61d)

![lnk_pdf](https://github.com/user-attachments/assets/8973ab02-a46b-4c3b-82c4-e060206fd587)

![ms_word](https://github.com/user-attachments/assets/e3aaea8f-21cc-4a72-9c9c-b2c169c40f0b)

![adobe_pdf](https://github.com/user-attachments/assets/fbcc4c5c-1603-4f11-a1fd-bfecba7c0491)
