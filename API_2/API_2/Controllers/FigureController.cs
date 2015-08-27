using API_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_2.Controllers
{
    public class FigureController : ApiController
    {
        #region　Http方法匹配
        public IEnumerable<Figure> GetAll()
        {
            return FigureManager.Figures;
        }

        public IEnumerable<Figure> GetPostAll()//只能用GET方法请求
        {
            return FigureManager.Figures;
        }

        [HttpPost]
        public IEnumerable<Figure> Get()//不能用GET方法请求,只能用Post方法请求
        {
            return FigureManager.Figures;
        }

        [AcceptVerbs("POST")]
        [HttpPut]
        public IEnumerable<Figure> PostByBody([FromBody] Figure figure)//可以用Put,Post方法请求
        {
            string body = Request.Content.ReadAsStringAsync().Result;
            if (figure != null)
            {
                FigureManager.Figures.Add(figure);
            }
            return FigureManager.Figures;
        }
        #endregion

        #region Action名匹配
        public Figure GetFigure(string firstName)
        {
            var result = FigureManager.Figures.FirstOrDefault(t => t.FirstName == firstName);
            return result;
        }
        #endregion

        #region 所有参数无默认值
        public Figure GetFromQueryString(string firstName)
        {
            var result = FigureManager.Figures.FirstOrDefault(t => t.FirstName == firstName);
            return result;
        }
        public Figure GetFromQueryString(string firstName, string lastName)
        {
            var result = FigureManager.Figures.FirstOrDefault(t => t.FirstName == firstName && t.LastName == lastName);
            return result;
        }

        public Figure GetFromQueryStringDefaultValue([FromUri] Figure figure)
        {
            var result = FigureManager.Figures.FirstOrDefault(t => t.FirstName == figure.FirstName && t.LastName == figure.LastName);
            return result;
        }

        #endregion

        #region 存在默认只参数
        public IEnumerable<Figure> GetFromQueryStringDefaultValue(string lastName = "Stack")
        {
            var result = FigureManager.Figures.Where(t => t.LastName == lastName);
            return result;
        }
        public Figure GetFromQueryStringDefaultValue(string firstName, string lastName = "Stack")
        {
            var result = FigureManager.Figures.FirstOrDefault(t => t.FirstName == firstName && t.LastName == lastName);
            return result;
        }

        //public Figure GetFromQueryStringDefaultValue(string firstName="Bran", string lastName = "Stack")
        //{
        //    var result = FigureManager.Figures.FirstOrDefault(t => t.FirstName == firstName && t.LastName == lastName);
        //    return result;
        //}

        public int GetFromQueryStringDefaultValue1(string x,string y,string z="z")
        {
            return 1;
        }
        public int GetFromQueryStringDefaultValue1(string x, string y)
        {
            return 2;
        }
        public int GetFromQueryStringDefaultValue1(string x)
        {
            return 3;
        }
        #endregion

        #region 参数类型
        public string GetFromQueryStringType(string x, string y)
        {
            return x + y;
        }
        public int GetFromQueryStringType(int x, int y)
        {
            return x + y;
        }

        //public void GetFromQueryStringType1(int x, string y)
        //{ }
        //public void GetFromQueryStringType1(string x, int y)
        //{ }
        #endregion



    }
}
