Parâmetros que normalmente são passados por referência,
como os arrays, não funcionam assim em Remoting.
Para isso deverá ser usada a palavra-chave do C# ref,
de modo a que esses parâmetros sejam 'marshalled' nos
2 sentidos.