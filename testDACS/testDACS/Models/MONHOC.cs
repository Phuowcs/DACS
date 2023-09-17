namespace testDACS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MONHOC")]
    public partial class MONHOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MONHOC()
        {
            BIENLAIHOCPHIs = new HashSet<BIENLAIHOCPHI>();
            Du_thi = new HashSet<Du_thi>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAMH { get; set; }

        [Required]
        [StringLength(128)]
        public string TENMH { get; set; }

        [Required]
        [StringLength(128)]
        public string NOIDUNG { get; set; }

        public short TONGTIET { get; set; }

        public int MADC { get; set; }

        public int MALV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BIENLAIHOCPHI> BIENLAIHOCPHIs { get; set; }

        public virtual DECUONG DECUONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Du_thi> Du_thi { get; set; }

        public virtual LINHVUC LINHVUC { get; set; }
    }
}
