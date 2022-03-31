using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Contactos
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarContactos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string name, string lastName, string address, string dateBirthday, string phoneNumber, string Movil, string Correo, string Estadocivil, string Genero)
        {
            //PROCEDIMNIENTO

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsetarContactos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@name", name);
            comando.Parameters.AddWithValue("@lastName", lastName);
            comando.Parameters.AddWithValue("@address", address);
            comando.Parameters.AddWithValue("@dateBirthday", dateBirthday);
            comando.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            comando.Parameters.AddWithValue("@Movil", Movil);
            comando.Parameters.AddWithValue("@Correo", Correo);
            comando.Parameters.AddWithValue("@EstadoCivil", Estadocivil);
            comando.Parameters.AddWithValue("@Genero", Genero);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();

        }

        public void Editar(string name, string lastName, string address, string dateBirthday, string phoneNumber, int id, string Movil,  string Correo, string Estadocivil, string Genero)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarContactos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@name", name);
            comando.Parameters.AddWithValue("@lastName", lastName);
            comando.Parameters.AddWithValue("@address", address);
            comando.Parameters.AddWithValue("@dateBirthday", dateBirthday);
            comando.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            comando.Parameters.AddWithValue("@idCont", id);
            comando.Parameters.AddWithValue("@Movil", Movil);
            comando.Parameters.AddWithValue("@Correo", Correo);
            comando.Parameters.AddWithValue("@EstadoCivil", Estadocivil);
            comando.Parameters.AddWithValue("@Genero", Genero);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarContactos";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idCont", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

    }
}
