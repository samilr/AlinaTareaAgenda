using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Contactos
    {
        private CD_Contactos objetoCD = new CD_Contactos();

        public DataTable MostrarCont() {

            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarCont (string name, string lastName, string address, string dateBirthday, string phoneNumber, string Movil, string Genero, string Correo, string Estadocivil)
        {

            objetoCD.Insertar(name,lastName,address,dateBirthday,phoneNumber, Movil,  Genero, Correo, Estadocivil);
    }

        public void EditarCont(string name, string lastName, string address, string dateBirthday, string phoneNumber, string id, string Movil, string Genero, string Correo, string Estadocivil)
        {
            objetoCD.Editar(name, lastName, address, dateBirthday, phoneNumber,Convert.ToInt32(id), Movil,  Genero,  Correo, Estadocivil);
        }

        public void EliminarCont(string id) {

            objetoCD.Eliminar(Convert.ToInt32(id));
        }

    }
}
