using cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Configurations
{
    public class PrescriptionEfConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(key => key.IdPrescription);
            builder
                .HasOne(x => x.Patient)
                .WithMany()
                .HasForeignKey(x => x.IdPatient);
            builder
                .HasOne(x => x.Doctor)
                .WithMany()
                .HasForeignKey(x => x.IdDoctor);

            var prescriptions = new List<Prescription>
            {
                new Prescription
                {
                    IdPrescription = 1,
                    Date = Convert.ToDateTime("2020-01-01"),
                    DueDate = Convert.ToDateTime("2021-12-12"),
                    IdPatient = 1,
                    IdDoctor = 1
                },
                new Prescription
                {
                    IdPrescription = 2,
                    Date = Convert.ToDateTime("2019-04-01"),
                    DueDate = Convert.ToDateTime("2019-07-01"),
                    IdPatient = 2,
                    IdDoctor = 2
                },
                new Prescription
                {
                    IdPrescription = 3,
                    Date = Convert.ToDateTime("2020-06-01"),
                    DueDate = Convert.ToDateTime("2020-09-03"),
                    IdPatient = 3,
                    IdDoctor = 3
                }
            };

            builder.HasData(prescriptions);
        }
    }
}
