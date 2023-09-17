namespace testDACS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_Lich_thi
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MALOP { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MALT { get; set; }

        public DateTime NGAYTHI { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime GIOBD { get; set; }

        public short? SOPHUT { get; set; }

        [Required]
        [StringLength(21)]
        public string PHONG { get; set; }

        [StringLength(31)]
        public string GHICHU { get; set; }

        public virtual LOP LOP { get; set; }

        public virtual LICHTHI LICHTHI { get; set; }
    }
}
