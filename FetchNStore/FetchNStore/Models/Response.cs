using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FetchNStore.Models
{
    public class Response
    {
        [Key]
        public int Response_ID { get; set; }
        [Required]
        public int Status_Code { get; set; }
        [Required]
        public string Method { get; set; }
        [Required]
        public string URL { get; set; }
        [Required]
        public string Response_Time { get; set; }
        [Required]
        public DateTime TimeOfDay { get; set; }
    }
}