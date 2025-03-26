using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieTub.Models
{
  public  class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<Subcategory> Subcategories { get; set; }
    }

    public class Subcategory
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }

}
