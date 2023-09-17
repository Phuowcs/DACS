namespace testDACS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BIENLAIHOCPHI")]
    public partial class BIENLAIHOCPHI
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MABL { get; set; }

        public double HOCPHI { get; set; }

        public int MAHV { get; set; }

        public int MAMH { get; set; }

        public int MALOP { get; set; }

        public virtual LOP LOP { get; set; }

        public virtual HOCVIEN HOCVIEN { get; set; }

        public virtual MONHOC MONHOC { get; set; }
    }
}
