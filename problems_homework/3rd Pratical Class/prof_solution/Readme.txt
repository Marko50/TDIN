Solution (VS) RemInventory

This solution is composed by 6 projects:

Shared
======
Contains the definition of the delegate associated with the remote event.
Defines the serializable class for the parameter of the remote event.
The resultant assembly must be present in the server and all the clients.

Manager
=======
Contains the remote class derived from MarshalByRefObject.
This class defines a remote method and an event.
The method's code triggers the event.
The assembly must be present in the server and the clients
should have access to the metadata (or skeleton). For simplification the
clients reference this assembly.

Server
======
The application that hosts the remote object.

UpdateInventory
===============
An application that calls the method in the remote object.

InventoryLog
============
A client application that subscribes the remote event.
The handler is in a class that must be remotable (derived from
MarshalByRefObject).
The server needs to have access to its metadata (or have a skeleton
of the relevant methods, but for simplification it references this assembly).

InventoryWatcher
================
Another client application that subscribes the remote event.
This time the handler is defined in the application class.
Nevertheless the class must be remotable and its metadata
accessible to the server (for simplification it references
this assembly).
