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
    public partial class Login : ContentPage
    {
        public static Clases.Usuario usuario;
        public Login()
        {
            InitializeComponent();
            indicador.BindingContext = this;
            btnLogin.Clicked += BtnLogin_Clicked;
            btnRegistrar.Clicked += BtnRegistrar_Clicked;
            if (App.Current.Properties.ContainsKey("LoginUsuario"))
            {
                txtUsuario.Text = (string)App.Current.Properties["LoginUsuario"];
                txtContraseña.Text = (string)App.Current.Properties["Contraseña"];
                Loguear();
            }
        }

        private void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            Loguear();
        }
        private async void Loguear()
        {
            IsBusy = true;
            usuario = await Clases.Servicio.Loguear(txtUsuario.Text, txtContraseña.Text);
            IsBusy = false;
            if (usuario.Id == 0)
            {
                await DisplayAlert("Incorrecto", "Datos incorrectos", "Ok");
                return;
            }
            if (sRecordar.IsToggled == true)
            {
                App.Current.Properties["LoginUsuario"] = txtUsuario.Text;
                App.Current.Properties["Contraseña"] = txtContraseña.Text;
                await App.Current.SavePropertiesAsync();
            }
            App.Current.MainPage = new NavigationPage(new Menu());
        }
    }
}