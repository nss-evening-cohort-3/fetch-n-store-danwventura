using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FetchNStore.Models;

namespace FetchNStore.DAL
{
    public class ResponseRepository
    {
        public ResponseContext Context {get;set;}

        public ResponseRepository()
        {
            Context = new ResponseContext();
        }


        public ResponseRepository(ResponseContext _context)
        {
            Context = _context;
        }

        public List<Response> GetAllResponses()
        {
            List<Response> all_responses = Context.Responses.ToList();
            return all_responses;
        }

        public void AddNewResponse(Response response)
        {
            Context.Responses.Add(response);
            Context.SaveChanges();
        }
    }
}