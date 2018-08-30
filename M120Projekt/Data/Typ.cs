using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Collections.ObjectModel;

namespace M120Projekt.Data
{
    public class Typ
    {
        #region Datenbankschicht
        [Key]
        public Int64 ID_Typ { get; set; }
        [Required]
        public String Type { get; set; }
        [Required]
        public ICollection<Pokemon> FremdschluesselListe_Pokemon { get; set; }
        #endregion





        #region Applikationsschicht
        public Typ() { }

        public static List<Data.Typ> GetAllTypes()
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Typ.Include(x => x.FremdschluesselListe_Pokemon) select record).ToList();
            }
        }
        public static Data.Typ GetTypeByID(Int64 idtyp)
        {
            using (var context = new Data.Context())
            {
                return (from record in context.Typ.Include(x => x.FremdschluesselListe_Pokemon) where record.ID_Typ == idtyp select record).FirstOrDefault();
            }
        }
        public static List<Data.Typ> Search(String value)
        {
            using (var context = new Data.Context())
            {
                var klasseBquery = (from record in context.Typ.Include(x => x.FremdschluesselListe_Pokemon) where record.Type == value select record).ToList();
                return klasseBquery;
            }
        }

        public Int64 Erstellen()
        {
            if (ID_Typ == null || ID_Typ == 0)
            {
                Console.WriteLine("CREATE EXCEPTION: TYPE WRONG, NULL OR ZERO");
                throw new Exception("EXCEPTION AT CREATING VALUE, ID_Typ IS WRONG");
            }
            if (Type == null)
            {
                Console.WriteLine("CREATE EXCEPTION: Type WRONG, NULL");
                throw new Exception("EXCEPTION AT CREATING VALUE, Type IS WRONG");
            }
            if(FremdschluesselListe_Pokemon == null)
            {
                FremdschluesselListe_Pokemon = new Collection<Data.Pokemon>();
            }

            using (var context = new Data.Context())
            {
                try
                {
                    context.Typ.Add(this);
                    context.SaveChanges();
                    return this.ID_Typ;
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
        }
        public void Aktualisieren()
        {
            using (var context = new Data.Context())
            {
                //TODO null Checks?
                context.Entry(this).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
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
            return ID_Typ.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
