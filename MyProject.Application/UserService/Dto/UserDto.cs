using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyProject.Application.UserService.Dto
{
    public class UserDto : IDto
    {
        //[MaxLength(1)]
        [Required]
        public string Name { get; set; }
        
        public int Age { get; set; }

        //[Required]
        //public test Test { get; set; }//> new test() { CreateTime = DateTime.Now };
    }
    public class test {
        [Required]
        public string Bri { get; set; }

        public DateTime CreateTime { get; set; }
    }

}
