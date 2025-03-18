using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieTub.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public string ImageFile { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Instructions { get; set; }
    }

}
