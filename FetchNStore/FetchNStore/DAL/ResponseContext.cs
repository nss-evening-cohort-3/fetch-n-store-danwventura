using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FetchNStore.DAL
{
    public class ResponseContext : DbContext
    {

        public virtual DbSet<Responses> {get; set;}

    }
}