namespace StudDataBase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudDataBase.DataModels.StudyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "StudDataBase.DataModels.StudyContext";
        }

        protected override void Seed(StudDataBase.DataModels.StudyContext context)
        {

        }
    }
}
