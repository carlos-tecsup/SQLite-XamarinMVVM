using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Tarea.Models;
using Tarea.DataContext;
using Tarea.Services;
using Tarea.Views;

namespace Tarea.ViewModels
{
    public class PersonaDetailsViewModel : BaseViewModel
    {
        #region Services
        private DBDataAccess<Persona> dataServicePersonas = new DBDataAccess<Persona>();
        #endregion Services

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged();
            }
        }


        private int monto;
        public int Monto
        {
            get { return monto; }
            set
            {
                monto = value;
                OnPropertyChanged();
            }
        }
        private DateTime fecha_matricula;
        public DateTime Fecha_matricula
        {
            get { return fecha_matricula; }
            set
            {
                fecha_matricula = value;
                OnPropertyChanged();
            }
        }

        private bool nuevo;
        public bool Nuevo
        {
            get { return nuevo; }
            set
            {

                OnPropertyChanged();
            }


        }

        private string estado;

        public string Estado
        {
            get { return estado; }
            set
            {
                estado = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Persona> personas;
        public ObservableCollection<Persona> Personas
        {
            get { return personas; }
            set { personas = value; }
        }

        public ICommand EditPersonaCommand { get; private set; }
        public ICommand DeletePersonaCommand { get; private set; }

        public PersonaDetailsViewModel()
        {
            this.dataServicePersonas = new DBDataAccess<Persona>();

        }

        private int _personaId;
        public PersonaDetailsViewModel(int personaId)
        {
            _personaId = personaId;

            var persona = this.dataServicePersonas.Encontrar(_personaId);
            Nombre = persona.Nombre;
            Monto = persona.Monto;
            Fecha_matricula = persona.Fecha_matricula;
            Estado = persona.Estado;
            Nuevo = persona.Nuevo;
            EditPersonaCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new EditPage(_personaId)));
          

                DeletePersonaCommand = new Command(DeleteTeam);
            }


            async void DeleteTeam()
            {
            var res = await App.Current.MainPage.DisplayAlert("Eliminar", "¿Estas seguro de eliminar este registro?", "Si", "No");

            if (res)
            {
                this.dataServicePersonas.Delete(_personaId);
                await Application.Current.MainPage.DisplayAlert("Operación Exitosa",

                                                                                 "Matricula Eliminada",
                                                                                 "Ok");
                Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}