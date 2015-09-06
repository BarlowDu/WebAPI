using API_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace API_4.Controllers
{
    [RoutePrefix("api/Figure")]
    public class FigureController : ApiController
    {
        #region url
        public Figure GetFigureFromQueryString(Figure figure)
        {
            return figure;
        }

        public Figure GetFigureFromQueryStringNotAll(Figure figure)
        {
            return figure;
        }


        [Route("GetFigureFromRoute/{FirstName}/{LastName}")]
        public Figure GetFigureFromRoute(Figure figure)
        {
            return figure;
        }

        [Route("GetFigureFromRouteAndQueryString/{FirstName}/{LastName}")]
        public Figure GetFigureFromRouteAndQueryString(Figure figure)
        {
            return figure;
        }

        [Route("GetTwoFigureFromRoute/{a.FirstName}/{a.LastName}/{b.FirstName}/{b.LastName}")]
        public List<Figure> GetTwoFigureFromRoute(Figure a, Figure b)
        {
            List<Figure> result = new List<Figure>();
            result.Add(a);
            result.Add(b);
            return result;
        }

        //[Route("GetTwoFigureFromRoute/{a.FirstName}/{a.LastName}/{b.FirstName}/{b.LastName}")]
        public List<Figure> GetTwoFigureFromQueryString(Figure a, Figure b)
        {
            List<Figure> result = new List<Figure>();
            result.Add(a);
            result.Add(b);
            return result;
        }

        public Figure GetComplexFigureFromQueryString(Figure figure)
        {
            return figure;

        }

        [Route("GetFigureFromRouteAndQueryString/{FirstName}/{LastName}/{Direwolf.Name}/{Direwolf.Color}")]
        public Figure GetComplexFigureFromRoute(Figure figure)
        {
            return figure;

        }

        public List<Figure> GetTwoComplexFigureFromQueryString(Figure a, Figure b)
        {
            List<Figure> result = new List<Figure>();
            result.Add(a);
            result.Add(b);
            return result;

        }

        [Route("GetTwoComplexFigureFromRoute/{a.FirstName}/{a.LastName}/{a.Direwolf.Name}/{a.Direwolf.Color}/{b.FirstName}/{b.LastName}/{b.Direwolf.Name}/{b.Direwolf.Color}")]
        public List<Figure> GetTwoComplexFigureFromRoute(Figure a, Figure b)
        {
            List<Figure> result = new List<Figure>();
            result.Add(a);
            result.Add(b);
            return result;
        }

        public  List<int> GetList([ModelBinder] List<int> list)
        {
            return list;
        }

        public List<Figure> GetFigureList([ModelBinder] List<Figure> list)
        {
            return list;
        }

        public List<Figure> GetTwoFigureList([ModelBinder] List<Figure> list1, [ModelBinder] List<Figure> list2)
        {
            List<Figure> list = new List<Figure>();
            list.AddRange(list1);
            list.AddRange(list2);
            return list;
        }

        #endregion


    }
}
