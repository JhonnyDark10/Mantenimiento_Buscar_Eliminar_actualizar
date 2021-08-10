using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using Capa_Entidad;
using System.Data;

namespace Capa_Negocio
{
    public class ClassNegocio
    {

        ClassDatos objd = new ClassDatos();

        public DataTable N_listar_clientes() {

            return objd.D_listar_clientes();
        }

        public DataTable N_Buscar_clientes(ClassEntidad obje)
        {

            return objd.D_Buscar_clientes(obje);
        }

        public String N_Mantenimiento(ClassEntidad obje) {

            return objd.D_Mantenimiento_clientes(obje);
        }
    }
}
