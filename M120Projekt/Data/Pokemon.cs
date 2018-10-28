using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace M120Projekt.Data
{
    public class Pokemon
    {
        #region Datenbankschicht
        [Key]
        public Int64 Nr_Pokemon { get; set; }
        public String Name { get; set; }
        public Int64 Generation { get; set; }
        public Int64 Angriff { get; set; }
        public Int64 Spezial_Angriff { get; set; }
        public Int64 Verteidigung { get; set; }
        public Int64 Spezial_Verteidigung { get; set; }
        public Int64 KP { get; set; }
        public Int64 Initiative { get; set; }
        public String Pokedex_Eintrag { get; set; }
        public Byte[] Bild { get; set; }
        public virtual ICollection<Typ> Typs { get; set; }
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
            using (var context = new Context())
            {
                return (from record in context.Pokemons.Include(x => x.Typs) select record).ToList();
            }
        }
        public static Data.Pokemon GetPokemonByNr(Int64 Nr_Pokemon)
        {
            using (var context = new Context())
            {
                return (from record in context.Pokemons.Include(x => x.Typs) where record.Nr_Pokemon == Nr_Pokemon select record).FirstOrDefault();
            }
        }
        public static List<Data.Pokemon> SearchByName(String name)
        {
            using (var context = new Context())
            {
                return (from record in context.Pokemons.Include(x => x.Typs) where record.Name.StartsWith(name) select record).ToList();
            }
        }
        public Int64 Erstellen(List<Int64> typen)
        {
            using (var context = new Context())
            {
                foreach(Int64 id in typen)
                {
                    Typ typ = context.Typs.FirstOrDefault(t => t.ID_Typ == id);
                    Typs.Add(typ);
                }
                context.Pokemons.Add(this);
                //TODO Check ob mit null möglich, sonst throw Ex
                //if (FremdschluesselListe_Typ != null) context.Typ.Attach(FremdschluesselListe_Typ);
                context.SaveChanges();
                return this.Nr_Pokemon;
            }
        }
        public Int64 Aktualisieren()
        {
            using (var context = new Context())
            {
                //TODO null Checks?
                this.Typs = null;
                context.Entry(this).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return this.Nr_Pokemon;
            }
        }
        public void Loeschen()
        {
            using (var context = new Context())
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
