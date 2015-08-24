using API_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_1.Controllers
{
    public class FigureController : ApiController
    {
        public IEnumerable<Figure> GetAll()
        {
            return FigureManager.Figures;
        }

        public Figure GetByQueryString(string firstName)
        {
            var result = FigureManager.Figures.FirstOrDefault(t => t.FirstName == firstName);
            return result;
        }

        [Route("api/Figure/GetByRoute/{firstName}")]
        public Figure GetByRoute(string firstName)
        {
            var result = FigureManager.Figures.FirstOrDefault(t => t.FirstName == firstName);
            return result;
        }

        public IEnumerable<Figure> PutByUrl(string firstName, string lastName)
        {
            //Catelyn Tully
            FigureManager.Figures.Add(new Figure(firstName, lastName));
            return FigureManager.Figures;
        }

        public IEnumerable<Figure> PutByUrlModel(Figure figure)
        {
            //Catelyn Tully
            if (figure != null)
            {
                FigureManager.Figures.Add(figure);
            }
            return FigureManager.Figures;
        }

        [Route("api/Figure/PutByRouteModel/{FirstName}/{LastName}")]
        public IEnumerable<Figure> PutByRouteModel(Figure figure)
        {
            //Catelyn Tully
            if (figure != null)
            {
                FigureManager.Figures.Add(figure);
            }
            return FigureManager.Figures;
        }

        public IEnumerable<Figure> PostByBody([FromBody] Figure figure)
        {
            string body = Request.Content.ReadAsStringAsync().Result;
            if (figure != null)
            {
                FigureManager.Figures.Add(figure);
            }
            return FigureManager.Figures;
        }

        public IEnumerable<Figure> Delete(string firstName)
        {
            var result = FigureManager.Figures.FirstOrDefault(t => t.FirstName == firstName);
            if (result != null)
            {
                FigureManager.Figures.Remove(result);
            }
            return FigureManager.Figures;
        }
    }
}
