﻿using cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Configurations
{
    public class PrescriptionMedicamentEfConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.HasKey(key => new { key.IdMedicament, key.IdPrescription });
            builder
                .HasOne(x => x.Prescription)
                .WithMany()
                .HasForeignKey(x => x.IdPrescription);
            builder
                .HasOne(x => x.Medicament)
                .WithMany()
                .HasForeignKey(x => x.IdMedicament);
            builder.Property(x => x.Dose).IsRequired();
            builder.Property(x => x.Details).HasMaxLength(100);

            var prescriptionMedicaments = new List<PrescriptionMedicament>
            {
                new PrescriptionMedicament
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Dose = 1,
                    Details = "one dose"
                },
                new PrescriptionMedicament
                {
                    IdMedicament = 2,
                    IdPrescription = 2,
                    Dose = 2,
                    Details = "double dose"
                },
                new PrescriptionMedicament
                {
                    IdMedicament = 3,
                    IdPrescription = 3,
                    Dose = 3,
                    Details = "tripple dose"
                }
            };

            builder.HasData(prescriptionMedicaments);
        }
    }
}
