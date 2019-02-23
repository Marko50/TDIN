all: run

Solution.exe: Solution.cs
	@csc -target:library lib/ImaginaryNumber.cs
	@csc -lib:lib/ -reference:ImaginaryNumber.dll Solution.cs 

clean:
	@rm -f Solution.exe
	@rm -f ImaginaryNumber.dll

run: Solution.exe
	@mono Solution.exe