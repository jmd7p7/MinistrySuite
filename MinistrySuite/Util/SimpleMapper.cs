using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MinistrySuite.Util
{
    //This class was written by Miguel Castro for his Plurarlsight tutorial
    //Building Multi-Client End to End SOA - Angular Edition
    //https://app.pluralsight.com/library/courses/building-multi-client-end-to-end-soa-angular/table-of-contents
    public static class SimpleMapper
    {
        public static void PropertyMap<T, U>(T source, U destination)
            where T : class, new()
            where U : class, new()
        {
            List<PropertyInfo> sourceProperties = source.GetType().GetProperties().ToList<PropertyInfo>();
            List<PropertyInfo> destinationProperties = destination.GetType().GetProperties().ToList<PropertyInfo>();

            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                PropertyInfo destinationProperty = destinationProperties.Find(item => item.Name == sourceProperty.Name);

                if (destinationProperty != null)
                {
                    try
                    {
                        destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);
                    }
                    catch (ArgumentException)
                    {
                    }
                }
            }
        }
    }
}
