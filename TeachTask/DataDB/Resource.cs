using System;
using System.Collections.Generic;

namespace TeachTask.DataDB
{
    public partial class Resource
    {
        public Resource()
        {
            DigitalImages = new HashSet<DigitalImage>();
        }

        public int ResourceId { get; set; }
        public int PrimaryId { get; set; }
        public int SecondaryId { get; set; }

        public virtual Primary Primary { get; set; } = null!;
        public virtual Secondary Secondary { get; set; } = null!;
        public virtual ICollection<DigitalImage> DigitalImages { get; set; }
    }
}
