using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieApplicationCore.Models
{
    public class MovieModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter movie name")]
        [StringLength(30,ErrorMessage ="Movie name characters should not be more than 30")]
        public string MovieName { get; set; }
        [Required(ErrorMessage = "Please enter movie description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter movie langauge")]
        public string MovieLangauge { get; set; }
    }
}
