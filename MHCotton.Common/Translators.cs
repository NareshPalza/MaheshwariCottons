using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MHCotton.Common
{
    public class Translators
    {
        public static T MapModelPOCOObjects<T>(object source)
        {
            Type des = typeof(T);
            Type src = source.GetType();
            T destination = Activator.CreateInstance<T>();
            Hashtable desProps = new Hashtable();
            foreach(PropertyInfo srcProp in src.GetProperties())
            {
                foreach(PropertyInfo desProp in des.GetProperties())
                {
                    if (desProp.Name.ToLower().Equals(srcProp.Name.ToLower()))
                    {
                        desProp.SetValue(destination, srcProp.GetValue(source));
                    }
                }
            }
            return destination;
        }
    }
}
