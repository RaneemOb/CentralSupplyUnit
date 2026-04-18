using System;
using System.Collections.Generic;

namespace CentralSupplyUnit.Core.Entities;

public partial class User
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<SupplyDocument> SupplyDocuments { get; set; } = new List<SupplyDocument>();

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
