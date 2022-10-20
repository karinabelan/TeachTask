using System;
using System.Collections.Generic;

namespace TeachTask.DataDB
{
    public partial class GraphicProduct
    {
        public GraphicProduct()
        {
            DigitalImages = new HashSet<DigitalImage>();
        }

        public int GraphicProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<DigitalImage> DigitalImages { get; set; }
    }
}
