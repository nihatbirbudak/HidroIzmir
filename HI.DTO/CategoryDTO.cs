using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HI.DTO
{
    public class CategoryDTO
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products{ get; set; }
    }
}
