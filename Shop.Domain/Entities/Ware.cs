using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Entities
{
    public class Ware
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Display(Name = "Назва")]
        [Required(ErrorMessage = "Будь ласка, введіть назву")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Опис")]
        [Required(ErrorMessage = "Будь ласка, введіть опис")]
        public string Description { get; set; }

        [Display(Name = "Категорія")]
        [Required(ErrorMessage = "Будь ласка, вкажіть категорію")]
        public string Category { get; set; }

        [Display(Name = "Ціна (грн)")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Будь ласка, введіть позитивне значення для ціни")]
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
