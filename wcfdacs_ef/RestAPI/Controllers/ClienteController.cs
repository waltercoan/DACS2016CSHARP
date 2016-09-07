
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    public class ClienteController : ApiController
    {
        public Cliente Get(int id)
        {
            Cliente c = new Cliente() {
                id=10, 
                nome="Zezinho", 
                idade=20
            };
            return c;
        }

        public ICollection<Cliente> Get()
        {
            ICollection<Cliente> colClientes = new List<Cliente>();

            colClientes.Add(new Cliente()
            {
                id = 10,
                nome = "Zezinho",
                idade = 20
            });

            colClientes.Add(new Cliente()
            {
                id = 20,
                nome = "Luizinho",
                idade = 200
            });

            return colClientes;
        }

        public void Post([FromBody]Cliente cliente)
        {
            Console.WriteLine("POST");
            Console.WriteLine(cliente.id);
            Console.WriteLine(cliente.nome);
            Console.WriteLine(cliente.idade);
        }
        public void Put([FromBody]Cliente cliente)
        {
            Console.WriteLine("POST");
            Console.WriteLine(cliente.id);
            Console.WriteLine(cliente.nome);
            Console.WriteLine(cliente.idade);
        }

        public HttpResponseMessage Delete(long id)
        {
            Console.WriteLine("Delete: " + id);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

    }
}


