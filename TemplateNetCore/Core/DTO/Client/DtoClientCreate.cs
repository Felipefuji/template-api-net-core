using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO.Client
{
    public class DtoClientCreate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Telephone { get; set; }
        public string Cif { get; set; }
        public bool IsEnable { get; set; }
    }
}
