using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.Domain.Entities;

namespace Shop.WebUI.Models
{
    public class WaresListViewModel
    {
        public IEnumerable<Ware> Wares { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}