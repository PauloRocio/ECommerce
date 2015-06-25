using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Minutrade.ECommerce.BusinessObjects;
using Minutrade.ECommerce.Dto;
using System.Net;

namespace Minutrade.ECommerce.WebApi.Areas.Phone.Controllers
{
    public class PhonesController : ApiController
    {
        /// <summary>
        /// Método responsável por retornar uma lista de telefones
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PhoneDto> GetPhones()
        {
            return new PhoneBo().GetPhones();
        }

        /// <summary>
        /// Método responsável por selecionar um telefone específico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof (PhoneDto))]
        public IHttpActionResult GetPhone(long id)
        {
            var phone = new PhoneBo().GetPhone(id);

            if (phone == null)
                return NotFound();
        
            return Ok(phone);
        }

        /// <summary>
        /// Action responsavel por atualizar os dados do telefone do cliente.
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        /// <param name="phone">Número do telefone</param>
        /// <returns></returns>
        public IHttpActionResult PutClient(long id, PhoneDto phone)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != phone.Id)
                return BadRequest();

            new PhoneBo().PutPhone(id, phone);

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Action responsavel por criar os dados do telefone do cliente.
        /// </summary>
        /// <param name="phone">Número do telefone</param>
        /// <returns></returns>
        public IHttpActionResult PostClient(PhoneDto phone)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            new PhoneBo().PostPhone(phone);

            return CreatedAtRoute("DefaultApi", new { id = phone.Id }, phone);
        }

        /// <summary>
        /// Action responsavel por apagar os dados do telefone do cliente.
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        /// <returns></returns>
        public IHttpActionResult DeletePhone(long id)
        {
            var phone = new PhoneBo().DeletePhone(id);

            return Ok(phone);
        }

    }
}