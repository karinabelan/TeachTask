using System;
using System.Collections.Generic;

namespace TeachTask.DataDB
{
    public partial class Primary
    {
        public Primary()
        {
            Resources = new HashSet<Resource>();
        }

        public int PrimaryId { get; set; }
        public string Address { get; set; } = null!;

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
