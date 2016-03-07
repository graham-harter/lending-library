using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibrary.Entities
{
    public class Medium : IEntityBase
    {
        public Medium()
        {
            Titles = new List<Title>();
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Title> Titles { get; set; }
    }
}
