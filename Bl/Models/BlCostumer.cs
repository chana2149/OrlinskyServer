using BL.Models;
using Dal.Models;
using System;
using System.Collections.Generic;

namespace BL.Models;

public partial class BlCostumer
{
    public string Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public virtual ICollection<BlProductsMain> IdFavorates { get; set; } = new List<BlProductsMain>();

    // public virtual ICollection<BlOrder> Orders { get; set; } = new List<BlOrder>();
}
