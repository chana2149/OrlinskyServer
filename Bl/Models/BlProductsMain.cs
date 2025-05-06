using System;
using System.Collections.Generic;

namespace BL.Models;

public partial class BlProductsMain
{
    public int IdProduct { get; set; }
   public DateTime? DayTaken { get; set; }
   public int IdSnif { get; set; }
    public int Id { get; set; }
    public bool CanBeUsed { get; set; }

    public bool Available { get; set; }
    public int Price { get; set; }

    public virtual BlProduct? IdProductNavigation { get; set; } = null!;

   public virtual BlSniffim? IdSnifNavigation { get; set; } = null!;
    // public virtual ICollection<BlOrder> IdOrders { get; set; } = new List<BlOrder>();
}
