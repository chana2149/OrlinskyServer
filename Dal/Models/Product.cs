using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdCattegory { get; set; }

    public string? Details { get; set; }

    public string? Url { get; set; }

    public virtual Cattegory IdCattegoryNavigation { get; set; } = null!;

    public virtual ICollection<ProductsMain> ProductsMains { get; set; } = new List<ProductsMain>();
}
