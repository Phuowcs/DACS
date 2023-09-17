namespace testDACS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOCVIEN")]
    public partial class HOCVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOCVIEN()
        {
            BIENLAIHOCPHIs = new HashSet<BIENLAIHOCPHI>();
            Du_thi = new HashSet<Du_thi>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAHV { get; set; }

        [Required]
        [StringLength(11)]
        public string TENHV { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(64)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(31)]
        public string HOLOT { get; set; }

        public DateTime NGAYSINH { get; set; }

        [Required]
        [StringLength(3)]
        public string GIOITINH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BIENLAIHOCPHI> BIENLAIHOCPHIs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Du_thi> Du_thi { get; set; }
    }
}
