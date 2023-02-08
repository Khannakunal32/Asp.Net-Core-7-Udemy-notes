using System.Text.RegularExpressions;

namespace RoutingTwo.CustomConstraints
{

    /// <summary>
    /// to create customConstraint and include it  into the file like regex we use iRouteConstraint interface
    /// </summary>
    public class MyCustomConstraint : IRouteConstraint
    {
        ///below the httpcontext is used for request and response objects <summary>
        /// route gives the full route like /bractus/olorio/snickers roiute
        /// routekey is the routerkey like {chocolate}
        /// values give object of values taht our of keys
        /// routeDirection
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //throw new NotImplementedException();
            ///my code here
            // first check if the the route parameter value exist like if {chocolate} parameter is present and exist

            if (!values.ContainsKey(routeKey)) return false;

            Regex regex = new Regex("^(snickers|silk|toblerone|orio|mars|5star)$");

            string? chocolate = Convert.ToString(values[routeKey])!;

            if (regex.IsMatch(chocolate))
            {
                return true;
            }

            return false;

            // after this go to builder
        }
    }
}
