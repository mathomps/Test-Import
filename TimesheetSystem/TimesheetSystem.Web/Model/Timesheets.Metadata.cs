using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace TimesheetSystem.Web.Model
{

    // --  Timesheets Table  --

    [MetadataType(typeof(Timesheet_Metadata))]
    public partial class Timesheet
    {
    }

    public class Timesheet_Metadata
    {
        // Hide the ID column, as it is auto-generated
        [ScaffoldColumn(false)]
        public object id {get; set;}

        [DisplayFormat(DataFormatString = "{0:c}")]
        [DisplayName("Hourly Rate")]
        public object HourlyRate {get; set;}

        [DisplayName("Invoice Number")]
        public object InvoiceNumber {get; set;}

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DisplayName("Date Entered")]
        public object DateEntered {get; set;}

    }


    // --  Clients Table  --

    [MetadataType(typeof(Client_Metadata))]
    public partial class Client
    {
    }

    public class Client_Metadata
    {
        // Hide the ID column, as it is auto-generated
        [ScaffoldColumn(false)]
        public object id { get; set; }
    }

}
