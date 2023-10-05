using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb.Models
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
        public DateTime FechaRegistro { get; set; }
        public string Correo { get; set; }
        public static Usuario Loguear(string loginUsuario,string contraseña)
        {
            var conx = Datos.Conectar();
            Usuario usu = new Usuario();
            SqlCommand command = new SqlCommand("spConsultaLogin", conx);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr;
            command.Parameters.AddWithValue("@LoginUsuario", loginUsuario);
            command.Parameters.AddWithValue("@Contraseña", contraseña);
            conx.Open();
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                usu.Id = dr.GetInt32(0);
                usu.LoginUsuario = loginUsuario;
                usu.Contraseña = contraseña;
            }
            dr.Close();
            conx.Close();
            return usu;
        }
        public string Guardar()
        {
            var respuesta = "";
            var conx = Datos.Conectar();
            var command = new SqlCommand("spRegistrarUsuario", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", Id);
            command.Parameters.AddWithValue("@LoginUsuario", LoginUsuario);
            command.Parameters.AddWithValue("@Contraseña", Contraseña);
            command.Parameters.AddWithValue("@NombreCompleto", NombreCompleto);
            command.Parameters.AddWithValue("@Sexo", Sexo);
            command.Parameters.AddWithValue("@UltimoAhorrado", UltimoAhorrado);
            command.Parameters.AddWithValue("@Correo", Correo);
            try
            {
                conx.Open();
                command.ExecuteNonQuery();
                conx.Close();
            }
            catch(Exception error)
            {
                respuesta = "Error, " + error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    conx.Close();
                }
            }
            return respuesta;
        }
        public static Usuario Cargar(int id)
        {
            var usu = new Usuario();
            var conx = Datos.Conectar();
            var command = new SqlCommand("spConsultarUsuario", conx);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr;
            command.Parameters.AddWithValue("@Id", id);
            conx.Open();
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                usu.Id = id;
                usu.NombreCompleto = dr.GetString(1);
                usu.Sexo = dr.GetString(2);
                usu.UltimoAhorro = dr.GetDateTime(3);
                usu.UltimoAhorrado = dr.GetDecimal(4);
                usu.TotalAhorrado = dr.GetDecimal(5);
                usu.FechaRegistro = dr.GetDateTime(6);
                usu.Correo = dr.GetString(7);
            }
            dr.Close();
            conx.Close();
            return usu;
        }
        public static List<Usuario> Lista(string texto)
        {
            var lista = new List<Usuario>();
            var conx = Datos.Conectar();
            var command = new SqlCommand("spListaUsuario", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Texto", texto);
            Usuario u;
            SqlDataReader dr;
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                u = new Usuario();
                u.Id = dr.GetInt32(0);
                u.LoginUsuario = dr.GetString(1);
                u.NombreCompleto = dr.GetString(2);
                u.Sexo = dr.GetString(3);
                u.UltimoAhorro = dr.GetDateTime(4);
                u.UltimoAhorrado = dr.GetDecimal(5);
                u.TotalAhorrado = dr.GetDecimal(6);
                u.FechaRegistro = dr.GetDateTime(7);
                u.Correo = dr.  GetString(8);
                lista.Add(u);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
        public static List<Usuario> ListaAhorro(int id)
        {
            var lista = new List<Usuario>();
            var conx = Datos.Conectar();
            var command = new SqlCommand("spListaAhorro", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            Usuario u;
            SqlDataReader dr;
            conx.Open();
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                u = new Usuario();
                u.Id = id;
                u.NombreCompleto = dr.GetString(2);
                u.UltimoAhorro = dr.GetDateTime(3);
                u.UltimoAhorrado = dr.GetDecimal(4);
                u.TotalAhorrado = dr.GetDecimal(5);
                u.FechaRegistro = dr.GetDateTime(6);
                u.Correo = dr.GetString(7);
                lista.Add(u);
            }
            dr.Close();
            conx.Close();
            return lista;
        }
    }
}