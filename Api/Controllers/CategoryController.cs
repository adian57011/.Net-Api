using Api.DB;
using Api.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("api/catagory/all")]
        public HttpResponseMessage Get()
        {
            var db = new ApiContext();

            var data = db.Catagories.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/catagory/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var db = new ApiContext();
            var data = db.Catagories.Find(id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/catagory/getbyname/{name}")]
        public HttpResponseMessage Get(string name)
        {
            var db = new ApiContext();
            try
            {
                var data = (from c in db.Catagories
                            where c.Name.Contains(name)
                            select c).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/catagory/create")]
        public HttpResponseMessage Create(Catagory c)
        {
            var db = new ApiContext();

            try
            {
                db.Catagories.Add(c);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Created" });
            }

            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/catagory/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var db = new ApiContext();
            var data = db.Catagories.Find(id);

            try
            {
                db.Catagories.Remove(data);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Catagory Deleted" });
            }

            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPatch]
        [Route("api/catagory/update")]
        public HttpResponseMessage Update(Catagory c)
        {
            var db = new ApiContext();
            var prev = db.Catagories.Find(c.Id);
            db.Entry(prev).CurrentValues.SetValues(c);

            try
            {
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

  
    }
}
