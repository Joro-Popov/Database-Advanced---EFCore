using System;
using System.Collections.Generic;

namespace P02.DatabaseFirst.Data.Models
{
    public partial class Towns
    {
        public Towns()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int TownId { get; set; }
        public string Name { get; set; }

        public ICollection<Addresses> Addresses { get; set; }
    }
}
