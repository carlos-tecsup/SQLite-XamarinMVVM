using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Tarea.Models;
using Tarea.Services;
using Tarea.Views;
using Xamarin.Forms;

namespace Tarea.ViewModels
{


    public class MenuItemViewModel
    {
        #region Attributes
        public int Id { get; set; }
        public string Option { get; set; }
        public string Icon { get; set; }
        #endregion Attributes

        #region Commands
        public ICommand SelectMenuItemCommand
        {
            get
            {
                return new Command(SelectMenuItemExecute);
            }
        }
        #endregion Commands

        #region Methods
        private void SelectMenuItemExecute()
        {
            if (this.Id == 1)
                Application.Current.MainPage.Navigation.PushAsync(new AddPersonaPage());
            if (this.Id == 2)
                Application.Current.MainPage.Navigation.PushAsync(new PersonasPage());
            

        }
        DBDataAccess<Persona> dataService = new DBDataAccess<Persona>();
        
        #endregion Methods

    }
}

