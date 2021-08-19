using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Luna_Project_AspNet_Web_API.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} is required!")]
        public string Name { get; set; }

        [Range(0,int.MaxValue, ErrorMessage ="{0} cannot be negative number!")]
        public int Stock { get; set; }

        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "{0} must be greater than zero!")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
