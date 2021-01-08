using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Tarea.DataContext;
using Tarea.Models;
using Tarea.Services;
using Xamarin.Forms;

namespace Tarea.ViewModels
{
    class EditPersonaViewModel:BaseViewModel
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre= value;
                OnPropertyChanged();
            }
        }


        private int monto;
        public int Monto
        {
            get { return monto; }
            set
            {
                monto= value;
                OnPropertyChanged();
            }
        }
        private DateTime fecha_matricula;
        public DateTime Fecha_matricula
        {
            get { return fecha_matricula; }
            set
            {
                fecha_matricula= value;
                OnPropertyChanged();
            }
        }
        private bool nuevo;
        public bool Nuevo
        {
            get { return this.nuevo; }
            set {
                nuevo = value;
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
        #region Constructor
        public EditPersonaViewModel()
        {
            this.dataServicePersonas = new DBDataAccess<Persona>();

        }



        #endregion Constructor
        #region Services

        private DBDataAccess<Persona> dataServicePersonas = new DBDataAccess<Persona>();

        #endregion Services
        public ICommand btnUpdatePersona { get; private set; }


        public int  _personaId;

       
        public EditPersonaViewModel(int personaId)
        {
            _personaId = personaId;
            var persona = this.dataServicePersonas.Encontrar(_personaId);
            Nombre = persona.Nombre;
            Monto = persona.Monto;
            Fecha_matricula = persona.Fecha_matricula;
            Estado = persona.Estado;
            Nuevo = persona.Nuevo;

            btnUpdatePersona = new Command(UpdateTeam);
        }
            
        async void UpdateTeam()
        {

            var persona = this.dataServicePersonas.Encontrar(_personaId);

            if (this.Nuevo)
            {
                persona.Estado = "SI";
                Estado = persona.Estado;
            }
            else
            {

                persona.Estado = "NO";
                Estado = persona.Estado; 
            }
            persona.Nombre = Nombre;
            persona.Monto = Monto;
            persona.Fecha_matricula = Fecha_matricula;
            persona.Nuevo = Nuevo;


            this.dataServicePersonas.Update(persona);

            await Application.Current.MainPage.DisplayAlert("Operación Exitosa",

                                                                             "Matricula actualizada",
                                                                             "Ok");
            

            await Application.Current.MainPage.Navigation.PopAsync();

        }


    }
}
