using System;
using System.Collections.Generic;

namespace TeachTask.DataDB
{
    public partial class PrimarySecondary
    {
        public int PrimaryId { get; set; }
        public string Address { get; set; } = null!;
        public int SecondaryId { get; set; }
        public string NamePhotographer { get; set; } = null!;
    }
}
