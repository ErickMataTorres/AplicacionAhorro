using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionAhorro.Clases
{
    public class Servicio
    {
        public static string URLBase = "http://AplicacionMovil.somee.com";
        public static async Task<Usuario> Loguear(string usu,string contraseña)
        {
            var url = URLBase + "/Usuario/Loguear";
            var ws = new HttpClient();
            var prms = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("LoginUsuario",usu),
                new KeyValuePair<string, string>("Contraseña",contraseña)
            });
            var res = await ws.PostAsync(url, prms).ConfigureAwait(false);
            var json = await res.Content.ReadAsStringAsync();
            var dato = JsonConvert.DeserializeObject<Usuario>(json);
            return dato;
        }
        public static async Task<string> RegistrarUsuario(Usuario usu)
        {
            var url = URLBase + "/Usuario/Registrar";
            var ws = new HttpClient();
            var prms = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("Id",usu.Id.ToString()),
                new KeyValuePair<string, string>("LoginUsuario",usu.LoginUsuario),
                new KeyValuePair<string, string>("Contraseña",usu.Contraseña),
                new KeyValuePair<string, string>("NombreCompleto",usu.NombreCompleto),
                new KeyValuePair<string, string>("Sexo",usu.Sexo),
                new KeyValuePair<string, string>("UltimoAhorro",usu.UltimoAhorro.ToString("dd/MM/yyyy")),
                new KeyValuePair<string, string>("UltimoAhorrado",usu.UltimoAhorrado.ToString()),
                new KeyValuePair<string, string>("Correo",usu.Correo)
            });
            var res = await ws.PostAsync(url, prms).ConfigureAwait(false);
            var dato = await res.Content.ReadAsStringAsync();
            return dato;

        }
        public static async Task<Usuario> CargarUsuario(int id)
        {
            var url = URLBase + "/Usuario/CargarUsuario";
            var ws = new HttpClient();
            var prms = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("Id",id.ToString())
            });
            var res = await ws.PostAsync(url, prms).ConfigureAwait(false);
            var json = await res.Content.ReadAsStringAsync();
            var dato = JsonConvert.DeserializeObject<Usuario>(json);
            return dato;
        }
        public static async Task<List<Usuario>> ListaUsuarios(string texto)
        {
            var url = URLBase + "/Usuario/Lista";
            var ws = new HttpClient();
            var prms = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string,string>("Texto", texto)
            });
            var res = await ws.PostAsync(url, prms).ConfigureAwait(false);
            var json = await res.Content.ReadAsStringAsync();
            var dato = JsonConvert.DeserializeObject<List<Usuario>>(json);
            return dato;
        }
        public static async Task<List<Usuario>> ListaAhorro(int id)
        {
            var url = URLBase + "/Usuario/ListaAhorro";
            var ws = new HttpClient();
            var prms = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("Id", id.ToString())
            });
            var res = await ws.PostAsync(url, prms).ConfigureAwait(false);
            var json = await res.Content.ReadAsStringAsync();
            var dato = JsonConvert.DeserializeObject<List<Usuario>>(json);
            return dato;
        }
    }
}
