using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea.Models;
using Tarea.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonasPage : ContentPage
    {
        public PersonasPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = new PersonasViewModel();
        }

        private async void OnPersonaTapped(object sender, ItemTappedEventArgs e)
        {

            if (e.Item != null)
            {
                var persona = (Persona)e.Item;
                await Navigation.PushAsync(new DetailsPage(persona.PersonaID));
            }
        }
    }
}