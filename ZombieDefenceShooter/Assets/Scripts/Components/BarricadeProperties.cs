using Unity.Entities;
using Unity.Mathematics;

namespace ZDS_DOTS
{
    public struct BarricadeProperties : IComponentData
    {
        public uint currentHealth;
        public uint maxHealth;
        public float3 transform;
    }

    public struct BarricadeTag : IComponentData
    {

    }
}
