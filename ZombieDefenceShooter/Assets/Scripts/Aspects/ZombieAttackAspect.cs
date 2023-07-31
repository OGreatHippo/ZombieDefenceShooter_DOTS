using Unity.Entities;

namespace ZDS_DOTS
{
    public readonly partial struct ZombieAttackAspect : IAspect
    {
        public readonly Entity entity;

        private readonly RefRO<ZombieAttackProperties> properties;
        private readonly RefRW<ZombieTimer> timer;

        private uint Damage => properties.ValueRO.damage;
        private uint AttackSpeed => properties.ValueRO.attackSpeed;

        public float ZombieTimer
        {
            get => timer.ValueRO.value;
            set => timer.ValueRW.value = value;
        }

        public void Attack(float deltaTime, EntityCommandBuffer.ParallelWriter ecb, int sortKey, Entity barricadeEntity)
        {
            ZombieTimer -= deltaTime;

            var barricadeDamage = new BarricadeDamageBufferElement { value = Damage };

            if(ZombieTimer <= 0)
            {
                ZombieTimer = AttackSpeed;

                ecb.AppendToBuffer(sortKey, barricadeEntity, barricadeDamage);
            } 
        }
    }
}
