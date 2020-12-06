using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Data.APIContext.Models
{
    public partial class User
    {
        public User() 
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public byte IsEnable { get; set; }
    }
}
