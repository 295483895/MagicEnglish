namespace MagicEnglish.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Table")]
    public partial class Table
    {
        public int Id { get; set; }

        [Required]
        [AllowHtml]
        public string Contents { get; set; }
    }
}
