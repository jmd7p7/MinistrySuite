using MinistrySuite.Common;
using System.Collections.Generic;

namespace MinistrySuite.Entities
{
    public class Ministry : EntityRoot
    {
        private string _Name;
        private string _Description;

        public virtual Church Church { get; private set; }
        public int ChurchId { get; private set; }
        public HouseKeeping HouseKeeping { get; set; }
        private ICollection<ChurchMember> _ChurchMembers;
        private ICollection<PrayerRequest> _PrayerRequests;

        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public virtual ICollection<PrayerRequest> PrayerRequests
        {
            get { return _PrayerRequests; }
            set
            {
                _PrayerRequests = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }


        public virtual ICollection<ChurchMember> ChurchMembers
        {
            get { return _ChurchMembers; }
            set
            {
                _ChurchMembers = value;
                HouseKeeping.UpdateDateLastModified();
            }
        }

        public Ministry()
        {
            HouseKeeping = new HouseKeeping();
            ChurchMembers = new HashSet<ChurchMember>();
            PrayerRequests = new HashSet<PrayerRequest>();
        }

        //Static create method for mocking the DB with entity framework
        public static Ministry Create(int churchId, string name, string description)
        {
            Ministry newMinistry = new Ministry();

            newMinistry.ChurchId = churchId;
            newMinistry.Name = name;
            newMinistry.Description = description;
            newMinistry.PrayerRequests = new List<PrayerRequest>();

            return newMinistry;
        }
    }
}
