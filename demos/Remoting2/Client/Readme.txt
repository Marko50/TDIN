Par�metros que normalmente s�o passados por refer�ncia,
como os arrays, n�o funcionam assim em Remoting.
Para isso dever� ser usada a palavra-chave do C# ref,
de modo a que esses par�metros sejam 'marshalled' nos
2 sentidos.