using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7._1.Users.BLL.Interface
{
    public class CacheLogic : ICacheLogic
    {
        private static Dictionary<string, object> _date;
        public bool Add<T>(string key, T value)
        {
            if (_date.ContainsKey(key))
            {
                return false;
            }

            _date.Add(key, value);

            return true;
        }
        public T Get<T>(string key)
        {
            if (!_date.ContainsKey(key))
            {
                return default(T);
            }

            return (T)_date[key];
        }
        public bool Delete(string key)
        {
            return _date.Remove(key);
        }
    }
}
