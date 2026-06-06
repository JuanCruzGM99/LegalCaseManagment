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


        public void SimularDatos()
        {
            var p = new Patente();
            p.Nombre = "Puede gestionar usuarios";
            p.Tipo = TipoPermiso.GestorUsuario;
            _crud.Save(p);

            p = new Patente();
            p.Nombre = "Puede gestionar permisos";
            p.Tipo = TipoPermiso.GestorPermiso;
            _crud.Save(p);

        }


    }
}
