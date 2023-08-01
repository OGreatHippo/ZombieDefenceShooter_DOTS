using Unity.Entities;

namespace ZDS_DOTS
{
    public struct BulletProperties : IComponentData
    {
        public float speed;
        public uint damage;
    }
}
