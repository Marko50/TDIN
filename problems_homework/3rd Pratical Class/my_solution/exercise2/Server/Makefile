all: run

Server.exe: Server.cs
	@csc -target:library ../lib/InventoryChangeArgs.cs
	@csc -reference:InventoryChangeArgs.dll -target:library ../lib/InventoryManager.cs
	@csc -reference:InventoryChangeArgs.dll -reference:InventoryManager.dll -target:library ../InventoryWatcher/InventoryWatcher.cs
	@csc -reference:InventoryChangeArgs.dll -reference:InventoryManager.dll -target:library ../InventoryLoger/InventoryLoger.cs
	@csc -reference:InventoryChangeArgs.dll -reference:InventoryManager.dll Server.cs

clean:
	@rm -f Server.exe
	@rm -f *.dll

run: Server.exe
	@mono Server.exe