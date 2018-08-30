using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120Projekt
{
    static class API_Pokemon
    {
      public static void Create_Pokemon(Int64 pkdx_nr, String name, Int64 generation, Int64 angriff, Int64 verteidigung, Int64 spezial_angriff, Int64 spezial_verteidigung, Int64 KP, Int64 initiative, String pokedexEintrag, ICollection<Data.Typ> typen)
        {
            Debug.Print("--- Create Pokemon ---");
            Data.Pokemon pokemon = new Data.Pokemon();
            pokemon.Nr_Pokemon = pkdx_nr;
            pokemon.Name = name;
            pokemon.Generation = generation;
            pokemon.Angriff = angriff;
            pokemon.Verteidigung = verteidigung;
            pokemon.Spezial_Angriff = spezial_angriff;
            pokemon.Spezial_Verteidigung = spezial_verteidigung;
            pokemon.KP = KP;
            pokemon.Initiative = initiative;
            pokemon.Pokedex_Eintrag = pokedexEintrag;
            pokemon.FremdschluesselListe_Typ = typen;
            Int64 pokemonID = pokemon.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + pokemonID);
        }
        // Read
        public static void Get_All_Pokemon()
        {
            Debug.Print("--- Pokemon_Read ---");
            // Demo liest alle
            foreach (Data.Pokemon pokemon in Data.Pokemon.GetAllPokemons())
            {
                Debug.Print("Pokemon Id:" + pokemon.Nr_Pokemon + " Name:" + pokemon.Name + " Typen:" + (from record in pokemon.FremdschluesselListe_Typ select record).ToList<Data.Typ>().ToString());
            }
        }
        /**
        // Update
        public static void DemoAUpdate()
        {
            Debug.Print("--- DemoAUpdate ---");
            // Pokemon ändert Attribute
            Data.Pokemon klasseA1 = Data.Pokemon.LesenID(1);
            klasseA1.TextAttribut = "Artikel 1 nach Update";
            klasseA1.KlasseBId = 2;  // Wichtig: Fremdschlüssel muss über Id aktualisiert werden!
            klasseA1.Aktualisieren();
        }
        // Delete
        public static void DemoADelete()
        {
            Debug.Print("--- DemoADelete ---");
            Data.Pokemon.LesenID(1).Loeschen();
            Debug.Print("Artikel mit Id 1 gelöscht");
        }
        #endregion
        **/
        #region Typ
        // Create
        public static void Create_Typ(String type)
        {
            Debug.Print("--- Pokemon Create ---");
            Data.Typ typ = new Data.Typ { Type = type, ID_Typ = Get_All_Types().Count + 1};
            Int64 typID = typ.Erstellen();
            Debug.Print("Typ erstellt mit Id:" + typID);
        }
        // Read
        public static ICollection<Data.Typ> Get_All_Types()
        {
            Debug.Print("--- Pokemon_Read ---");
            ICollection<Data.Typ> types_collection = new Collection<Data.Typ>();
            List<Data.Typ> types = Data.Typ.GetAllTypes();
            foreach (Data.Typ type in types)
            {
                Debug.Print("Auslesen Typen " + type.Type);
                types_collection.Add(type);
            }
            return types_collection;
        }

        /**
        // Update
        public static void DemoBUpdate()
        {
            Debug.Print("--- DemoBUpdate ---");
            Data.Typ klasseB = Data.Typ.LesenID(1);
            klasseB.TextAttribut = "Artikelgruppe 2 nach Update";
            klasseB.Aktualisieren();
            Debug.Print("Gruppe mit Name 'Artikelgruppe 1' verändert");
        }
        // Delete
        public static void DemoBDelete()
        {
            Debug.Print("--- DemoBDelete ---");
            // Achtung! Referentielle Integrität darf nicht verletzt werden!
            try
            {
                Data.Typ klasseB = Data.Typ.LesenID(1);
                klasseB.Loeschen();
                Debug.Print("Gruppe mit Id 1 gelöscht");
            } catch (Exception ex)
            {
                Debug.Print("Fehler beim Löschen:" + ex.Message);
            }
        }
        **/
        #endregion*/
        
    }
}
