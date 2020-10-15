using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace web_basics.data
{
    public static class DbInitializer
    {
        public static async void Initialize(WebBasicsDBContext context)
        {         
            await context.Database.EnsureCreatedAsync();

            if (!(await context.Cats.AnyAsync()))
            {
                await context.Cats.AddRangeAsync(new Entities.Cat[] { 
                new Entities.Cat() { Name = "Barsik", Age = 3 },
                new Entities.Cat() { Name = "Kozkii", Age = 4 },
                new Entities.Cat() { Name = "Murka", Age = 13 },
                new Entities.Cat() { Name = "Bony", Age = 2 }
            });

                await context.SaveChangesAsync();
            }
            if (!(await context.Dogs.AnyAsync()))
            {
                await context.Dogs.AddRangeAsync(new Entities.Dog[] {
                new Entities.Dog() { Name = "Barbos", Age = 5 },
                new Entities.Dog() { Name = "Lexa", Age = 1 },
                new Entities.Dog() { Name = "Sharik", Age = 10 },
            });
                await context.SaveChangesAsync();
            }
        }
    }
}
