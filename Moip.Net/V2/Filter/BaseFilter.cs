using System.Linq;
using System;

namespace Moip.Net.V2.Filter
{
    public abstract class BaseFilter
    {
        private readonly string _name;
        private object[] _value;

        public BaseFilter(string name, object[] value)
        {
            _name = name;
            _value = value;
        }
        
        protected abstract string FilterName { get; }

        public override string ToString()
        {
            string[] arrValues = new string[_value.Length];

            for (int i = 0; i < arrValues.Length; i++)
            {
                if(_value[i] is DateTime)
                {
                    arrValues[i] = ((DateTime)_value[i]).ToString("yyyy-MM-dd");
                }
                else
                {
                    arrValues[i] = _value[i].ToString();
                }
            }

            return string.Format("{0}::{1}({2})", _name, FilterName, string.Join(",", arrValues));
        }
    }
}
