using System;
using System.Collections.Generic;

namespace CentralSupplyUnit.Core.Entities;

public partial class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Quantity { get; set; }

    public int WarehouseId { get; set; }

    public virtual ICollection<SupplyDocument> SupplyDocuments { get; set; } = new List<SupplyDocument>();

    public virtual Warehouse Warehouse { get; set; } = null!;
}
