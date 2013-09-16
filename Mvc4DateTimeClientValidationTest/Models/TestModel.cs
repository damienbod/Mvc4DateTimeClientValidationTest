using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc4DateTimeClientValidationTest.Models
{
    public class TestModel
    {
        public DateTime Date1 { get; set; }
        public DateTime? Date2 { get; set; }

        public DateTime NoValidationDate1 { get; set; }
        public DateTime? NoValidationDate2 { get; set; }
    }
}