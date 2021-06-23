using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieApplicationCore.Models
{
    public class LanguageModel
    {
        [Key]
        public int Id { get; set; }
        public string Language { get; set; }
    }
}
