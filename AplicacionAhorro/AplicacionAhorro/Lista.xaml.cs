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
    public partial class Lista : ContentPage
    {
        private List<Clases.Usuario> usuarios;
        public Lista()
        {
            InitializeComponent();
            indicador.BindingContext = this;            
            txtBuscar.SearchButtonPressed += TxtBuscar_SearchButtonPressed;
            btnNuevo.Clicked += BtnNuevo_Clicked;
            lista.ItemTapped += Lista_ItemTapped;
        }
        private async void Lista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var usu = (Clases.Usuario)e.Item;
            IsBusy = true;
            var usuario = await Clases.Servicio.CargarUsuario(usu.Id);
            IsBusy = false;
            await Navigation.PushAsync(new DetallePersona(usuario));
        }
        private async void BtnNuevo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }
        private async void TxtBuscar_SearchButtonPressed(object sender, EventArgs e)
        {
            IsBusy = true;
            usuarios = await Clases.Servicio.ListaUsuarios(txtBuscar.Text);
            IsBusy = false;
            lista.ItemsSource = usuarios;
        }
    }
}