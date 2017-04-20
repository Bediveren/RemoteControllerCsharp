# RemoteControllerCsharp

Simple remote control client/server written in C#. Done using WinForms.  
Requires .NET 4.0 and above.    

USAGE:  

* Main window  
![alt tag](https://cloud.githubusercontent.com/assets/24376768/25250646/27dc6248-261f-11e7-9016-fe4c51ef42df.PNG)  

One client creates server, other connects to the server.

* End result example  
![alt tag](https://cloud.githubusercontent.com/assets/24376768/25250650/29f0c452-261f-11e7-8c0e-3cc62a34584e.PNG)

Notes:  
- Mouse movement is disabled by default, to enable it, find ServerHost.cs line 166 and uncomment it.
- Keyboard input will not loop if both - the server and the client are ran on the same computer. 
