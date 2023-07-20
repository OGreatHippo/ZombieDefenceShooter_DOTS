using Unity.Entities;

namespace ZDS_DOTS
{
    public struct ZombieProperties : IComponentData, IEnableableComponent
    {
        public float walkSpeed;
    }
}
