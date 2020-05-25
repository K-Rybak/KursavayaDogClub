namespace KursavayaDogClub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("C##RYBAK.DOG_ARCHIVE")]
    public partial class DOG_ARCHIVE
    {
        [Key]
        public decimal DOG_ID_A { get; set; }

        [StringLength(25)]
        public string DOG_NAME_A { get; set; }

        public decimal? OWNER_ID_A { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BIRTH_DATE_A { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DEATH_DATE_A { get; set; }

        [StringLength(6)]
        public string SEX_A { get; set; }

        public decimal? ID_FATHER_A { get; set; }

        public decimal? ID_MOTHER_A { get; set; }

        public decimal? ID_BREED_A { get; set; }
    }
}
