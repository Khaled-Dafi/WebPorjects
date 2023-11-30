//2/5
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    //USING EF (ORM)
    public class Category
    {
        [Key] //this is the data annotations
        public int Id { get; set; } //this the PK
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30,ErrorMessage ="Are you Dump or did your brain fucked by someone Stopid?"),]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order must be between 1-100 you dump idiot sack of shit")]
        public int DisplayOrder { get; set; } 
    }
}
//What is Data Anotaions 