﻿using Shop.Domain.Abstract;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Order> Orders
        {
            get { return context.Orders; }
        }

        public void SaveOrder(Order order)
        {
            if (order.Id == 0)
                context.Orders.Add(order);
            else
            {
                Order dbEntry = context.Orders.Find(order.Id);
                if (dbEntry != null)
                {
                    dbEntry.Date = DateTime.Today;
                    dbEntry.Sum = order.Sum;
                    dbEntry.User1 = order.User1;
                    dbEntry.Wares = order.Wares;
                }
            }
            context.SaveChanges();
        }
    }
}
