using System.Collections.Generic;

namespace Demo_EmailTemplating_Coravel.Models
{
    public class Student
    {
        public string StudentCode { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Career { get; set; }
        public List<Cycle> Cycles { get; set; }
    }
}
