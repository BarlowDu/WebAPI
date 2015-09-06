using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_4.Models
{
    public static class FigureManager
    {
        static List<Figure> figures;
        static FigureManager()
        {
            figures = new List<Figure>();
            figures.Add(new Figure("Eddard", "Stack"));
            figures.Add(new Figure("Robb", "Stack"));
            figures.Add(new Figure("Sansa", "Stack"));
            figures.Add(new Figure("Arya", "Stack"));
            figures.Add(new Figure("Bran", "Stack"));
            figures.Add(new Figure("Rickon", "Stack"));
            figures.Add(new Figure("Jon", "Snow"));
        }
        public static List<Figure> Figures
        {
            get { return figures; }
        }
    }
}