using Unity.Entities;
using Unity.Mathematics;

namespace ZDS_DOTS
{
    public struct PlayerProperties : IComponentData
    {
        public uint damage;
        public uint attackSpeed;
        public Entity bullet;
    }

    public struct ShootTimer : IComponentData
    {
        public float value;
    }
}
