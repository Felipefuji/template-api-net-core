using System;
using System.Collections.Generic;
using System.Text;

namespace $safeprojectname$.$safeprojectname$.APIContext.Models
{
    public partial class Usuarios
    {
        public Usuarios() 
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Telefono { get; set; }
        public byte Activo { get; set; }
    }
}
