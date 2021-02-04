using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Data.APIContext.Models
{
    public partial class Client
    {
        public Client()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Telephone { get; set; }
        public string Cif { get; set; }
        public byte IsEnable { get; set; }
    }
}
