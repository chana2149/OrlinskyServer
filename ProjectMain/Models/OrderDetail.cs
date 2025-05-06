using System;
using System.Collections.Generic;

namespace ProjectMain.Models;

public partial class OrderDetail
{
    public int IdOrder { get; set; }

    public int IdProductSpecific { get; set; }

    public string? Nothing { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual ProductsMain IdProductSpecificNavigation { get; set; } = null!;
}
