using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Luna_Project_AspNet_Web_API.Web.DTOs
{
    
    public class CategoryDto
    {

        public int Id { get; set; }


        [Required(ErrorMessage ="{0} cannot be empty!")]
        public string Name { get; set; }
    }
}
