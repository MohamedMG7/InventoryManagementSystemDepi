using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.BLL.Dto.ShoopinhCartDto
{
    public class ShoppingCartReadDto
    {
       
            public int CartId { get; set; }  
            public int UserId { get; set; }  
            public double TotalPrice { get; set; }  
        

    }
}
