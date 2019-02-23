all: run

Solution.exe: Solution.cs
	@csc -target:library lib/module_a/A.cs
	@csc -target:library lib/module_b/B.cs
	@csc -lib:lib/ -reference:A.dll -reference:B.dll Solution.cs 

clean:
	@rm -f Solution.exe
	@rm -f *.dll

run: Solution.exe
	@mono Solution.exe