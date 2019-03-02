all: run

InventoryWatcher.exe: InventoryWatcher.cs
	@csc -target:library ../lib/InventoryChangeArgs.cs
	@csc -reference:InventoryChangeArgs.dll -target:library ../lib/InventoryManager.cs
	@csc -reference:InventoryChangeArgs.dll -reference:InventoryManager.dll InventoryWatcher.cs

clean:
	@rm -f InventoryWatcher.exe
	@rm -f *.dll

run: InventoryWatcher.exe
	@mono InventoryWatcher.exe