How to build the demo in the command line:
==========================================

Server side:
1. Compile Stroke.cs into Stroke.dll
   > csc /t:library Stroke.cs
2. Compile PaperSheet.cs into PaperSheet.dll (uses Stroke functionality)
   > csc /t:library /r:Stroke.dll PaperSheet.cs
3. Compile Server.cs into Console application Server.exe
   > csc /t:exe Server.cs
4. Copy Stroke.dll and PaperSheet.dll to the Client directory
   (The client application needs the metadata of both to compile and run)

Client side:
1. Compile NetDraw.cs into Windows application NetDraw.exe (needs metadata from Stroke and PaperSheet)
   > csc /t:winexe /r:Stroke.dll /r:PaperSheet.dll NetDraw.cs
2. Copy NetDraw.exe to the Server directory
   (The server will need the metadata of the NetDraw app at runtime in order to verify the callbacks, when events are fired)

Note: To produce the metadata only a skeleton without implementation code should be enough, but it is easier to copy the complete assemblies. This should not be the solution in production environments.

1. Run the Server from the Server directory
2. Run 2 or more NetDraw instances from the Client directory
3. Use the mouse to draw in any client and the delete key to clear the paper
