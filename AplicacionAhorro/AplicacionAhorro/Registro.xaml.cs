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
    public partial class Registro : ContentPage
    {
        private List<string> lista=new List<string>();
        
        
        public Registro()
        {
            InitializeComponent();
            lista.Add("Masculino");
            lista.Add("Femenino");
            pSexo.ItemsSource = lista;
            btnRegistrar.Clicked += BtnRegistrar_Clicked;
            
        }

        private void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            Guardar();
        }

        private async void Guardar()
        {
            Clases.Usuario u;
            string res;
            if (txtContraseña.Text == null || txtContraseña.Text.Length < 10)
            {
                await DisplayAlert("Error", "Contraseña al menos de 10 caracteres", "Ok");
                return;
            }
            if (txtContraseña.Text != txtConfirmar.Text)
            {
                await DisplayAlert("Error", "Deben coincidir las contraseñas", "Ok");
                return;
            }
            u = new Clases.Usuario();
            u.Id = int.Parse(txtId.Text.Trim());
            u.LoginUsuario = txtUsuario.Text.Trim();
            u.Contraseña = txtContraseña.Text.Trim();
            u.NombreCompleto = txtNombre.Text.ToUpper().Trim();
            u.Sexo = pSexo.SelectedItem.ToString();
            if (txtUltimoAhorrado.Text == null || txtUltimoAhorrado.Text == string.Empty)
            {
                u.UltimoAhorrado = 0;
            }
            else
            {
                u.UltimoAhorrado = Convert.ToDecimal(txtUltimoAhorrado.Text.Trim());
            }
            u.Correo = txtCorreo.Text.ToUpper().Trim();
            res = await Clases.Servicio.RegistrarUsuario(u);
            if (res.StartsWith("Error"))
            {
                await DisplayAlert("Error", res, "Ok");
            }
            else
            {
                await DisplayAlert("Atención", "Se registro el Usuario Satisfactoriamente", "Ok");
                await Navigation.PopAsync();
            }
        }
    }
}