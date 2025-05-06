
using Dal.Models;
using System;
using System.Collections.Generic;

namespace BL.Models;

public partial class BlOrder
{
    public int IdOrder { get; set; }

    public int IdSnif { get; set; }

    public string IdCostumer { get; set; }
    public int? Totalsum { get; set; }

    public DateTime? Date { get; set; }

    // public virtual BlCostumer IdCostumerNavigation { get; set; } = null!;

    // public virtual BlSniffim IdSnifNavigation { get; set; } = null!;


    public virtual ICollection<BlOrderDetail>? OrderDetails { get; set; } = new List<BlOrderDetail>();

}
