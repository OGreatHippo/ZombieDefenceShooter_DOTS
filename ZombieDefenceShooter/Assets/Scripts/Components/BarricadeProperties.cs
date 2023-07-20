using Unity.Entities;
using Unity.Mathematics;

namespace ZDS_DOTS
{
    public struct BarricadeProperties : IComponentData
    {
        public uint health;
        public float3 transform;
    }
}
