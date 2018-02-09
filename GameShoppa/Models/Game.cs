using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GameShoppa.Models
{
    public class Game
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Image")]
        public string Img { get; set; }
        [Required]
        [Range(5, 200)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreID { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
