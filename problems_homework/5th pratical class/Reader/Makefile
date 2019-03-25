all: run

Reader.exe: Reader.cs
	@csc -target:library ../TransmitableObject/TransmitableObject.cs
	@csc -reference:TransmitableObject.dll Reader.cs

clean:
	@rm -f Reader.exe
	@rm -f *.dll

run: Reader.exe
	@mono Reader.exe