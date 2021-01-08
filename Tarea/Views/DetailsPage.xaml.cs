using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        private int personaId;
        public DetailsPage(int personaId)
        {
            InitializeComponent();
            this.personaId = personaId ;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = new PersonaDetailsViewModel(personaId );
        }
    }
}