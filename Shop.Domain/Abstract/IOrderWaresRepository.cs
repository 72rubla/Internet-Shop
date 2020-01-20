using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Abstract
{
    public interface IOrderWaresRepository
    {
        IEnumerable<OrderWare> OrderWares { get; }
        void SaveOrderWare(OrderWare orderware, Cart cart);
    }
}
