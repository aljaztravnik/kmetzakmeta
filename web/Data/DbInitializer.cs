using web.Data;
using web.Models;
using System;
using System.Linq;

namespace web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(KmetContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Uporabniki.Any())
            {
                return;   // DB has been seeded
            }

            var uporabniki = new Uporabnik[]
            {
                new Uporabnik{Username="aljaz",Password="testgeslo"},
                new Uporabnik{Username="klaudija",Password="testgeslo"},
                new Uporabnik{Username="gregor",Password="testgeslo"},
                new Uporabnik{Username="janez",Password="testgeslo"},
                new Uporabnik{Username="gasper",Password="testgeslo"},
                new Uporabnik{Username="domen",Password="testgeslo"},
                new Uporabnik{Username="jan",Password="testgeslo"},
                new Uporabnik{Username="joco",Password="testgeslo"}
            };

            context.Uporabniki.AddRange(uporabniki);
            context.SaveChanges();

            var regije = new Regija[]
            {
                new Regija{Name="Osrednjeslovenska"},
                new Regija{Name="Pomurska"},
                new Regija{Name="Podravska"},
                new Regija{Name="Koroška"},
                new Regija{Name="Savinjska"},
                new Regija{Name="Zasavska"},
                new Regija{Name="Posavska"},
                new Regija{Name="Jugovzhodna Slovenija"},
                new Regija{Name="Gorenjska"},
                new Regija{Name="Primorsko-notranjska"},
                new Regija{Name="Goriška"},
                new Regija{Name="Obalno-kraška"},
            };

            context.Regije.AddRange(regije);
            context.SaveChanges();

            var pasme = new Pasma[]
            {
                new Pasma{Name="Črno-belo govedo"},
                new Pasma{Name="Limuzin (Limousin) govedo"},
                new Pasma{Name="Lisasto govedo"},
                new Pasma{Name="Montbeliard govedo"},
                new Pasma{Name="Rjavo govedo"},
                new Pasma{Name="Šarole (Charolais) govedo"},
            };

            context.Pasme.AddRange(pasme);
            context.SaveChanges();

            var znamke = new Znamka[]
            {
                new Znamka{Name="Fendt"},
                new Znamka{Name="Massey Ferguson"},
                new Znamka{Name="Valtra"},
                new Znamka{Name="Fiat Trattori"},
                new Znamka{Name="Landini"},
                new Znamka{Name="McCormick Tractors"},
                new Znamka{Name="Case"},
                new Znamka{Name="Case IH"},
                new Znamka{Name="Caterpillar"},
                new Znamka{Name="Claas"},
                new Znamka{Name="New Holland"},
                new Znamka{Name="Steyr"},
                new Znamka{Name="John Deere"},
                new Znamka{Name="Deutz-Fahr"},
                new Znamka{Name="Goldoni"},
                new Znamka{Name="JCB"},
                new Znamka{Name="Kubota"},
                new Znamka{Name="Komatsu"},
                new Znamka{Name="Lamborghini"},
                new Znamka{Name="Landini"},
                new Znamka{Name="Lindner"},
                new Znamka{Name="Ursus"},
                new Znamka{Name="SAME"},
                new Znamka{Name="IMT"},
                new Znamka{Name="Zetor"},
            };

            context.Znamke.AddRange(znamke);
            context.SaveChanges();

            var kategorijeStrojev = new KategorijaStroja[]
            {
                new KategorijaStroja{Name="Traktor"},
                new KategorijaStroja{Name="Zgrabljalnik"},
                new KategorijaStroja{Name="Trosilec"},
                new KategorijaStroja{Name="Cisterna"},
                new KategorijaStroja{Name="Nakladač"},
                new KategorijaStroja{Name="Balirka"},
            };

            context.KategorijeStrojev.AddRange(kategorijeStrojev);
            context.SaveChanges();
        }
    }
}