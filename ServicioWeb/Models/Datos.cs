using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb.Models
{
    public class Datos
    {
        public static SqlConnection Conectar()
        {
            var conx = new SqlConnection("SERVER=AplicacionAhorro.mssql.somee.com; DATABASE=AplicacionAhorro; USER ID=Abcdefghijxa_SQLLogin_1; PWD=hbl5mf35c2;");
            return conx;
        }
    }
}