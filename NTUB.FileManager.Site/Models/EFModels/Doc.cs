namespace NTUB.FileManager.Site.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Doc
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string Title { get; set; }

        [StringLength(60)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(40)]
        public string FileName { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime ModifiedTime { get; set; }
    }
}
