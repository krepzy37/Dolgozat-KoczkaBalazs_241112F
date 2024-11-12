using KoczkaBalazs_241112F;
using System.Text;

var varosok = new List<Varos>();
using StreamReader sr = new(@"..\..\..\src\varosok.csv", Encoding.UTF8);
_ = sr.ReadLine();
while (!sr.EndOfStream) varosok.Add(new(sr.ReadLine()));
Console.WriteLine($"A kollekció hossza: {varosok.Count}");

var kina = varosok.Where(v => v.OrszagNev == "Kína");
float f1 = kina.Sum(v => v.Nepesseg);
Console.WriteLine($"\n(1.) Összesen {f1:00.00} millió fő él kínai nagyvárosokban");

var india = varosok.Where(v => v.OrszagNev == "India");
float f2 = india.Average(v => v.Nepesseg);
Console.WriteLine($"\n(2.) Az indiai nagyvárosok átlaglélekszáma: {f2:00.00} millió fő.");

var f3 = varosok.OrderByDescending(v => v.Nepesseg).First();
Console.WriteLine($"\n(3.) A legnépesebb város: {f3.VarosNev}");

var f4 = varosok.Where(v => v.Nepesseg > 20)
                        .OrderByDescending(v => v.Nepesseg)
                        .ToList();
Console.WriteLine("\n(4.) 20m feletti nagyvárosok népesség szerint csökkenő sorrendben:");
foreach (var varos in f4)
{
    Console.WriteLine($"\t{varos.ToString()}");
}

var f5 = varosok.GroupBy(v => v.OrszagNev)
                                .Where(g => g.Count() > 1)
                                .Select(g => g.Key)
                                .ToList();
Console.WriteLine($"\n(5.)Országok több várossal a listában: {f5.Count}");

var f6 = varosok.Select(v => v.VarosNev[0])
                              .GroupBy(c => c)
                              .OrderByDescending(g => g.Count())
                              .First().Key;
Console.WriteLine($"\n(6.)A legtöbb nagyváros neve {f6} betűvel kezdődik");