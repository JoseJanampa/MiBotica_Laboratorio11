using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades.Base;
using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;
using Clientes = MiBotica.SolPedido.Entidades.Core.Cliente;

namespace MiBotica.SolPedido.LogicaNegocio.Core
{
    public class ClientesLN : BaseLN
    {
        public List<Clientes> ListaClientes()
        {
            try
            {
                return new ClientesDA().ListaClientes();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public Clientes BuscarCliente(int id)
        {
            try
            {
                return new ClientesDA().BuscarCliente(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public bool InsertarCliente(Clientes entidad)
        {
            try
            {
                return new ClientesDA().InsertarCliente(entidad);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public bool ModificarCliente(Clientes entidad)
        {
            try
            {
                return new ClientesDA().ModificarCliente(entidad);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public bool EliminarCliente(int id)
        {
            try
            {
                return new ClientesDA().EliminarCliente(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}