using Unity.Entities;

namespace ZDS_DOTS
{
    public readonly partial struct ZombieAttackAspect : IAspect
    {
        private readonly RefRO<ZombieProperties> properties;
    }
}
