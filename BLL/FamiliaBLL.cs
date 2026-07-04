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
    public class FamiliaBLL : AbstractBLL<IFamilia>
    {
        public FamiliaBLL()
        {
            _crud = new FamiliaDAL();
        }

        public IList<IFamilia> ListarPorUsuario(int idUsuario)
        {
            return ((FamiliaDAL)_crud).ListarPorUsuario(idUsuario);
        }

        public void AsignarFamiliaAUsuario(EEUsuario usuario, IFamilia familia)
        {
            if (usuario == null || familia == null)
                return;

            Familia familiaConcreta = familia as Familia;
            if (familiaConcreta == null || familiaConcreta.ID <= 0)
                return;

            ((FamiliaDAL)_crud).AsignarFamiliaAUsuario(usuario.ID, familiaConcreta.ID);
        }

        public void QuitarFamiliaAUsuario(EEUsuario usuario, IFamilia familia)
        {
            if (usuario == null || familia == null)
                return;

            Familia familiaConcreta = familia as Familia;
            if (familiaConcreta == null || familiaConcreta.ID <= 0)
                return;

            ((FamiliaDAL)_crud).QuitarFamiliaAUsuario(usuario.ID, familiaConcreta.ID);
        }

        // Se deja el método para no romper referencias viejas, pero la carga inicial ahora está en SQL.
        public void SimularDatos()
        {
        }
    }
}
