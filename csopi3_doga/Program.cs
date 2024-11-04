using csopi3_doga;
using System.Text;

List<Versenyzo2> versenyzok = [];
using StreamReader sr = new("..\\..\\..\\src\\forras.txt", Encoding.UTF8);
while (!sr.EndOfStream) versenyzok.Add(new(sr.ReadLine()));

var f1 = versenyzok.Where(v => v.Kategoria == "25-29");
Console.WriteLine($"versenyzok szama a 25-29-es kategoriaban: {f1.Count()}");

var f2 = versenyzok.Average(v=> 2014-v.Szul);
Console.WriteLine($"Atlag eletkor a verenyzoknel: {f2:0.00} ev");

var f3 = versenyzok.Sum(v => v.VersenyIdok["úszás"].TotalHours);
Console.WriteLine($"versenyzok uszassal toltott osszes ideje: {f3:0.00} ora");

var f4 = versenyzok.Where(v => v.Kategoria == "elit").Average(v => v.VersenyIdok["úszás"].TotalMinutes);
Console.WriteLine($"Atlagos uszasi ido elit kategoriaban: {f4:0.00} perc");

var f5 = versenyzok.Where(v => v.Nem).MinBy(v => v.Osszido);
Console.WriteLine($"A ferfi gyoztes: {f5}");

var f6 = versenyzok.GroupBy(v => v.Kategoria);
Console.WriteLine($"a versenyt befejezok rajtszama a korkategoriankent:");
foreach (var grp in f6)
{
    Console.WriteLine($"\t{grp.Key}: ({grp.Count()})");
    foreach (var versenyzo in grp)
    {
        Console.WriteLine($"\t\t{versenyzo}");
    }
}
    