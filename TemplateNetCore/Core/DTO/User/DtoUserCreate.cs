using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO.User
{
    public class DtoUserCreate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool IsEnable { get; set; }
    }
}
