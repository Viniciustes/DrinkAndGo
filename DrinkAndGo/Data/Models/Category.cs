using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrinkAndGo.Data.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Drink> Drinks { get; set; }
    }
}
