using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.DB.Models
{
    public class Catagory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<News> News { get; set; }

        public Catagory()
        {
            News = new List<News>();
        }
    }
}