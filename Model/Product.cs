using System;
using System.Collections.Generic;

namespace mcdonalds_api.Model;

public partial class Product
{
    public int Id { get; set; }

    public string ItemName { get; set; }

    public byte[] Photo { get; set; }

    public string DescriptionText { get; set; }

    public virtual ICollection<ClientOrderItem> ClientOrderItems { get; set; } = new List<ClientOrderItem>();

    public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
}
