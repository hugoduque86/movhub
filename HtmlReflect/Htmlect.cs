using System;
using System.Collections.Generic;
using System.Reflection;
using MovHubDb.Model;

namespace HtmlReflect
{
    public class Htmlect
    {
        

        private Dictionary<Type,List<Getter>> cache = new Dictionary<Type, List<Getter>>();

        public string ToHtml(object obj)
        {
            List<Getter> S= GetGetters(obj);
            string r = "<ul class='list-group'>\n";
            foreach (var getter in S)
            {
                r+=getter.ParseToHtml(obj);
            }
            return r+"</ul>";

            
        
        }

        private List<Getter> GetGetters(object obj)
        {
            List<Getter> S;
            if (cache.TryGetValue(obj.GetType(), out S)) return S;
            S=new List<Getter>();
            foreach (var property in obj.GetType().GetProperties())
            {
                if (property.GetCustomAttribute<HtmlIgnoreAttribute>() != null)
                {
                    S.Add(new GetterIgnore());
                    continue;
                }
                if (property.GetCustomAttribute<HtmlAsAttribute>() != null)
                {
                    S.Add(new GetterAs(property));
                    continue;
                }
                S.Add(new NormalGetter(property));
            }
            cache.Add(obj.GetType(),S);
            return S;
        }

        public string ToHtml(object[] arr)
        {
            List<Getter> S = GetGetters(arr[0]);

            //if (cache.ContainsKey(arr)) return cache[arr];
            string r = "<table class='table table-hover'>\n\t<thead>\n\t\t<tr>";
            foreach (var info in S)
            {
               
                r += info.ParseToHtmlArrayHeader();

            }
            r += "</tr>\n\t</thead>\n\t<tbody>\n";
            foreach (var o in arr)
            {
                r += "\t\t<tr>";
                foreach (var info in S)
                {
                    r+=info.ParseToHtmlArrayEntry(o);
                }
                r += "</tr>\n";
            }
            //cache.Add(arr, r + "\t</tbody>\n</table>");
            return r+"\t</tbody>\n</table>";
        }
    }
}
