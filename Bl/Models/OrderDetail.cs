
using Dal.Models;
using System;
using System.Collections.Generic;

namespace BL.Models;


public partial class BlOrderDetail
{
    public int IdOrder { get; set; }

    public int IdProductSpecific { get; set; }

    public string Nothing { get; set; }

    //public virtual Order IdOrderNavigation { get; set; } = null!;
  public virtual BlProductsMain2? IdProductSpecificNavigation { get; set; } = null!;
}
