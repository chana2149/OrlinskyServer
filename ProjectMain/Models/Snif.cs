using System;
using System.Collections.Generic;

namespace ProjectMain.Models;

public partial class Snif
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProductsMain> ProductsMains { get; set; } = new List<ProductsMain>();
}
