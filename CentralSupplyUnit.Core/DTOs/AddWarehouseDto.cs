using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.DTOs
{
    public class AddWarehouseDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<AddItemDto> Items { get; set; } = new();
    }
}
