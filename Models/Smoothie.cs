using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieTub.Models
{
    public class Smoothie
    {
        public string Id { get; set; }  // Unique identifier
        public string Name { get; set; } // Name of the smoothie
        public string Description { get; set; } // Description
        public string ImageUrl { get; set; } // Image URL
        public List<string> Ingredients { get; set; } // List of ingredients
        public string Category { get; set; } // Smoothie category

        public Smoothie()
        {
            Ingredients = new List<string>();
        }
    }
}