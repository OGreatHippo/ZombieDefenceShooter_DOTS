using Unity.Entities;

namespace ZDS_DOTS
{
    public readonly partial struct ZombieAspect : IAspect
    {
        public readonly Entity entity;

        private readonly RefRO<ZombieProperties> properties;

        public void DamageZombie()
        {

        }
    }
}
