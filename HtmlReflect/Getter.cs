using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MovHubDb.Model;

namespace HtmlReflect
{

    interface Getter

    {

        string ParseToHtml(object obj);
        string ParseToHtmlArrayHeader();
        string ParseToHtmlArrayEntry(object obj);
    }

    class GetterIgnore : Getter
    {
        public string ParseToHtml(object obj)
        {
            return "";
        }

        public string ParseToHtmlArrayHeader()
        {
            return "";
        }

        public string ParseToHtmlArrayEntry(object obj)
        {
            return"";
        }
    }

    class NormalGetter : Getter
    {
        private PropertyInfo p ;
        private string singleObjPredicate = "\t<li class='list-group-item'><strong>";

        public NormalGetter(PropertyInfo p)
        {
            this.p = p;
        }

        public string ParseToHtml(object obj)
        {
            return singleObjPredicate + p.Name.Replace("_", String.Empty) + "</strong>:&nbsp" + p.GetValue(obj) + "</li>\n";
        }

        public string ParseToHtmlArrayHeader()
        {
            return "<th>" + p.Name.Replace("_", String.Empty) + "</th>";
        }

        public string ParseToHtmlArrayEntry(object obj)
        {
            return "<td>" + p.GetValue(obj) + "</td>";
        }
    }
    
    class GetterAs :Getter
    {
        private PropertyInfo p;

        public GetterAs(PropertyInfo p)
        {
            this.p = p;
        }

        public string ParseToHtml(object obj)
        {
            var c = p.GetCustomAttribute<HtmlAsAttribute>();
            return c.Val.Replace("{name}", p.Name.Replace("_", String.Empty)).Replace("{value}", p.GetValue(obj)?.ToString()) + "\n";
        }

        public string ParseToHtmlArrayHeader()
        {
            return "<th>" + p.Name.Replace("_", String.Empty) + "</th>";
        }

        public string ParseToHtmlArrayEntry(object obj)
        {
           var c = p.GetCustomAttribute<HtmlAsAttribute>();
            return c.Val
                .Replace("{name}", p.Name.Replace("_", String.Empty))
                .Replace("{value}", p.GetValue(obj)?.ToString()); 
        }
    }
}
