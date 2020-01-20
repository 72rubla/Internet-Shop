using Shop.Domain.Abstract;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Concrete
{
    public class EFOrderWaresRepository : IOrderWaresRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<OrderWare> OrderWares
        {
            get { return context.OrderWares; }
        }
        public void SaveOrderWare(OrderWare orderware, Cart cart)
        {
            if (orderware.ID == 0)
                context.OrderWares.Add(orderware);
            else
            {
                OrderWare dbEntry = context.OrderWares.Find(orderware.ID);
                if (dbEntry != null)
                {
                    //dbEntry.OrderId = orderware.OrderId;
                    //dbEntry.UserId = orderware.UserId;
                    //dbEntry.WareId = orderware.WareId;
                    foreach (var item in cart.Lines)
                    {
                        dbEntry.OrderId = orderware.OrderId;
                        dbEntry.UserId = orderware.UserId;
                        dbEntry.WareId = item.Ware.ID;
                        context.SaveChanges();
                    }
                }
            }
            context.SaveChanges();
        }        
    }
}
