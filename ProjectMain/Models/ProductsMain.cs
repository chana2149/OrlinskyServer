using System;
using System.Collections.Generic;

namespace ProjectMain.Models;

public partial class ProductsMain
{
    public int? IdProduct { get; set; }

    public int IdSnif { get; set; }

    public int Id { get; set; }

    public bool Available { get; set; }

    public int Price { get; set; }

    public DateTime? DayTaken { get; set; }

    public bool? CanBeUsed { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual Snif IdSnifNavigation { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Costumer> IdCusts { get; set; } = new List<Costumer>();
}
