using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.Entities;
using Shop.Domain.Abstract;

namespace Shop.Domain.Concrete
{
    public class EFWareRepository : IWareRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Ware> Wares
        {
            get { return context.Wares; }
        }
        //OrderWare ow = new OrderWare();
        
        public void SaveWare(Ware ware)
        {
            
            if (ware.ID == 0)
                context.Wares.Add(ware);
            else
            {
                Ware dbEntry = context.Wares.Find(ware.ID);
                if (dbEntry != null)
                {
                    dbEntry.Name = ware.Name;
                    dbEntry.Description = ware.Description;
                    dbEntry.Price = ware.Price;
                    dbEntry.Category = ware.Category;
                    dbEntry.ImageData = ware.ImageData;
                    dbEntry.ImageMimeType = ware.ImageMimeType;
                }
            }
            context.SaveChanges();
        }
        public Ware DeleteWare(int ID)
        {
            Ware dbEntry = context.Wares.Find(ID);
            if (dbEntry != null)
            {
                context.Wares.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
