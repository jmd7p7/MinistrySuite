using System;

namespace MinistrySuite.Common
{
    public class HouseKeeping
    {
        public DateTimeOffset DateCreated { get; private set; }
        public DateTimeOffset DateLastModified { get; private set; }
        public bool IsActive { get; set; }

        public HouseKeeping()
        {
            DateCreated = DateLastModified = DateTimeOffset.Now;
            IsActive = true;
        }

        public void UpdateDateLastModified()
        {
            DateLastModified = DateTimeOffset.Now;
        }
    }
}
