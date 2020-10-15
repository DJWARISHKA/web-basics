using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_basics.data.Entities;

namespace web_basics.data.Repositories
{
    public class Dog
    {
        WebBasicsDBContext context;

        public Dog(IConfiguration configuration)
        {
            this.context = new WebBasicsDBContext(configuration);
        }

        public async Task<IEnumerable<Entities.Dog>> GetAsync()
        {
            var Dogs = await context.Dogs.ToListAsync();
            return Dogs;
        }

        public async Task<int> AddAsync(Entities.Dog dog)
        {
            await context.AddAsync(dog);
            await context.SaveChangesAsync();
            return dog.Id;
        }
    }
}
