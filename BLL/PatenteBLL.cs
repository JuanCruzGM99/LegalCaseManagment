using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Interfaces;
using Services.Composite;
using DAL;

namespace BLL
{
    public class PatenteBLL : AbstractBLL<IPatente>
    {
        public PatenteBLL()
        {
            _crud = new PatenteDAL();
        }

        // Se deja el método para no romper referencias viejas, pero la carga inicial ahora está en SQL.
        public void SimularDatos()
        {
        }
    }
}
