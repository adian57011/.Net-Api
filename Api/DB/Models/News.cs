using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Api.DB.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        
        [ForeignKey("Catagory")]
        public int CatId { get; set; }

        [JsonIgnore]
        public virtual Catagory Catagory { get; set; }
    }
}