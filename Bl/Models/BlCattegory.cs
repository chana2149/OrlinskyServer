using System;
using System.Collections.Generic;

namespace BL.Models;

public partial class BlCattegory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<BlProduct> Products { get; set; } = new List<BlProduct>();
}
