using FetchNStore.DAL;
using FetchNStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FetchNStore.Controllers
{
    public class ResponseController : ApiController
    {
        ResponseRepository repo = new ResponseRepository();
        // GET api/<controller>
        public List<Response> Get()
        {
            
            List<Response> all_responses = repo.GetAllResponses();

            return all_responses;

            //foreach (var each_response in all_responses)
            //{
            //    Response this_response = each_response;
            //}


            
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]Response response)
        {
            repo.AddNewResponse(response);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}