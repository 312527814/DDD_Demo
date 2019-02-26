using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Application.UserService.Dto
{
    public class GetScoreOutDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int Score { get; set; }

        public string Course { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
