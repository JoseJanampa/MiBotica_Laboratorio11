using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Clientes = MiBotica.SolPedido.Entidades.Core.Cliente;

namespace MiBotica.SolPedido.AccesoDatos.Core
{
    public class ClientesDA
    {
        public Clientes LlenarEntidad(IDataReader reader)
        {
            Clientes cliente = new Clientes();

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Codigo'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Codigo"]))
                    cliente.Codigo = Convert.ToInt32(reader["Codigo"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='NombreCompleto'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["NombreCompleto"]))
                    cliente.NombreCompleto = Convert.ToString(reader["NombreCompleto"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Zona'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Zona"]))
                    cliente.Zona = Convert.ToString(reader["Zona"]);
            }

            return cliente;
        }

        public List<Clientes> ListaClientes()
        {
            List<Clientes> listaEntidad = new List<Clientes>();
            Clientes entidad = null;

            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("ListarClientes", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);
                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return listaEntidad;
        }

        public Clientes BuscarCliente(int id)
        {
            Clientes entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("BuscarClientes", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Codigo", id);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);
                    }
                }
            }
            return entidad;
        }

        public bool InsertarCliente(Clientes entidad)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("InsertarClientes", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@NombreCompleto", entidad.NombreCompleto ?? "");
                    comando.Parameters.AddWithValue("@Zona", entidad.Zona ?? "");
                    conexion.Open();
                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ModificarCliente(Clientes entidad)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("ModificarClientes", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Codigo", entidad.Codigo);
                    comando.Parameters.AddWithValue("@NombreCompleto", entidad.NombreCompleto ?? "");
                    comando.Parameters.AddWithValue("@Zona", entidad.Zona ?? "");
                    conexion.Open();
                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool EliminarCliente(int id)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("BorraClientes", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Codigo", id);
                    conexion.Open();
                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}