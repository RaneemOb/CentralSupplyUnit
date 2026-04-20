using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.DTOs
{
    public class WarehouseItemFlatDto
    {
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByName { get; set; }
        public int? ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? ItemDescription { get; set; }
        public int? Quantity { get; set; }
    }
}
