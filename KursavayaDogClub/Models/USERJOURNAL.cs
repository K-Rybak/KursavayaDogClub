namespace KursavayaDogClub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("C##RYBAK.USERJOURNAL")]
    public partial class USERJOURNAL
    {
        [Key]
        public decimal ID_JOURNAL { get; set; }

        [StringLength(255)]
        public string LOGIN_JOURNAL { get; set; }

        public DateTime? TIME_JOURNAL { get; set; }
    }
}
