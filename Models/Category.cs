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
        [MaxLength(30,ErrorMessage ="NOOOO?"),]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="NOOOO")]
        public int DisplayOrder { get; set; } 
    }
}
//What is Data Anotaions 
