using Epam.Task._7._1.Users.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7._1.Users.BLL.Interface
{
    public class CacheLogic : ICacheLogic
    {
        private static Dictionary<string, object> _date = new Dictionary<string, object>();
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
            if (_date == null)
            {
                return default(T);
            }
            else if(!_date.ContainsKey(key))
            {
                return default(T);
            }

            return (T)_date[key];
        }
        public bool Delete(string key)
        {
            if (_date != null)
            {
                return _date.Remove(key);
            }
            return false;
        }
    }
}
