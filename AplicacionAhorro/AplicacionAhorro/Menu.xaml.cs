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
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
            btnCerrarSesion.Clicked += BtnCerrarSesion_Clicked;
            btnLista.Clicked += BtnLista_Clicked;
        }

        private void BtnLista_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Lista());
        }

        private async void BtnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            var res = await DisplayAlert("Confirmar", "¿Realmente cerrar sesión?", "Si", "No");
            if (res)
            {
                App.Current.Properties.Remove("LoginUsuario");
                App.Current.Properties.Remove("Contraseña");
                App.Current.MainPage = new NavigationPage(new Login());
                await App.Current.SavePropertiesAsync();
            }
        }
    }
}