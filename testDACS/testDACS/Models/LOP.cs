namespace testDACS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOP")]
    public partial class LOP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOP()
        {
            BIENLAIHOCPHIs = new HashSet<BIENLAIHOCPHI>();
            CT_Lich_thi = new HashSet<CT_Lich_thi>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MALOP { get; set; }

        [Required]
        [StringLength(128)]
        public string TENLOP { get; set; }

        public int MAGV { get; set; }

        public int MAKH { get; set; }

        public int MATKB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BIENLAIHOCPHI> BIENLAIHOCPHIs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_Lich_thi> CT_Lich_thi { get; set; }

        public virtual GIANGVIEN GIANGVIEN { get; set; }

        public virtual KHOAHOC KHOAHOC { get; set; }

        public virtual THOIKHOABIEU THOIKHOABIEU { get; set; }
    }
}
