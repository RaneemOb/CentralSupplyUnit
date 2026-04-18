using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.DTOs
{
    public class AddItemDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int WarehouseId { get; set; }
    }
}
