using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibrary.Entities
{
    public class Title : IEntityBase
    {
        public int ID { get; set; }
        public int MediumId { get; set; }
        public string Name { get; set; }
        public string Subtitle { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public Nullable<short> Year { get; set; }
        public string ImageURL { get; set; }

        public virtual Medium Medium { get; set; }
    }
}
