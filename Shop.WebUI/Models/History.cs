using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.Domain.Entities;

namespace Shop.WebUI.Models
{
    public class History
    {
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Ware> Wares { get; set; }
        public IEnumerable<OrderWare> OrderWares { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}