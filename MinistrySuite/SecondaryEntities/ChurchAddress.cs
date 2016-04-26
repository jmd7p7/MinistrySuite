using MinistrySuite.Entities;

namespace MinistrySuite.SecondaryEntities
{
    public class ChurchAddress : Address
    {
        public virtual Church Church { get; private set; }
        public int ChurchId { get; private set; }
    }
}
