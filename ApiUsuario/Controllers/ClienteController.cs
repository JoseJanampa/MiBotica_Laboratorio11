using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;
using Clientes = MiBotica.SolPedido.Entidades.Core.Cliente;

namespace ApiUsuario.Controllers
{
    public class ClienteController : ApiController
    {
        // GET: api/Cliente
        public IEnumerable<Clientes> Get()
        {
            return new ClientesLN().ListaClientes();
        }

        // GET: api/Cliente/5
        public Cliente Get(int id)
        {
            return new ClientesLN().BuscarCliente(id);
        }

        // POST: api/Cliente
        public void Post([FromBody] Cliente value)
        {
            new ClientesLN().InsertarCliente(value);
        }

        // PUT: api/Cliente/5
        public void Put(int id, [FromBody] Cliente value)
        {
            value.Codigo = id;
            new ClientesLN().ModificarCliente(value);
        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
            new ClientesLN().EliminarCliente(id);
        }
    }
}