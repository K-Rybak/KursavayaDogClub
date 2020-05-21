using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KursavayaDogClub.Models
{
    public class QueryOneModel
    {
        public string Surname { get; set; }
        public int Count { get; set; }
        public DateTime? EarlyDate { get; set; }
        public DateTime? LaterDate { get; set; }

    }
}