all: run

Client.exe: Client.cs
	@csc -target:library PrimeNumberWebService.cs
	@csc -reference:PrimeNumberWebService.dll Client.cs

clean:
	@rm -f Client.exe
	@rm -f *.dll

run: Client.exe
	@mono Client.exe