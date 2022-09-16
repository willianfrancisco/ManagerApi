using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Api.ViewModel
{
    public class ResultViewModel
    {
        public string Message { get; set; }
        public bool Succes { get; set; }
        public dynamic Data { get; set; }
    }
}
