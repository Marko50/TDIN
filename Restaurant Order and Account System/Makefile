all: run

Application: Server/OrderDealingCenter.cs Clients/DiningRoom/DiningRoom.cs lib/CentralNode.cs lib/Order.cs
	@csc -target:library lib/Order.cs
	@csc -reference:Order.dll -target:library lib/CentralNode.cs
	@csc Server/OrderDealingCenter.cs
	@csc -reference:CentralNode.dll -reference:Order.dll Clients/DiningRoom/DiningRoom.cs

clean:
	@rm -f *.exe
	@rm -f *.dll

run: Application