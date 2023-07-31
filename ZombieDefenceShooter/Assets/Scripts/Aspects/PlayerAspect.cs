using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ZDS_DOTS
{
    public readonly partial struct PlayerAspect : IAspect
    {
        public readonly Entity entity;

        private readonly RefRO<PlayerProperties> playerProperties;
        private readonly RefRO<LocalTransform> localTransform;
        private readonly RefRW<ShootTimer> shootTimer;

        public uint Damage => playerProperties.ValueRO.damage;
        private uint AttackSpeed => playerProperties.ValueRO.attackSpeed;

        public float ShootTimer
        {
            get => shootTimer.ValueRO.value;
            set => shootTimer.ValueRW.value = value;
        }

        public void Shoot(float deltaTime, EntityCommandBuffer ecb)
        {
            ShootTimer -= deltaTime;

            if(ShootTimer < 0)
            {
                ShootTimer = AttackSpeed;

                var newBullet = ecb.Instantiate(playerProperties.ValueRO.bullet);

                ecb.SetComponent(newBullet, SpawnPosition());
            }
        }

        public LocalTransform SpawnPosition()
        {
            return new LocalTransform
            {
                Position = localTransform.ValueRO.Position,
                Rotation = quaternion.identity,
                Scale = localTransform.ValueRO.Scale
            };
        }
    }
}
