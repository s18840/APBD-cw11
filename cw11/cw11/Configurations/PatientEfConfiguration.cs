using cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Configurations
{
    public class PatientEfConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(key => key.IdPatient);
            builder.Property(x => x.FirstName).HasMaxLength(100);
            builder.Property(x => x.LastName).HasMaxLength(100);

            var patients = new List<Patient>
            {
                new Patient
                {
                  IdPatient  = 1,
                  FirstName = "Andrzej",
                  LastName = "Waski",
                  BirthDate = Convert.ToDateTime("1981-11-12")
                },
                new Patient
                {
                    IdPatient  = 2,
                    FirstName = "Jan",
                    LastName = "Pazdzioch",
                    BirthDate = Convert.ToDateTime("2000-01-11")
                },
                new Patient
                {
                    IdPatient  = 3,
                    FirstName = "Artur",
                    LastName = "Zdzichowski",
                    BirthDate = Convert.ToDateTime("1989-05-12")
                }
            };

            builder.HasData(patients);
        }
    }
}
