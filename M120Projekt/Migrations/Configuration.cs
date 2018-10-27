namespace M120Projekt.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<M120Projekt.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "M120Projekt.Data.Context";
        }

        protected override void Seed(M120Projekt.Data.Context context)
        {
            ICollection<Data.Typ> preTypes = Data.Typ.GetAllTypes();
            if(preTypes.Count < 1)
            {
                IList<Data.Typ> defaultTypes = new List<Data.Typ>();
                defaultTypes.Add(new Data.Typ { Type = "Normal" });
                defaultTypes.Add(new Data.Typ { Type = "Feuer" });
                defaultTypes.Add(new Data.Typ { Type = "Wasser" });
                defaultTypes.Add(new Data.Typ { Type = "Pflanze" });
                defaultTypes.Add(new Data.Typ { Type = "Kampf" });
                defaultTypes.Add(new Data.Typ { Type = "Flug" });
                defaultTypes.Add(new Data.Typ { Type = "Elektro" });
                defaultTypes.Add(new Data.Typ { Type = "Boden" });
                defaultTypes.Add(new Data.Typ { Type = "Gestein" });
                defaultTypes.Add(new Data.Typ { Type = "Psycho" });
                defaultTypes.Add(new Data.Typ { Type = "Geist" });
                defaultTypes.Add(new Data.Typ { Type = "Drache" });
                defaultTypes.Add(new Data.Typ { Type = "Eis" });
                defaultTypes.Add(new Data.Typ { Type = "Fee" });
                defaultTypes.Add(new Data.Typ { Type = "Stahl" });
                defaultTypes.Add(new Data.Typ { Type = "Käfer" });
                defaultTypes.Add(new Data.Typ { Type = "Unlicht" });
                defaultTypes.Add(new Data.Typ { Type = "Gift" });

                context.Typ.AddRange(defaultTypes);

            }

            base.Seed(context);
        }
    }
}
