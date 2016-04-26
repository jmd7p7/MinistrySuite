using MinistrySuite.Common;
using Common.Validation;
using System.Collections.Generic;
using System;
using MinistrySuite.SecondaryEntities;

namespace MinistrySuite.Entities
{
    public class PrayerRequest : EntityRoot
    {
        public Church Church { get; private set; }
        public int ChurchId { get; private set; }
        private string _Title;
        private string _Request;
        private bool _PermissionGranted;
        private DateTimeOffset _StartDate;
        private DateTimeOffset _EndDate;
        public HouseKeeping HouseKeeping { get; set; }
        private ICollection<Ministry> _Ministries;
        private ICollection<PrayerRequestUpdate> _Updates;

        public string Title
        {
            get { return _Title; }
            set
            {
                Guard.ForNull(value, "Title");
                Guard.ForOutSideMinOrMaxIntegerBounds(0, 100, value.Length, "Title");
                _Title = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public string Request
        {
            get { return _Request; }
            set
            {
                Guard.ForNull(value, "Request");
                Guard.ForOutSideMinOrMaxIntegerBounds(0, 500, value.Length, "Request");
                _Request = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        //In order to create or modify a prayer request, permission granted
        //MUST be set to true.
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

        public DateTimeOffset EndDate
        {
            get { return _EndDate; }
            set
            {
                Guard.ForOutSideMinOrMaxDateTimeOffSetBounds(DateTimeOffset.Now.AddYears(-1), DateTimeOffset.Now.AddYears(1), value, "EndDate");
                _EndDate = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public DateTimeOffset StartDate
        {
            get { return _StartDate; }
            set
            {
                Guard.ForOutSideMinOrMaxDateTimeOffSetBounds(DateTimeOffset.Now.AddYears(-1), DateTimeOffset.Now.AddYears(1), value, "StartDate");
                _StartDate = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public virtual ICollection<Ministry> Ministries
        {
            get { return _Ministries; }
            set
            {
                _Ministries = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public virtual ICollection<PrayerRequestUpdate> Updates
        {
            get { return _Updates; }
            set
            {
                _Updates = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public PrayerRequest()
        {
            HouseKeeping = new HouseKeeping();
            Updates = new HashSet<PrayerRequestUpdate>();
            Ministries = new HashSet<Ministry>();
        }

        //Static create method for mocking the DB with entity framework
        public static PrayerRequest Create(int churchId, string title, string request, 
            DateTimeOffset startDate, DateTimeOffset endDate, List<Ministry> ministries)
        {
            PrayerRequest newPrayerRequest = new PrayerRequest();
            newPrayerRequest.ChurchId = churchId;
            newPrayerRequest.Title = title;
            newPrayerRequest.Request = request;
            newPrayerRequest.StartDate = startDate;
            newPrayerRequest.EndDate = endDate;
            newPrayerRequest.Ministries = ministries;
            newPrayerRequest.PermissionGranted = true;

            return newPrayerRequest;
        }
    }
}
