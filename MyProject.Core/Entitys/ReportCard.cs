using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Core.Entitys
{
    public class ReportCard : Entity
    {
        public int UserId { get; set; }

        public int Score { get; set; }

        public string Course { get; set; }


    }
}
