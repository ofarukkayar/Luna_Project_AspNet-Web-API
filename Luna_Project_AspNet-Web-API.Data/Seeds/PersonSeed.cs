using Luna_Project_AspNet_Web_API.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luna_Project_AspNet_Web_API.Data.Seeds
{
    class PersonSeed : IEntityTypeConfiguration<Person>
    {
        private readonly int[] _ids;
        public PersonSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(
                new Person { Id = _ids[0], Name = "Peter", SurName = "Smith" },
                new Person { Id = _ids[1], Name = "Bob", SurName = "Herb" }
                );
        }
    }
}
