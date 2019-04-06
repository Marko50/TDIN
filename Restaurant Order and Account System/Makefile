all: run

Application: Servers/OrderDealing/OrderDealing.cs Servers/OrderDealing/Bar/Bar.cs Servers/OrderDealing/Kitchen/Kitchen.cs Servers/CentralNode/CentralNode.cs Clients/DiningRoom/DiningRoom.cs lib/CentralNodeManager.cs lib/Order.cs lib/OrderPart.cs
	@csc -target:library lib/OrderPart.cs	
	@csc -reference:OrderPart.dll -target:library lib/Order.cs
	@csc -reference:OrderPart.dll -target:library Servers/OrderDealing/OrderDealing.cs
	@csc -reference:Order.dll -reference:OrderPart.dll -target:library lib/CentralNodeManager.cs
	@csc Servers/CentralNode/CentralNode.cs
	@csc -reference:CentralNodeManager.dll -reference:OrderPart.dll -reference:OrderDealing.dll Servers/OrderDealing/Bar/Bar.cs
	@csc -reference:CentralNodeManager.dll -reference:OrderPart.dll -reference:OrderDealing.dll Servers/OrderDealing/Kitchen/Kitchen.cs
	@csc -reference:CentralNodeManager.dll -reference:Order.dll Clients/DiningRoom/DiningRoom.cs

clean:
	@rm -f *.exe
	@rm -f *.dll

run: Application