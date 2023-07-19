using Unity.Entities;
using Unity.Mathematics;

namespace ZDS_DOTS
{
    public struct GameRandom : IComponentData
    {
        public Random random;
    }
}
