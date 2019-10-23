using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)//uses the migration - entity framework translating our models into SQL 
        {
            context.Database.EnsureCreated();
        }


    }
}
