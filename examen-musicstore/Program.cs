using System;
using System.Collections.Generic;
using System.IO;

var lista = new List<Album>{
    new Album("album1","1",1986,true),
    new Album("album2","2",1992,false),
    new Album("album3","3",1924,true)
};

foreach(var a in lista) Console.WriteLine(a);

Console.WriteLine();
Console.WriteLine("Álbumes de Metallica:");
foreach(var a in lista) if(a.getArtista().Contains("Metallica")) Console.WriteLine(a);

Console.WriteLine();
Console.WriteLine(DateTime.Now.ToShortDateString());

GuardarAlbums(lista,"albums.txt");

void GuardarAlbums(List<Album> lista,string ruta){
    var lines=new List<string>();
    foreach(var a in lista) lines.Add($"{a.getTitulo()};{a.getArtista()};{a.getAnyo()};{a.isDisponible()}");
    File.WriteAllLines(ruta,lines);
}
