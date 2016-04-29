using MinistrySuite.Common;
using MinistrySuite.Util;
using MinistrySuite.Entities;
using System;

namespace MinistrySuite.SecondaryEntities
{
    public class PrayerRequestUpdate
    {
        public int Id { get; private set; }
        public PrayerRequest PrayerRequest { get; private set; }
        public int PrayerRequestId { get; private set; }
        private string _UpdateInformation;
        private bool _PermissionGranted;
        public HouseKeeping HouseKeeping { get; set; }
        public bool PermissionGranted
        {
            get { return _PermissionGranted; }
            set
            {
                if (value == false)
                {
                    throw new ArgumentException("Permission Granted must be set to true.");
                }
                _PermissionGranted = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public string UpdateInformation
        {
            get { return _UpdateInformation; }
            set
            {
                Guard.ForNullOrEmptyOrWhiteSpace(value, "UpdateInformation");
                Guard.ForOutSideMinOrMaxIntegerBounds(0, 500, value.Length, "UpdateInformation");
                _UpdateInformation = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public PrayerRequestUpdate()
        {
            HouseKeeping = new HouseKeeping();
        }
    }
}
