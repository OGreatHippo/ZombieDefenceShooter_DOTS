using Unity.Burst;
using Unity.Entities;

namespace ZDS_DOTS
{
    [BurstCompile]
    public partial struct ZombieSystem : ISystem
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

            new WalkJob
            {
                deltaTime = deltaTime 
            }.ScheduleParallel();
        }
    }

    [BurstCompile]
    public partial struct WalkJob : IJobEntity
    {
        public float deltaTime;

        [BurstCompile]
        private void Execute(ZombieWalkAspect zombie)
        {
            zombie.Move(deltaTime);

            //if(zombie.InStoppingRange())
        }
    }
}
