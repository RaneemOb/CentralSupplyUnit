using System;
using System.Collections.Generic;

namespace CentralSupplyUnit.Core.Entities;

public partial class SupplyDocument
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Subject { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int WarehouseId { get; set; }

    public int ItemId { get; set; }

    public int Status { get; set; }

    public virtual User CreatedByNavigation { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}
