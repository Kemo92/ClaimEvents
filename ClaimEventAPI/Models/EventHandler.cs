using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClaimEventAPI.Models
{
    public class EventHandler
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

    }
}