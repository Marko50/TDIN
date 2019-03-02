all: run

Client.exe: Client.cs
	@csc -target:library ../lib/InventoryChangeArgs.cs
	@csc -reference:InventoryChangeArgs.dll -target:library ../lib/InventoryManager.cs
	@csc -reference:InventoryChangeArgs.dll -reference:InventoryManager.dll Client.cs

clean:
	@rm -f Client.exe
	@rm -f *.dll

run: Client.exe
	@mono Client.exe