using Unity.Entities;

namespace ZDS_DOTS
{
    public struct ZombieProperties : IComponentData
    {
        public uint health;
    }

    public struct ZombieWalkProperties : IComponentData, IEnableableComponent
    {
        public float walkSpeed;
    }

    public struct ZombieAttackProperties : IComponentData, IEnableableComponent
    {
        public uint damage;
        public uint attackSpeed;
    }

    public struct ZombieTimer : IComponentData
    {
        public float value;
    }
}
