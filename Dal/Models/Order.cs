using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int IdSnif { get; set; }

    public string IdCostumer { get; set; } = null!;

    public int? Totalsum { get; set; }

    public DateTime? Date { get; set; }

    public virtual Costumer IdCostumerNavigation { get; set; } = null!;

    public virtual Snif IdSnifNavigation { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
