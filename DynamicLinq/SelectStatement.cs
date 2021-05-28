using System;
using System.Linq;
using System.Linq.Expressions;

namespace DynamicLinq
{
    public class SelectStatement<T> where T :class
    {

        public Func<T, T> SelectColumn(string fields)
        {
            var xParameter = Expression.Parameter(typeof(T), "o");


            var xNew = Expression.New(typeof(T));

            var bindings = fields.Split(',').Select(o => o.Trim())
                .Select(o =>
                {

                    var mi = typeof(T).GetProperty(o);

                    var xOriginal = Expression.Property(xParameter, mi);


                    return Expression.Bind(mi, xOriginal);
                }
            );

            // initialization "new Data { Field1 = o.Field1, Field2 = o.Field2 }"
            var xInit = Expression.MemberInit(xNew, bindings);

            // expression "o => new Data { Field1 = o.Field1, Field2 = o.Field2 }"
            var lambda = Expression.Lambda<Func<T, T>>(xInit, xParameter);

            // compile to Func<Data, Data>
            return lambda.Compile();
        }
    }
}