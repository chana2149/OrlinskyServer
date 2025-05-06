using Dal.Models;
using System;
using System.Collections.Generic;

namespace BL.Models;

public partial class BlProduct
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Url { get; set; }
    public string? Details { get; set; }

    public int IdCattegory { get; set; }

/*    public byte[] Image { get; set; }
*/
    public virtual BlCattegory? IdCattegoryNavigation { get; set; }

    public virtual ICollection<BlProductsMain>? ProductsMains { get; set; } = new List<BlProductsMain>();
   
}
