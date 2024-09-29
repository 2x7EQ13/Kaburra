![file_small](https://github.com/user-attachments/assets/383219d3-1bac-4d8f-8f1b-2047a7a9d92e)

Kaburra is a project that supports phishing attack testing.

Its main purpose is to assess the awareness level of personnel within companies and organizations.

It helps system managers evaluate after conducting training courses on social engineering awareness. The emails and fake malware are designed to resemble the techniques currently used by ransomware gangs and APT groups.
All activities take place in a sandbox, and **you should also work with the SysAdmin before proceeding.**

_Kaburra is derived from Kookaburra, a type of kingfisher that does not eat fish_

## Main functions

**Use available phishing email templates or create your own through Ms Word, and send them to one or multiple targets with one click.**

**Track which emails are opened and which attachments are executed.**

**Support statistics to assess the overall level of awareness.**

## Types of attachments:

**1.** Ms Word .doc file with VBA macros.

**2.** LNK Shortcut - PDF icon

**3.** Ms Word Exe Side Loading - With Digital Signature

**4.** PDF Reader Exe Side Loading - With Digital Signature

**PE uses SparringRAT:** [https://github.com/2x7EQ13/SparringRAT]

## Installation:

**Server:**

Public server with a domain that has verified SSL. Use Let's Encrypt if you want it for free.

Upload the Webserver folder to the server, replacing server-cert.crt and server-key.key with the cert/key pair obtained when registering with Let's Encrypt.

**cd Webserver**

**pip3 install httpserver**

**sudo python3 websvr.py**

## Admin

Download and Install Webview2 Runtime: this is for mail preview before send.

[https://developer.microsoft.com/en-us/microsoft-edge/webview2/?form=MA13LH#download]

.NET 6 Desktop Runtime

[https://dotnet.microsoft.com/en-us/download/dotnet/6.0]

**Run Kaburra.exe**

**Fill Sender Setting info and "Check"**

**Fill Payload Setting and "Send"**

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
