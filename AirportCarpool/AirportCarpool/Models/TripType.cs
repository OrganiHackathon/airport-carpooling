using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportCarpool.Models {
    public class TripType {
        public int TripTypeId { get; set; }
        public string TripTypeCode { get; set; }
        public string Description { get; set; }
    }
}