using System;
using System.Collections.Generic;

namespace TeachTask.DataDB
{
    public partial class DigitalImage
    {
        public int DigitalImageId { get; set; }
        public int ResourceId { get; set; }
        public int GraphicProductId { get; set; }

        public virtual GraphicProduct GraphicProduct { get; set; } = null!;
        public virtual Resource Resource { get; set; } = null!;
    }
}
