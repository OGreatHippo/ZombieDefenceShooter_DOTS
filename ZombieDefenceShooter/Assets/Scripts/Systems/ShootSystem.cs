using Unity.Burst;
using Unity.Entities;

namespace ZDS_DOTS
{
    [BurstCompile]
    public partial struct ShootSystem : ISystem
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
            var ecbSingleton = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();

            new ShootJob
            {
                deltaTime = deltaTime,
                ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged)
            }.Run();
        }
    }

    [BurstCompile]
    public partial struct ShootJob : IJobEntity
    {
        public float deltaTime;
        public EntityCommandBuffer ecb;

        [BurstCompile]
        private void Execute(PlayerAspect player)
        {
            player.Shoot(deltaTime, ecb);
        }
    }
}
