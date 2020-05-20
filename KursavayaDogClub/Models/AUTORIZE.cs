namespace KursavayaDogClub.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("C##RYBAK.AUTORIZE")]
    public partial class AUTORIZE
    {
        [Key]
        public decimal ID_USER { get; set; }

        [StringLength(20)]
        public string LOGIN { get; set; }

        [StringLength(20)]
        public string PASSWORD { get; set; }
    }
}
