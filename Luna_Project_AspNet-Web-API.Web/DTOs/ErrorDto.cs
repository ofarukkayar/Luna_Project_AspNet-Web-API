using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luna_Project_AspNet_Web_API.Web.DTOs
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }
        public List<String> Errors { get; set; }
        public int Status { get; set; }
    }
}
