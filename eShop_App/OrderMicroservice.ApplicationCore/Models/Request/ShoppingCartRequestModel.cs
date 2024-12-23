﻿using OrderMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Models.Request
{
    public class ShoppingCartRequestModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string CustomerName { get; set; }

    }
}
