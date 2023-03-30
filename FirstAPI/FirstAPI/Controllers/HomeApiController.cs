using FirstAPI.CRUD;
using FirstAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace FirstAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class HomeApiController : ApiController
    {
        PlantsDAL plantDAL = new PlantsDAL();

        [ResponseType(typeof(IEnumerable<DetailsViewModel>))]
        public IHttpActionResult Get()
        {
            var details = plantDAL.GetAllDetails();
            return Ok(details);
        }

        [ResponseType(typeof(IEnumerable<DetailsByIdViewModel>))]
        public IHttpActionResult GetId(int id)
        {
            var details = plantDAL.GetDetailsById(id);
            if (details == null)
            {
                return NotFound();
            }
            return Ok(details);
        }

        [ResponseType(typeof(IEnumerable<CreateViewModel>))]
        public IHttpActionResult Post(CreateViewModel mgData)
        {
            if (ModelState.IsValid)
            {
                var createDetail = plantDAL.CreateDetails(mgData);
                return CreatedAtRoute("DefaultApi", new { id = createDetail.Id }, createDetail);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [ResponseType(typeof(IEnumerable<UpdateViewModel>))]
        public IHttpActionResult Put(UpdateViewModel mgData, int id)
        {
            //id ye ait kayıt yok ise
            if (plantDAL.IsThereAnyDetails(id) == false)
            {
                return NotFound();
            }
            //details model doğrulanmadıysa
            else if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(plantDAL.UpdateDetails(mgData, id));
            }
        }
        public IHttpActionResult Delete(int id)
        {
            if (plantDAL.IsThereAnyDetails(id) == false)
            {
                return NotFound();
            }
            else
            {
                plantDAL.DeleteDetails(id);
                return Ok();
            }
        }
    }
}
