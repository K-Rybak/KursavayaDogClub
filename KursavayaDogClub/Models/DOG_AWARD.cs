namespace KursavayaDogClub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("C##RYBAK.DOG_AWARD")]
    public partial class DOG_AWARD
    {
        public int DOG_ID { get; set; }

        public int AWARD_ID { get; set; }

        public DateTime? DATE_AWARD { get; set; }

        [Key]
        public decimal ID_PRIMARY { get; set; }

        public virtual AWARD AWARD { get; set; }

        public virtual DOG DOG { get; set; }
    }
}
