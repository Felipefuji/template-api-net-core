using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO.Usuarios
{
    public class DtoUserCreate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
    }
}
