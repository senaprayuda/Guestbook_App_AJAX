using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSI_M6_P1_18.Models
{
    public class ResponseModel
    {
        public int status { get; set; } 
        public String messages { get; set; } 
        public List<Object> data { get; set;}
    }
}