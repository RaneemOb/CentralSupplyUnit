using System;
using System.Collections.Generic;
using System.Text;

namespace CentralSupplyUnit.Core.DTOs
{
    public class SupplyDocumentDto
    {
       
            public int Id { get; set; }
            public string Name { get; set; }
            public string? Subject { get; set; }

            public string WarehouseName { get; set; }
            public string ItemName { get; set; }
            public string CreatedByName { get; set; }   // 👈 جديد

            public int StatusId { get; set; }
            public string StatusName { get; set; }
            public DateTime CreatedDate { get; set; }
        }
    
}
