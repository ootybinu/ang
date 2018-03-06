using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace WaterAMR.Utility
{
    public static class DbUtility
    {
        public static string GetSPName(string provider, string SpName, string criteria)
        {
            if (provider == "npgsql")
                return string.Format("select * from {0} ({1})", SpName, criteria);
            else
                return string.Format("execute {0} {1}", SpName, criteria);
        }

        public static IEnumerable<T> GetOrderBy<T>(this IEnumerable<T> Source, string SortBy, bool asc)
        {
            var r = typeof(T).GetProperty(SortBy);
            var paramExpr = Expression.Parameter(typeof(T));
            var prop = Expression.PropertyOrField(paramExpr, r.Name);
            var expr = Expression.Lambda(prop, paramExpr);
            var method = asc ? typeof(Enumerable).GetMethods().FirstOrDefault(m => m.Name == "OrderBy" && m.GetParameters().Length == 2)
                              : typeof(Enumerable).GetMethods().FirstOrDefault(m => m.Name == "OrderByDescending" && m.GetParameters().Length == 2);

            var gm = method.MakeGenericMethod(typeof(T), r.PropertyType);
            return (IEnumerable<T>)gm.Invoke(null, new object[] { Source, expr.Compile() });
        }

    }

}
