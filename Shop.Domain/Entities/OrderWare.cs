using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class OrderWare
    {
        public int ID { get; set; }       
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int WareId { get; set; }
        public virtual User Users { get; set; }
        public virtual Order Orders { get; set; }
        public virtual Ware Wares { get; set; }
    }
}