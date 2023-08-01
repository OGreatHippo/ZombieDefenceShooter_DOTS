using Unity.Burst;
using Unity.Entities;

namespace ZDS_DOTS
{
    [UpdateAfter(typeof(ShootSystem))]
    [BurstCompile]
    public partial struct BulletSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;

            new MoveBulletJob
            {
                deltaTime = deltaTime,
            }.ScheduleParallel();
        }
    }

    public partial struct MoveBulletJob : IJobEntity
    {
        public float deltaTime;

        [BurstCompile]
        private void Execute(BulletAspect bullet)
        {
            bullet.Move(deltaTime);
        }
    }
}
