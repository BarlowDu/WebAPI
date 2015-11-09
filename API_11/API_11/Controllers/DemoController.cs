using API_11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace API_11.Controllers
{
    public class DemoController : ApiController
    {
        public Figure PostFigureFromUrl([ModelBinder]Figure figure)
        {
            return figure;
        }

        public Figure PostFigureFromBody([FromBody]Figure figure)
        {
            return figure;
        }

        public ModelStateDictionary PostFigureFromUrlForState([ModelBinder]Figure figure)
        {
            return ModelState;
        }

        public ModelStateDictionary PostFigureFromBodyForState([FromBody]Figure figure)
        {
            return ModelState;
        }
    }
}
