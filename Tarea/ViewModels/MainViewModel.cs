using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using Tarea.Models;
using Tarea.Services;

namespace Tarea.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        #region Attributes
        private ObservableCollection<MenuItemViewModel> menu;
        #endregion Attributes

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu
        {
            get { return this.menu; }
            set { SetValue(ref this.menu, value); }
        }
        #endregion Properties

        #region Constructor
        public MainViewModel()
        {
            this.LoadMenu();
        }
        #endregion Constructor

        #region Methods 
        private void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuItemViewModel>();

            this.Menu.Clear();
            this.Menu.Add(new MenuItemViewModel { Id = 1, Option = "Crear Matricula" });
            this.Menu.Add(new MenuItemViewModel { Id = 2, Option = "Lista de Matriculas" });
        }
        #endregion Methods
        DBDataAccess<Persona> dataService = new DBDataAccess<Persona>();
      
    }
}
