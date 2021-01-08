using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea.Interfaces
{
    public interface IConfigDataBase
    {
       
        string GetFullPath(string databaseFileName);
      

            string GetDbPath();
        
    }
}
