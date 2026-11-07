using MiBotica.SolPedido.Entidades; 
using MiBotica.SolPedido.Entidades.Core;
using Newtonsoft.Json;              
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Web.Services.Description;
using Clientes = MiBotica.SolPedido.Entidades.Core.Cliente;

namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class ClienteController : Controller
    {
        //Sustituye al puerto donde corre tu ApiUsuario
        string RutaApi = "https://localhost:44368/api/";
        string jsonMediaType = "application/json";

        // GET: Cliente
        public ActionResult Index()
        {
            string metodo = "Cliente";
            List<Clientes> lista = new List<Clientes>();

            using (WebClient cliente = new WebClient())
            {
                cliente.Headers.Clear();
                cliente.Headers[HttpRequestHeader.ContentType] = jsonMediaType;
                cliente.Encoding = Encoding.UTF8;

                string rutacompleta = RutaApi + metodo;
                var data = cliente.DownloadString(new Uri(rutacompleta));
                lista = JsonConvert.DeserializeObject<List<Clientes>>(data);
            }

            return View(lista);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            Clientes cliente = new Clientes();
            return View(cliente);
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Clientes cliente)
        {
            try
            {
                string metodo = "Cliente";

                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = jsonMediaType;
                    client.Encoding = Encoding.UTF8;

                    string rutacompleta = RutaApi + metodo;

                    // Convertir el objeto cliente recibido del formulario a formato JSON
                    string data = JsonConvert.SerializeObject(cliente);

                    // Enviar la petición POST hacia la Web API 
                    client.UploadString(new Uri(rutacompleta), "POST", data);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(cliente);
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            string metodo = "Cliente";
            Clientes Entcli = new Clientes();

            using (WebClient cliente = new WebClient())
            {
                cliente.Headers.Clear();
                cliente.Headers[HttpRequestHeader.ContentType] = jsonMediaType;
                cliente.Encoding = Encoding.UTF8;

                string rutacompleta = RutaApi + metodo + "/" + id;

                var data = cliente.DownloadString(new Uri(rutacompleta));
                Entcli = JsonConvert.DeserializeObject<Clientes>(data);
            }

            return View(Entcli);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Clientes collection)
        {
            string metodo = "Cliente";
            try
            {
                using (WebClient cliente = new WebClient())
                {
                    cliente.Headers.Clear();
                    cliente.Headers[HttpRequestHeader.ContentType] = jsonMediaType;
                    cliente.Encoding = Encoding.UTF8;

                    var clienteJson = JsonConvert.SerializeObject(collection);

                    string rutacompleta = RutaApi + metodo + "/" + id;
                    var resultado = cliente.UploadString(new Uri(rutacompleta), "PUT", clienteJson);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var zz = ex.Message;
                return View();
            }
        }
        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            string metodo = "Cliente";
            Clientes Entcli = new Clientes();

            using (WebClient cliente = new WebClient())
            {
                cliente.Headers.Clear();
                cliente.Headers[HttpRequestHeader.ContentType] = jsonMediaType;
                cliente.Encoding = Encoding.UTF8;

                string rutacompleta = RutaApi + metodo + "/" + id;

                var data = cliente.DownloadString(new Uri(rutacompleta));
                Entcli = JsonConvert.DeserializeObject<Clientes>(data);
            }

            return View(Entcli);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            string metodo = "Cliente";
            try
            {
                using (WebClient cliente = new WebClient())
                {
                    cliente.Headers.Clear();
                    cliente.Headers[HttpRequestHeader.ContentType] = jsonMediaType;
                    cliente.Encoding = Encoding.UTF8;

                    string rutacompleta = RutaApi + metodo + "/" + id;
                    // Envia el verbo DELETE hacia la Web API
                    var resultado = cliente.UploadString(new Uri(rutacompleta), "DELETE", "");
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var zz = ex.Message;
                return View();
            }
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            string metodo = "Cliente";
            Clientes Entcli = new Clientes();

            using (WebClient cliente = new WebClient())
            {
                cliente.Headers.Clear();
                cliente.Encoding = Encoding.UTF8;

                string rutacompleta = RutaApi + metodo + "/" + id;

                var data = cliente.DownloadString(new Uri(rutacompleta));
                Entcli = JsonConvert.DeserializeObject<Clientes>(data);
            }

            return View(Entcli);
        }
    }
}