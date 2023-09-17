namespace testDACS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THOIKHOABIEU")]
    public partial class THOIKHOABIEU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THOIKHOABIEU()
        {
            LOPs = new HashSet<LOP>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MATKB { get; set; }

        public DateTime TUNGAY { get; set; }

        public DateTime DENNGAY { get; set; }

        [Required]
        [StringLength(31)]
        public string THU { get; set; }

        [Required]
        [StringLength(5)]
        public string CA { get; set; }

        public byte TIETBD { get; set; }

        public byte SOTIET { get; set; }

        [Required]
        [StringLength(21)]
        public string PHONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOP> LOPs { get; set; }
    }
}
