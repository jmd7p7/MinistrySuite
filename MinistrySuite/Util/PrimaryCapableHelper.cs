using System.Collections.Generic;
using System.Linq;
using MinistrySuite.Common;

namespace MinistrySuite.Util
{
    public static class PrimaryCapableHelper
    {
        public static T GetPrimary<T>(this ICollection<T> primaryCapableEntities) where T : PrimaryCapableEntity
        {
            return primaryCapableEntities.Where(e => e.IsPrimary == true).FirstOrDefault();
        }

        public static bool ValidatePrimaryCapableEntity<T>(this ICollection<T> primaryCapableEntities) where T : PrimaryCapableEntity
        {
            //A collection of valid primary capable entities is valid if it contains zero entities
            //or if it contains n entities and exactly one of them is set to 'IsPrimary'
            return primaryCapableEntities.Where(e => e.IsPrimary == true).Count() == 1 || 
                   primaryCapableEntities.Count() == 0;
        }
    }
}
