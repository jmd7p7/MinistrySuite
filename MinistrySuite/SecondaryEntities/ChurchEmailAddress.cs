using MinistrySuite.Entities;

namespace MinistrySuite.SecondaryEntities
{
    public class ChurchEmailAddress : EmailAddress
    {
        public int ChurchId { get; private set; }
        public virtual Church Church { get; private set; }
    }
}
