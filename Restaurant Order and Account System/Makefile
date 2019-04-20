all: run

Application: Servers/OrderDealing/OrderDealing.cs Servers/OrderDealing/Bar/BarManager.cs Servers/OrderDealing/Kitchen/KitchenManager.cs Servers/CentralNode/CentralNode.cs Clients/DiningRoom/DiningRoom.cs Clients/Bar/Bar.cs lib/CentralNodeManager.cs lib/Order.cs lib/OrderPart.cs GUI/DiningRoom/DiningRoomGUI.cs GUI/OrderDealing/OrderDealingGUI.cs GUI/OrderDealing/Bar/BarGUI.cs GUI/OrderDealing/Kitchen/KitchenGUI.cs
	@csc -target:library lib/OrderPart.cs	
	@csc -reference:OrderPart.dll -target:library lib/Order.cs
	@csc -reference:Order.dll -reference:OrderPart.dll -target:library lib/CentralNodeManager.cs
	@csc -target:library -reference:Order.dll GUI/DiningRoom/DiningRoomGUI.cs
	@csc -target:library GUI/OrderDealing/OrderDealingGUI.cs
	@csc -target:library -reference:OrderDealingGUI.dll GUI/OrderDealing/Bar/BarGUI.cs
	@csc -target:library -reference:OrderDealingGUI.dll GUI/OrderDealing/Kitchen/KitchenGUI.cs
	@csc Servers/CentralNode/CentralNode.cs
	@csc -reference:OrderPart.dll -reference:OrderDealingGUI.dll -target:library Servers/OrderDealing/OrderDealing.cs
	@csc -reference:CentralNodeManager.dll -reference:OrderPart.dll -reference:OrderDealing.dll -reference:OrderDealingGUI.dll -reference:BarGUI.dll Servers/OrderDealing/Bar/BarManager.cs
	@csc -reference:CentralNodeManager.dll -reference:OrderPart.dll -reference:OrderDealing.dll -reference:OrderDealingGUI.dll -reference:KitchenGUI.dll Servers/OrderDealing/Kitchen/KitchenManager.cs
	@csc -reference:CentralNodeManager.dll -reference:Order.dll -reference:DiningRoomGUI.dll -reference:OrderPart.dll Clients/DiningRoom/DiningRoom.cs
	@csc -reference:CentralNodeManager.dll -reference:Order.dll Clients/Bar/Bar.cs

clean:
	@rm -f *.exe
	@rm -f *.dll

run: Application