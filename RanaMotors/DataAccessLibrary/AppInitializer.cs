using System;
using System.Data.Entity;

namespace DataAccessLibrary
{
    internal class AppInitializer : CreateDatabaseIfNotExists<CarContext>
    {
        protected override void Seed(CarContext context)
        {
            try
            {
                base.Seed(context);
            }
            catch (Exception exq)
            {
                var errorMsg = exq.Message;
                throw;
            }
        }
    }
}