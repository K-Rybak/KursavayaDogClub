namespace KursavayaDogClub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("C##RYBAK.OWNER")]
    public partial class OWNER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OWNER()
        {
            DOG = new HashSet<DOG>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OWNER_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string OWNER_SURNAME { get; set; }

        [Required]
        [StringLength(20)]
        public string OWNER_NAME { get; set; }

        [Required]
        [StringLength(20)]
        public string OWNER_PATRONYMIC { get; set; }

        public int ID_DISTRICT { get; set; }

        public int ID_STREET { get; set; }

        public short? NUM_HOUSE { get; set; }

        public short? NUM_APARTMENT { get; set; }

        [StringLength(11)]
        public string NUM_PHONE { get; set; }

        public virtual DISTRICT DISTRICT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOG> DOG { get; set; }

        public virtual STREET STREET { get; set; }
    }
}
