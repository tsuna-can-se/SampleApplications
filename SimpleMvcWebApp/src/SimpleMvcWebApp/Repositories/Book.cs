namespace SimpleMvcWebApp.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [StringLength(512)]
        [Display(Name = "���Ж�")]
        public string Name { get; set; }

        [Display(Name = "���i")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = false)]
        public decimal? Price { get; set; }

        [StringLength(256)]
        [Display(Name = "����")]
        public string Author { get; set; }

        [StringLength(256)]
        [Display(Name = "�o�Ŏ�")]
        public string Publisher { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
