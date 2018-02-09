using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GameShoppa.Models
{
    public class Genre
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
