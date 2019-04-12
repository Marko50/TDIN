all: run

Application: Servers/OrderDealing/OrderDealing.cs Servers/OrderDealing/Bar/BarManager.cs Servers/OrderDealing/Kitchen/KitchenManager.cs Servers/CentralNode/CentralNode.cs Clients/DiningRoom/DiningRoom.cs Clients/Bar/Bar.cs lib/CentralNodeManager.cs lib/Order.cs lib/OrderPart.cs
	@csc -target:library lib/OrderPart.cs	
	@csc -reference:OrderPart.dll -target:library lib/Order.cs
	@csc -reference:OrderPart.dll -target:library Servers/OrderDealing/OrderDealing.cs
	@csc -reference:Order.dll -reference:OrderPart.dll -target:library lib/CentralNodeManager.cs
	@csc Servers/CentralNode/CentralNode.cs
	@csc -reference:CentralNodeManager.dll -reference:OrderPart.dll -reference:OrderDealing.dll Servers/OrderDealing/Bar/BarManager.cs
	@csc -reference:CentralNodeManager.dll -reference:OrderPart.dll -reference:OrderDealing.dll Servers/OrderDealing/Kitchen/KitchenManager.cs
	@csc -reference:CentralNodeManager.dll -reference:Order.dll Clients/DiningRoom/DiningRoom.cs
	@csc -reference:CentralNodeManager.dll -reference:Order.dll Clients/Bar/Bar.cs

clean:
	@rm -f *.exe
	@rm -f *.dll

run: Application