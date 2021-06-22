using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaApi.Controllers
{
    [Route("")]
    public class DeafultController : Controller
    {
        public String Index()
        {
            return "Running";
        }
    }
}
