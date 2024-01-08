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
                new Uporabnik{User="aljaz",Password="testgeslo"},
                new Uporabnik{User="klaudija",Password="testgeslo"},
                new Uporabnik{User="gregor",Password="testgeslo"},
                new Uporabnik{User="janez",Password="testgeslo"},
                new Uporabnik{User="gasper",Password="testgeslo"},
                new Uporabnik{User="domen",Password="testgeslo"},
                new Uporabnik{User="jan",Password="testgeslo"},
                new Uporabnik{User="joco",Password="testgeslo"}
            };

            context.Uporabniki.AddRange(uporabniki);
            context.SaveChanges();

            var regije = new Regija[]
            {
                new Regija{Region="Osrednjeslovenska"},
                new Regija{Region="Pomurska"},
                new Regija{Region="Podravska"},
                new Regija{Region="Koroška"},
                new Regija{Region="Savinjska"},
                new Regija{Region="Zasavska"},
                new Regija{Region="Posavska"},
                new Regija{Region="Jugovzhodna Slovenija"},
                new Regija{Region="Gorenjska"},
                new Regija{Region="Primorsko-notranjska"},
                new Regija{Region="Goriška"},
                new Regija{Region="Obalno-kraška"},
            };

            context.Regije.AddRange(regije);
            context.SaveChanges();

            var pasme = new Pasma[]
            {
                new Pasma{Breed="Črno-belo govedo"},
                new Pasma{Breed="Limuzin (Limousin) govedo"},
                new Pasma{Breed="Lisasto govedo"},
                new Pasma{Breed="Montbeliard govedo"},
                new Pasma{Breed="Rjavo govedo"},
                new Pasma{Breed="Šarole (Charolais) govedo"},
            };

            context.Pasme.AddRange(pasme);
            context.SaveChanges();

            var znamke = new Znamka[]
            {
                new Znamka{Brand="Fendt"},
                new Znamka{Brand="Massey Ferguson"},
                new Znamka{Brand="Valtra"},
                new Znamka{Brand="Fiat Trattori"},
                new Znamka{Brand="Landini"},
                new Znamka{Brand="McCormick Tractors"},
                new Znamka{Brand="Case"},
                new Znamka{Brand="Case IH"},
                new Znamka{Brand="Caterpillar"},
                new Znamka{Brand="Claas"},
                new Znamka{Brand="New Holland"},
                new Znamka{Brand="Steyr"},
                new Znamka{Brand="John Deere"},
                new Znamka{Brand="Deutz-Fahr"},
                new Znamka{Brand="Goldoni"},
                new Znamka{Brand="JCB"},
                new Znamka{Brand="Kubota"},
                new Znamka{Brand="Komatsu"},
                new Znamka{Brand="Lamborghini"},
                new Znamka{Brand="Landini"},
                new Znamka{Brand="Lindner"},
                new Znamka{Brand="Ursus"},
                new Znamka{Brand="SAME"},
                new Znamka{Brand="IMT"},
                new Znamka{Brand="Zetor"},
            };

            context.Znamke.AddRange(znamke);
            context.SaveChanges();

            var kategorijeStrojev = new KategorijaStroja[]
            {
                new KategorijaStroja{MachineType="Traktor"},
                new KategorijaStroja{MachineType="Zgrabljalnik"},
                new KategorijaStroja{MachineType="Trosilec"},
                new KategorijaStroja{MachineType="Cisterna"},
                new KategorijaStroja{MachineType="Nakladač"},
                new KategorijaStroja{MachineType="Balirka"},
            };

            context.KategorijeStrojev.AddRange(kategorijeStrojev);
            context.SaveChanges();
        }
    }
}