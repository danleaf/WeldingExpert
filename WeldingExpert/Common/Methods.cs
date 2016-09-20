using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeldingExpert.Common
{
    public static class Methods
    {
        public static string GetMainMenuItemName<TModel>(this HtmlHelper<TModel> html, string moduleName)
        {
            return "show_" + moduleName + "menu";
        }

        public static string GetSubMenuName<TModel>(this HtmlHelper<TModel> html, string moduleName)
        {
            return moduleName + "menu";
        }

        public static void PlaceMainMenuItem<TModel>(this HtmlHelper<TModel> html, string moduleName, string text)
        {
            HttpContext.Current.Response.Write("<li id='show_"+ moduleName + "_menu'>" + text + "</li>");
        }

        public class DoPlaceSubMenu : IDisposable
        {
            public DoPlaceSubMenu(string moduleName, string Text)
            {
                HttpContext.Current.Response.Write("<li id='" + moduleName + "_menu'>" + Text + "</li>");
            }

            public void Dispose()
            {
                HttpContext.Current.Response.Write("</li>");
            }
        }

        public static DoPlaceSubMenu PlaceSubMenu<TModel>(this HtmlHelper<TModel> html, string moduleName, string text)
        {
            return new DoPlaceSubMenu(moduleName, text);
        }
    }
    
}