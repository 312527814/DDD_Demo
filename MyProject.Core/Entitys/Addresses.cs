using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Core.Entitys
{
    public class Addresses : Entity
    {

        public int UserId { get; set; }

        public string Address { get; set; }

        public int Area { get; set; }
    }

}
