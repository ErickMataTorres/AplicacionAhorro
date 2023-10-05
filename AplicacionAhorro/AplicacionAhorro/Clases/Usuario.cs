using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionAhorro.Clases
{
    public class Usuario
    {
        public int Id { get; set; }
        public string LoginUsuario { get; set; }
        public string Contraseña { get; set; }
        public string NombreCompleto { get; set; }
        public string Sexo { get; set; }
        public DateTime UltimoAhorro { get; set; }
        public decimal UltimoAhorrado { get; set; }
        public decimal TotalAhorrado { get; set; }
        public string Correo { get; set; }
    }
}
