using MinistrySuite.Entities;

namespace MinistrySuite.SecondaryEntities
{
    public class ChurchPhoneNumber : PhoneNumber
    {
        public int ChurchId { get; private set; }
        public Church Church { get; private set; }
    }
}
