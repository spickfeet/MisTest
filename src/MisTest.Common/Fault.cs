using System;
using System.Collections.Generic;
using System.Text;

namespace MisTest.Common
{
    public class Fault
    {
        public string Message { get; set; }
        public List<Fault> Details { get; set; }

        public Fault(string message)
        {
            Message = message;
            Details = new List<Fault>();
        }

        public Fault(string message, List<Fault> details)
        {
            Message = message;
            Details = details;
        }
    }
}
