using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.DTOs
{
    public class AddSupplyDocumentDto
    {
        public required string Name { get; set; }
        public string? Subject { get; set; }
        public int WarehouseId { get; set; }
        public int ItemId { get; set; }
    }
}
