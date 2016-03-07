using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LendingLibrary.Entities;

namespace LendingLibrary.Data.Configurations
{
    public class TitleConfiguration : EntityBaseConfiguration<Title>
    {
        public TitleConfiguration()
        {
            Property(t => t.MediumId).IsRequired();
            Property(t => t.Name).IsRequired().HasMaxLength(200);
            Property(t => t.Subtitle).HasMaxLength(300);
            Property(t => t.Author).IsRequired().HasMaxLength(200);
            Property(t => t.Publisher).IsRequired().HasMaxLength(50);
            Property(t => t.Year).IsOptional();
            Property(t => t.ImageURL).IsOptional().HasMaxLength(200);
        }
    }
}
