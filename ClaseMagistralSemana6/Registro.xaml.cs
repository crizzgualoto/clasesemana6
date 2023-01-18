using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClaseMagistralSemana6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try { 
            WebClient client = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("codigo", txtId.Text);
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
            client.UploadValues("http://192.168.22.6/Servicios/estudiante.php", "POST", parametros);
                DisplayAlert("MENSAJE", "Se registro Ok " + txtNombre.Text+ " " + txtApellido.Text, "Cerrar");
            }
            catch(Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "Cerrar");
            }
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}