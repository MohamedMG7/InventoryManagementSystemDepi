﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.DAL.Data.Models
{
	public class Payment
	{
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }
        public string PaymentStatus { get; set; }
        public TimeOnly PaymentTime { get; set; }
        //There Should be OrderId
        public int OrderId { get; set; }
        public Order order { get; set; }
    }
}
