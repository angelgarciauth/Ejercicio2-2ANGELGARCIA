using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_2ANGELGARCIA.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class ListFirmas : ContentPage
{
    public ListFirmas()
    {
        InitializeComponent();
            if (App.DBase == null)
            {

            }
        }

        private void listFirmas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (await App.DBase.getListFirma() != null)
            {
                listFirmas.ItemsSource = await App.DBase.getListFirma();
            }
            else
            {
                await DisplayAlert("Advertencia", "No hay firmas agregados", "Ok");
            }
        }
    }
}