namespace KursavayaDogClub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("C##RYBAK.DOG")]
    public partial class DOG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOG()
        {
            DOG_AWARD = new HashSet<DOG_AWARD>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DOG_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string DOG_NAME { get; set; }

        public int OWNER_ID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BIRTH_DATE { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DEATH_DATE { get; set; }

        [Required]
        [StringLength(6)]
        public string SEX { get; set; }

        public int? ID_FATHER { get; set; }

        public int? ID_MOTHER { get; set; }

        public int? ID_BREED { get; set; }

        public virtual BREED BREED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOG_AWARD> DOG_AWARD { get; set; }

        public virtual OWNER OWNER { get; set; }
    }
}
