using System;
using System.Collections.Generic;
using System.Text;
using Tarea.Models;
using Tarea.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Tarea.DataContext;
using System.ComponentModel;

namespace Tarea.ViewModels
{
    public class PersonasViewModel : BaseViewModel
    {
        #region Services
        private readonly DBDataAccess<Persona> dataServicePersonas;
        #endregion Services

        #region Attributes
        private ObservableCollection<Persona> personas;
        public Persona persona;
        private string nombre;
        private DateTime fecha_matricula;
        private Boolean nuevo;
        private int monto;
        private string estado;
        #endregion Attributes

        #region Properties
        public ObservableCollection<Persona> Personas
        {
            get { return this.personas; }
            set { SetValue(ref this.personas, value); }
        }

        public Persona SelectedPersona
        {
            get { return this.persona; }
            set { SetValue(ref this.persona, value); }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }

        }
        public DateTime Fecha_matricula
        {
            get { return this.fecha_matricula; }
            
           
            set { SetValue(ref this.fecha_matricula, value); }
            
        }
        public bool Nuevo
        {
            get {  return this.nuevo; }
            set { SetValue(ref this.nuevo, value); }

        }
        public String Estado
        {
            get { return this.estado; }
            set { SetValue(ref this.estado, value); }
        }

        public int Monto
        {
            get { return this.monto; }
            set { SetValue(ref this.monto, value); }

        }

        #endregion Properties

        #region Constructor
        public PersonasViewModel()
        {
            this.dataServicePersonas = new DBDataAccess<Persona>();
            this.LoadPersonas();
            this.Fecha_matricula = DateTime.Now;

        }



        #endregion Constructor

        #region Commands
        public  ICommand btnSavePersona
        {

            get
            {
                return new Command(async () =>
                {
                    if (this.Nuevo)
                    {
                        this.Estado = "SI";
                        Estado = this.Estado;
                    }
                    else
                    {
                       
                        this.Estado = "NO";
                        Estado = this.Estado;

                    }

                    var newPersona = new Persona()
                    {
                        Estado = this.Estado,
                        Nombre = this.Nombre,
                        Nuevo = this.Nuevo,
                        Monto=this.Monto,
                       
                        Fecha_matricula=this.Fecha_matricula.Date
                            
                    };
                    if (newPersona != null)
                    {
                        if (this.dataServicePersonas.Create(newPersona))
                        {
                            await Application.Current.MainPage.DisplayAlert("Operación Exitosa",
                                                                           
                                                                                "Matricula creada correctamente en la base de datos",
                                                                                "Ok");
                            this.Nombre = string.Empty;
                            this.Nuevo = true;
                            this.Monto = 0;
                            this.Fecha_matricula= DateTime.Now;


                        }
                        else
                            await Application.Current.MainPage.DisplayAlert("Operación Fallida",
                                                                                $"Error al crear la  Persona en la base de datos",
                                                                                "Ok");
                    }

                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Validación",
                                                                                  $"Nombre de persona repetida",
                                                                                  "Ok");
                    }

                    await Application.Current.MainPage.Navigation.PopAsync();

                }

                );

            }

        }


        public ICommand UpdatePersonaCommand { get; private set; }

        #endregion Commands

        #region Methods


     
            private void LoadPersonas()
        {
            var personasDB = this.dataServicePersonas.Get().ToList() as List<Persona>;
            this.Personas = new ObservableCollection<Persona>(personasDB);

        }
   
        #endregion


    }
}