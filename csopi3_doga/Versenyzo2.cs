using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csopi3_doga
{
    internal class Versenyzo2
    {
        public string Nev { get; set; }
        public int Szul { get; set; }
        public string RajtSzam { get; set; }
        public bool Nem { get; set; }
        public string Kategoria { get; set; }
        public Dictionary<string, TimeSpan> VersenyIdok { get; set; }

        public override string ToString() => $"[{RajtSzam}] {Nev} ({Kategoria})";
        public int Osszido => (int)VersenyIdok.Values.Sum(x => x.TotalSeconds);

        public Versenyzo2(string sor)
        {
            string[] d = sor.Split(';');
            Nev = d[0];
            Szul = int.Parse(d[1]);
            RajtSzam = d[2];
            Nem = d[3] == "f";
            Kategoria = d[4];

            VersenyIdok = new()
            {
                {"úszás", TimeSpan.Parse(d[5])},
                {"I. depó", TimeSpan.Parse(d[6])},
                {"kerékpározás", TimeSpan.Parse(d[7])},
                {"II. depó", TimeSpan.Parse(d[8])},
                {"futás", TimeSpan.Parse(d[9])},
            };
        }
    }
}
