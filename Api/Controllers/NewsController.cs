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
    public class NewsController : ApiController
    {
        [HttpPost]
        [Route("api/news")]
        public HttpResponseMessage Create(News n)
        {
            var db = new ApiContext();

            try
            {
                db.News.Add(n);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "News Created" });
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("api/news/all")]
        public HttpResponseMessage Get()
        {
            var db = new ApiContext();

            var data = db.News.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/news/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var db = new ApiContext();

            try
            {
                var data = db.News.Find(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/news/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var db = new ApiContext();
            var data = db.News.Find(id);
            try
            {
                db.News.Remove(data);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Deleted!" });

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPatch]
        [Route("api/news/update")]
        public HttpResponseMessage Update(News n)
        {
            var db = new ApiContext();
            var prev = db.News.Find(n.Id);
            db.Entry(prev).CurrentValues.SetValues(n);

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
        [HttpGet]
        [Route("api/news/catagory/{name}")]
        public HttpResponseMessage Get(string name)
        {
            var db = new ApiContext();
            try
            {
                var data = (from u in db.Catagories
                            where u.Name.Equals(name)
                            select u.News).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/news/date/{date}")]
        public HttpResponseMessage Get(DateTime date)
        {
            var db = new ApiContext();

            try
            {
                var data = (from u in db.News
                            where u.PublishDate.Equals(date)
                            select u.Title).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

                throw;
            }
        }
    }



}
