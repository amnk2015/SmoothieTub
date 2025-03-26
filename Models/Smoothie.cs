using System.Collections.Generic;

namespace SmoothieTub.Models
{
    public class Smoothie
    {
        public string Id { get; set; }  // Firebase key (optional)
        public string Name { get; set; } // Smoothie name
        public string Description { get; set; } // Description
        public string ImageUrl { get; set; } // Image URL
        public List<string> Ingredients { get; set; } // List of ingredients
        public List<string> Instructions { get; set; } // List of instructions
        public string Category { get; set; } // Smoothie category
        public string Subcategory { get; set; } // ✅ Added Subcategory (To Match Categories)
        public List<string> HealthBenefits { get; set; } // List of instructions


        public Smoothie()
        {
            Ingredients = new List<string>();
            Instructions = new List<string>();
            HealthBenefits = new List<string>();
        }
    }
}
