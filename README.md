# RemoteControllerCsharp

Simple remote control client/server written in C#. Done using WinForms.  
Requires .NET 4.0 and above.    

USAGE:  

* Main window  
![alt tag](http://imgur.com/QnKQ7NM)  

One client creates server, other connects to the server.

* End result example  
![alt tag](http://imgur.com/5u3iPYX)  

Notes:  
- Mouse movement is disabled by default, to enable it, find ServerHost.cs line 166 and uncomment it.
- Keyboard input will not loop if both - the server and the client are ran on the same computer. 
