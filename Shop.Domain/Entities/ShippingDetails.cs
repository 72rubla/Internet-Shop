using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Вкажіть ім’я")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Вкажіть телефон")]

        [Display(Name = "Телефон")]
        public string Line1 { get; set; }

        [Required(ErrorMessage = "Вкажіть E-Mail")]
        [Display(Name = "E-Mail")]
        public string Line2 { get; set; }

        [Required(ErrorMessage = "Вкажіть адрес")]
        [Display(Name = "Адрес")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Вкажіть місто")]
        [Display(Name = "Місто")]
        public string City { get; set; }

        //[Required(ErrorMessage = "Укажите страну")]
        //[Display(Name = "Страна")]
        //public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
