using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LendingLibrary.Entities;

namespace LendingLibrary.Data.Configurations
{
    public class MediumConfiguration : EntityBaseConfiguration<Medium>
    {
        public MediumConfiguration()
        {
            Property(m => m.Name).IsRequired().HasMaxLength(50);
        }
    }
}
