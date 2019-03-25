all: run

Sender.exe: Sender.cs
	@csc -target:library ../TransmitableObject/TransmitableObject.cs
	@csc -reference:TransmitableObject.dll Sender.cs

clean:
	@rm -f Sender.exe
	@rm -f *.dll

run: Sender.exe
	@mono Sender.exe