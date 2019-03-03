all: run

InventoryLoger.exe: InventoryLoger.cs
	@csc -target:library ../lib/InventoryChangeArgs.cs
	@csc -reference:InventoryChangeArgs.dll -target:library ../lib/InventoryManager.cs
	@csc -reference:InventoryChangeArgs.dll -reference:InventoryManager.dll InventoryLoger.cs

clean:
	@rm -f InventoryLoger.exe
	@rm -f *.dll

run: InventoryLoger.exe
	@mono InventoryLoger.exe