using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Models
{
    public class LevelText
    {
        [Key]
        public int Id { get; set; }
        public int StoryLevel { get; set; }
        public Int16 LevelNummber { get; set; }

        public string StoryText { get; set; }
        [StringLength(10)]
        public string LineColor { get; set; }
    }
}
