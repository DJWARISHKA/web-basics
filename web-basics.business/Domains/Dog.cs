using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using web_basics.business.ViewModels;

namespace web_basics.business.Domains
{
    public class Dog
    {
        data.Repositories.Dog repository;
        IMapper mapperin;
        IMapper mapperout;

        public Dog(IConfiguration configuration)
        {
            this.repository = new data.Repositories.Dog(configuration);
            this.mapperin = new MapperConfiguration(cfg => {
                cfg.CreateMap<data.Entities.Dog, ViewModels.Dog>();
            }).CreateMapper();
            this.mapperout = new MapperConfiguration(cfg => {
                cfg.CreateMap<ViewModels.Dog, data.Entities.Dog>();
            }).CreateMapper();
        }

        public IEnumerable<ViewModels.Dog> Get()
        {
            var Dogs = repository.GetAsync();
            //Dogs.Wait();
            return Dogs.Result.Select(Dog => mapperin.Map<data.Entities.Dog, ViewModels.Dog>(Dog));
        }
        public int Add(ViewModels.Dog dog)
        {
            data.Entities.Dog tmp = mapperout.Map<ViewModels.Dog, data.Entities.Dog>(dog);
            int id = repository.AddAsync(tmp).Result;
            return id;
        }
    }
}
