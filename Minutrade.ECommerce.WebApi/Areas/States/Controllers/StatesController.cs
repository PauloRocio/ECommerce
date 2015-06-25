using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Minutrade.ECommerce.Dto;
using Minutrade.ECommerce.BusinessObjects;

namespace Minutrade.ECommerce.WebApi.Areas.States.Controllers
{
    public class StatesController : ApiController
    {
        /// <summary>
        /// Método responsável por retornar uma lista de estados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StateDto> GetStates()
        {
            return new StatesBo().GetStates();
        }

        /// <summary>
        /// Método responsável por seleciona um estado específico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(StateDto))]
        public IHttpActionResult GetState(long id)
        {
            var state = new StatesBo().GetState(id);
            
            if (state == null)
            {
                return NotFound();
            }

            return Ok(state);
        }
    }
}