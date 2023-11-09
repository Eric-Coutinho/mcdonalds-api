using System;
using System.Collections.Generic;

namespace mcdonalds_api.Model;

public partial class ClientOrder
{
    public int Id { get; set; }

    public string OrderCode { get; set; }

    public int StoreId { get; set; }

    public DateTime Moment { get; set; }

    public DateTime? DeliveryMoment { get; set; }

    public virtual ICollection<ClientOrderItem> ClientOrderItems { get; set; } = new List<ClientOrderItem>();

    public virtual Store Store { get; set; }
}
