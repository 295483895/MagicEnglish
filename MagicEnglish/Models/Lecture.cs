namespace MagicEnglish.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lecture")]
    public partial class Lecture
    {
        public int Id { get; set; }

        [Required]
        public string NAME { get; set; }

        [Required]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        public string Score { get; set; }

        public int Score_num { get; set; }
    }
}
