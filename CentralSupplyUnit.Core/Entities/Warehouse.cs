using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CentralSupplyUnit.Core.Entities;

public partial class Warehouse
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    [JsonIgnore]
    public virtual User ?CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<SupplyDocument> SupplyDocuments { get; set; } = new List<SupplyDocument>();
}
