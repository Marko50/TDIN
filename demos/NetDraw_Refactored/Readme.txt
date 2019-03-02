Refactored demo
===============

In this new architecture there is only a common assembly between Client and Server
The Shared assembly contains:
1. Only an interface of the remote objects (the implementation is not exposed to the client)
2. An intermediate class with the same events of the remote objects
   This class will be instantiated on the client. 
   The client subscribes its events.
   Also this class will subscribe the remote events.
   The server only needs to know the metadata of this class and not the all client.
3. All Serializable classes

How to build:

Shared directory:
1. Compile the Shared.cs source
   > csc /t:library Shared.cs
2. Copy Shared.dll to the Server and Client directories

Server directory:
The server implements the remote objects whose interfaces are in the Shared assembly
1. Compile the Server application
   > csc /t:exe /r:Shared.dll Server.cs

Client directory:
1. Compile the Client application
   > csc /t:winexe /r:Shared.dll NetDraw.cs

Running the demo:

1. Run the Server application from the Server directory
2. Run 2 or more NetDraw clients from the Client directory
