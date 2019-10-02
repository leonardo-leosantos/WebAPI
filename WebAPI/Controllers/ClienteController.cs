using System;
using System.Linq;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ClienteController : ApiController
    {
        private static Cliente[] Clientes = new Cliente[]
        {
                    new Cliente { ID = 01, nome = "Leonardo Luis Santana", email = "leonardoluis@teste.com.br", ativo = true },
                    new Cliente { ID = 02, nome = "Bianca Fidelis", email = "biafidelis@teste.com.br", ativo = true },
                    new Cliente { ID = 03, nome = "Davy dos Santos", email = "davysantos@teste.com", ativo = false },
                    new Cliente { ID = 04, nome = "Joao Silva", email = "jsilva@teste.com", ativo = false },
                    new Cliente { ID = 05, nome = "Victor Luan", email = "victor@luan.com", ativo = true   },
        };

        // GET: api/Cliente
        public Cliente[] Get()
        {
            return Clientes;
        }

        // GET: api/Cliente/5
        public Cliente Get(int id)
        {
            var clientes = Clientes;
            return clientes.SingleOrDefault(x => x.ID == id);
        }
        
        // POST: api/Cliente
        public void Post([FromBody]Cliente cliente)
        {            
            int indice = Clientes.Length;                   
            cliente.ID = indice + 1;                      
            Array.Resize(ref Clientes, indice+ 1);
            Clientes[indice] = cliente;
        }
        
        // PUT: api/Cliente/5
        public void Put([FromBody]Cliente clienteAlterado)
        {
            Cliente cliente = Clientes.SingleOrDefault(x => x.ID == clienteAlterado.ID);
            cliente.email = clienteAlterado.email;
            cliente.nome = clienteAlterado.nome;
        }
        
        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
            Cliente[] clientesTmp = new Cliente[Clientes.Length - 1];
            int qtdcliente = 0;

            foreach (Cliente cliente in Clientes) 
            { qtdcliente++;

                if (cliente.ID == id)
                {
                    Clientes[qtdcliente - 1] = null;
                    qtdcliente--;
                }
                else
                {
                    clientesTmp[qtdcliente - 1] = cliente;
                }              
            }

            Array.Resize(ref Clientes, clientesTmp.Length);

            for (var i = 0; i < clientesTmp.Length; i++)
            {
                Clientes[i] = clientesTmp[i];
            }             
        }       
    }
}
