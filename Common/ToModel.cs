using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace onlinebusinessApi.Common
{
    public static class ToModel
    {
        public static T DtToMel<T>(this DataRow dr)
        {
            //获取泛型真实类型
            Type t = typeof(T);
            //实例化t
            T md = (T)Activator.CreateInstance(t);
            //获取对象中属性
            var props = t.GetProperties();
            foreach(var prop in props)
            {
                if(dr.Table.Columns.Contains(prop.Name))
                {
                    prop.SetValue(md,dr[prop.Name]);
                }
            }
            return md;
        }
    }
}
