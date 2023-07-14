using Unity.Entities;
using Unity.Mathematics;

namespace ZDS_DOTS
{
    public struct RandomSpawn : IComponentData
    {
        public Random random;
    }
}