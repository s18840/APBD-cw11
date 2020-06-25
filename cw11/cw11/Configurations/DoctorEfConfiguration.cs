using cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Configurations
{
    public class DoctorEfConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(key => key.IdDoctor);
            builder.Property(x => x.FirstName).HasMaxLength(100);
            builder.Property(x => x.LastName).HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(100);

            var doctors = new List<Doctor>
            {
                new Doctor
                {
                    IdDoctor = 1,
                    FirstName = "Anton",
                    LastName = "Toshkin",
                    Email = "anton.toshkin@gmail.com"
                },
                new Doctor
                {
                    IdDoctor = 2,
                    FirstName = "Rob",
                    LastName = "Steves",
                    Email = "robbson@company.com"
                },
                new Doctor
                {
                    IdDoctor = 3,
                    FirstName = "Jake",
                    LastName = "Sorensen",
                    Email = "jake.sor@wp.pl"
                }
            };

            builder.HasData(doctors);
        }
    }
}
