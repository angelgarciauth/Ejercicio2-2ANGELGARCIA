
using Ejercicio2_2ANGELGARCIA.Controller;
using Ejercicio2_2ANGELGARCIA.Models;
using Ejercicio2_2ANGELGARCIA.Views;
using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio2_2ANGELGARCIA
{
    public partial class MainPage : ContentPage
    {
        Byte[] resultBase;
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnLista_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListFirmas());
        }

        private async void btnSqlite_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                await DisplayAlert("Error", "Por favor, ingrese el nombre", "OK");
                return;
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                await DisplayAlert("Error", "Por favor, ingrese una descripcion", "OK");
                return;
            }

            if (firmaDigital.IsBlank)
            {
                await DisplayAlert("Error", "Por favor, ingrese una firma digital", "OK");
                return;
            }


              var imageFirma = await firmaDigital.GetImageStreamAsync(SignatureImageFormat.Png);
              var mStream = (MemoryStream)imageFirma;
              Byte[] data = mStream.ToArray();

         


            var firma = new Firma()
            {
                id = 0,
                nombre = txtNombre.Text,
                descripcion = txtDescripcion.Text,
                firm = data
            };

                var folderPath = "/storage/emulated/0/Android/data/com.companyname.ejercicio2_2angelgarcia/files/Pictures";
                var nameFirma = "";

                if (await new servicio().saveFirma(firma))
                {
                    try
                    {
                        if (!Directory.Exists(folderPath))
                            Directory.CreateDirectory(folderPath);

                        nameFirma = txtNombre.Text + DateTime.Now.ToString("MMddyyyyhhmmss"); ;

                        File.WriteAllBytes(folderPath + "/" + nameFirma + ".png", firma.firm);

                        Msg("Firma guardada \nPath:" + folderPath + "/" + nameFirma+ ".png");
                    txtNombre.Text = "";
                    txtDescripcion.Text = "";
                    }
                    catch
                    {
                        Msg("Firma guardada");
                    }



                    
                }
                else Msg("Error no se guardo la firma");
            }
            
        

        public async void Msg(string msg)
        {
            await DisplayAlert("Notificacion", msg, "OK");
        }

        
    }
}
