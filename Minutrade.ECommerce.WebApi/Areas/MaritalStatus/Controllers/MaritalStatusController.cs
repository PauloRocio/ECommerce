using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Minutrade.ECommerce.Dto;
using Minutrade.ECommerce.BusinessObjects;

namespace Minutrade.ECommerce.WebApi.Areas.MaritalStatus.Controllers
{
    public class MaritalStatusController : ApiController
    {
        /// <summary>
        /// Método responsável por retornar uma lista de estado civil
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MaritalStatuDto> GetMaritalStatus()
        {
            return new MaritalStatusBo().GetMaritalStatus();
        }

        /// <summary>
        /// Método responsável por selecionar um tipo de estado civil
        /// </summary>
        /// <param name="id">Identificador do estado civil</param>
        /// <returns></returns>
        [ResponseType(typeof(MaritalStatuDto))]
        public IHttpActionResult GetMaritalStatu(long id)
        {
            var maritalStatu = new MaritalStatusBo().GetMaritalStatu(id);

            if (maritalStatu == null)
            {
                return NotFound();
            }

            return Ok(maritalStatu);
        }

        /// <summary>
        /// Método responsável por editar dados de estado civil
        /// </summary>
        /// <param name="id"></param>
        /// <param name="maritalStatu"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaritalStatu(long id, MaritalStatuDto maritalStatu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maritalStatu.Id)
            {
                return BadRequest();
            }

            new MaritalStatusBo().PutMarital(id, maritalStatu);

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Método responsável por adicionar um estado civil
        /// </summary>
        /// <param name="maritalStatu"></param>
        /// <returns></returns>
        [ResponseType(typeof(MaritalStatuDto))]
        public IHttpActionResult PostMaritalStatu(MaritalStatuDto maritalStatu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            new MaritalStatusBo().PostMaritalStatus(maritalStatu);
            
            return CreatedAtRoute("DefaultApi", new { id = maritalStatu.Id }, maritalStatu);
        }

        /// <summary>
        /// Método responsável por deletar um tipo de estado civil
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MaritalStatuDto))]
        public IHttpActionResult DeleteMaritalStatu(long id)
        {
            MaritalStatuDto marital = new MaritalStatusBo().DeleteMarital(id);
            return Ok(marital);
        }
    }
}