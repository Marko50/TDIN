all: run

Application: Servers/Bar/Bar.cs Servers/CentralNode/CentralNode.cs Clients/DiningRoom/DiningRoom.cs lib/CentralNodeManager.cs lib/Order.cs
	@csc -target:library lib/Order.cs
	@csc -reference:Order.dll -target:library lib/CentralNodeManager.cs
	@csc Servers/CentralNode/CentralNode.cs
	@csc -reference:CentralNodeManager.dll -reference:Order.dll Servers/Bar/Bar.cs
	@csc -reference:CentralNodeManager.dll -reference:Order.dll Clients/DiningRoom/DiningRoom.cs

clean:
	@rm -f *.exe
	@rm -f *.dll

run: Application