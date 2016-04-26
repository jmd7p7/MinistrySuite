using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinistrySuite.Web.HtmlHelpers
{
    public static class MyHtmlHelpers
    {
        public static IHtmlString DrillDownHandCreator(this HtmlHelper htmlHelper, int numPrependedSpaces, string href)
        {
            string htmlString = $"<a class='NoUnderlineOnHover' href='" + href + 
                $"'><span class='glyphicon glyphicon-hand-up' aria-hidden='true'></a>";
            for (int i = 0; i < numPrependedSpaces; i++)
            {
                htmlString = "&nbsp;" + htmlString;
            }
            return new HtmlString(htmlString); 
        }

        //IsActive() code by Kyle Mitofsky
        //http://www.codingeverything.com/2014/05/mvcbootstrapactivenavbar.html
        public static string IsActive(this HtmlHelper htmlHelper, string controller, string action)
        {
            var routeData = htmlHelper.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["Action"];
            var routeContoller = (string)routeData.Values["Controller"];

            var returnActive = routeAction == action && routeContoller == controller;

            return returnActive ? "active" : "";
        }
    }
}