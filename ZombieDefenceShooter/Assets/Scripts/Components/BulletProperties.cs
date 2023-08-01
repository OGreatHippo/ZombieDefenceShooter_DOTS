using Unity.Entities;

namespace ZDS_DOTS
{
    public struct BulletProperties : IComponentData
    {
        public uint speed;
        public uint damage;
    }
}
