using System;
using System.Collections.Generic;

namespace TeachTask.DataDB
{
    public partial class Secondary
    {
        public Secondary()
        {
            Resources = new HashSet<Resource>();
        }

        public int SecondaryId { get; set; }
        public string NamePhotographer { get; set; } = null!;

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
