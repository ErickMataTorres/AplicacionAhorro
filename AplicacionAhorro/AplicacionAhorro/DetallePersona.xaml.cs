using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicacionAhorro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallePersona : ContentPage
    {
        private Clases.Usuario usuario;
        private List<Clases.Usuario> listaUsuario;
        public DetallePersona(Clases.Usuario u)
        {
            InitializeComponent();
            usuario = u;
            MostrarDatos();
            ListaAhorro();
        }
        private void MostrarDatos()
        {
            lblId.Text = usuario.Id.ToString();
            lblNombreCompleto.Text = usuario.NombreCompleto;
            lblSexo.Text = usuario.Sexo;
            lblCorreo.Text = usuario.Correo;
            lblTotalAhorrado.Text ="Total ahorrado: "+usuario.TotalAhorrado.ToString();
        }
        private async void ListaAhorro()
        {
            listaUsuario = await Clases.Servicio.ListaAhorro(int.Parse(lblId.Text));
            lista.ItemsSource = listaUsuario;
        }
    }
}