using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.Entities;

namespace Shop.Domain.Abstract
{
    public interface IWareRepository
    {
        IEnumerable<Ware> Wares { get; }
        void SaveWare(Ware ware);
        Ware DeleteWare(int ID);
    }
}
