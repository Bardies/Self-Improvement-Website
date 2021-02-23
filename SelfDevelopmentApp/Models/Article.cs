using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Models
{
    public class Article
    {
        [Key]
        [Display(Name ="Article ID")]
        public int ID { get; set; }

        
        [Required(ErrorMessage ="Article title is required")]
        [MinLength(5 , ErrorMessage ="Title can not be less than 5 characters")]
        public string Title { get; set; }
        
        
        [Required(ErrorMessage ="Article author is required")]
        public string Author{ get; set; }


        [Required(ErrorMessage = "Article content is required")]
        [DataType(DataType.MultilineText)]
        public byte[] Text { get; set; }

        
        [Required(ErrorMessage ="Article image is required")]
        [DataType(DataType.Upload)]
        public byte[] Image { get; set; }

        
        [Display(Name ="Topic ID")]
        [ForeignKey("Topic")]
        public int TopicID{ get; set; }
        
        public virtual Topic Topic { get; set; }
    }
}
