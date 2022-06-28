using Insight.Database;
using System;
using System.Collections.Generic;

namespace ADN.DM
{
    public class DMGeneral<T>
    {
        public bool Add(string sp, T entity)
        {
            string response = DMInsight.DefaultCnn().ExecuteScalar<string>(sp, entity, commandTimeout: 3000);
            return response == "TRUE" ? true : false;
        }

        public T GetConsultar(string sp, object entity)
        {
            T response = DMInsight.DefaultCnn().ExecuteScalar<T>(sp, entity, commandTimeout: 3000);
            return response;
        }

        public List<T> GetListSQL(string sp, Object entity)
        {
            List<T> response = DMInsight.DefaultCnn().Query<T>(sp, entity, commandTimeout: 3000) as List<T>;
            return response;
        }
    }
}
