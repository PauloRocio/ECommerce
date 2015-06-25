using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Minutrade.ECommerce.BusinessObjects;
using Minutrade.ECommerce.Dto;

namespace Minutrade.ECommerce.WebApi.Areas.Clients.Controllers
{
    public class ClientsController : ApiController
    {
        /// <summary>
        /// Método responsável por retornar todos clientes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ClientDto> GetClients()
        {
            return new ClientsBo().GetClients();
        }

        /// <summary>
        /// Método responsável por retornar um cliente específico
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        /// <returns></returns>
        [ResponseType(typeof(ClientDto))]
        public IHttpActionResult GetClient(long id)
        {
            var client = new ClientsBo().GetClient(id);

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        /// <summary>
        /// Método responsável por editar os dados do usuário
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        /// <param name="client">Atributo da camada de regra de negócios</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(long id, ClientDto client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != client.Id)
                return BadRequest();

            new ClientsBo().PutClient(id, client);

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Método responsável por Adicionar um cliente
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [ResponseType(typeof(ClientDto))]
        public IHttpActionResult PostClient(ClientDto client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            new ClientsBo().PostClient(client);

            return CreatedAtRoute("DefaultApi", new { id = client.Id }, client);
        }

        /// <summary>
        /// Método responsável por Deletar um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(ClientDto))]
        public IHttpActionResult DeleteClient(long id)
        {
            ClientDto client = new ClientsBo().DeleteClient(id);

            return Ok(client);
        }
    }
}