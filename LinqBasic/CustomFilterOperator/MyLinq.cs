using System;
using System.Collections.Generic;
using System.Text;

namespace FilteringOperator
{
    public static class MyLinq
    {
        // 1.Read only ( chỉ đọc)
        // 2.Forward only ( chỉ chạy tiến ko quay đầu )
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            
            foreach (var item in source)
            {
                if (predicate(item))
                {
                  yield  return item;
                }
            }
          
        }
    }
}
