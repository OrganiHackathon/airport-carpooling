using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportCarpool.Models {
    public abstract class MovementDetail {
        public int MovementDetailId { get; set; }
        public Movement Movement { get; set; }
    }
}