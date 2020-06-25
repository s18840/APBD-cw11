using cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Configurations
{
    public class MedicamentEfConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(key => key.IdMedicament);
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.Type).HasMaxLength(100);

            var medicaments = new List<Medicament>()
            {
                new Medicament
                {
                    IdMedicament = 1,
                    Name = "Apap",
                    Description = "paracetamol",
                    Type = "glowa"
                },
                new Medicament
                {
                    IdMedicament = 2,
                    Name = "Ibuprom",
                    Description = "ibuprofen",
                    Type = "glowa"
                },
                new Medicament
                {
                    IdMedicament = 3,
                    Name = "Rennie",
                    Description = "Bolenium",
                    Type = "zgaga"
                }
            };

            builder.HasData(medicaments);
        }
    }
}
