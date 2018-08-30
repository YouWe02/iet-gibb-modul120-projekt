using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace M120Projekt.Data
{
    public class Pokemon
    {
        #region Datenbankschicht
        [Key]
        public Int64 Nr_Pokemon { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public Int64 Generation { get; set; }
        [Required]
        public Int64 Angriff { get; set; }
        public Int64 Spezial_Angriff { get; set; }
        public Int64 Verteidigung { get; set; }
        public Int64 Spezial_Verteidigung { get; set; }
        public Int64 KP { get; set; }
        public Int64 Initiative { get; set; }
        public String Pokedex_Eintrag { get; set; }
        public Byte[] Bild { get; set; }
        public ICollection<Typ> FremdschluesselListe_Typ { get; set; }
        #endregion



        #region Applikationsschicht
        public Pokemon() { }
        [NotMapped]
        public Int64 Basiswertsume
        {
            get
            {
                return Angriff + Spezial_Angriff + Verteidigung + Spezial_Verteidigung + KP + Initiative;
            }
        }
        public static List<Data.Pokemon> GetAllPokemons()
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Pokemon.Include(x => x.FremdschluesselListe_Typ) select record).ToList();
            }
        }
        public static Data.Pokemon GetPokemonByNr(Int64 Nr_Pokemon)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Pokemon.Include(x => x.FremdschluesselListe_Typ) where record.Nr_Pokemon == Nr_Pokemon select record).FirstOrDefault();
            }
        }
        public static List<Data.Pokemon> SearchByName(String name)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Pokemon.Include(x => x.FremdschluesselListe_Typ) where record.Name == name select record).ToList();
            }
        }
        public Int64 Erstellen()
        {
            if (Nr_Pokemon == null || this.Nr_Pokemon == 0)
            {
                Console.WriteLine("CREATE EXCEPTION: NR WRONG, NULL OR ZERO");
                throw new Exception("EXCEPTION AT CREATING VALUE, NR_Pokemon IS WRONG");
            }
            if (Name == null)
            {
                Console.WriteLine("CREATE EXCEPTION: NAME WRONG, NULL");
                throw new Exception("EXCEPTION AT CREATING VALUE, NAME IS WRONG");
            }


            using (var context = new Data.Context())
            {
                context.Pokemon.Add(this);
                //TODO Check ob mit null möglich, sonst throw Ex
                //if (FremdschluesselListe_Typ != null) context.Typ.Attach(FremdschluesselListe_Typ);
                context.SaveChanges();
                return this.Nr_Pokemon;
            }
        }
        public Int64 Aktualisieren()
        {
            using (var context = new Data.Context())
            {
                //TODO null Checks?
                this.FremdschluesselListe_Typ = null;
                context.Entry(this).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return this.Nr_Pokemon;
            }
        }
        public void Loeschen()
        {
            using (var context = new Data.Context())
            {
                context.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public override string ToString()
        {
            return Nr_Pokemon.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
