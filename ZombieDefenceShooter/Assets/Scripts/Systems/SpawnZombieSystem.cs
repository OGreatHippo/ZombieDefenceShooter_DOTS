using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;

namespace ZDS_DOTS
{
    [BurstCompile]
    public partial struct SpawnZombieSystem : ISystem
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

            new SpawnJob
            {
                deltaTime = deltaTime,
                ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged)
            }.Run();
        }
    }

    [BurstCompile]
    public partial struct SpawnJob : IJobEntity
    {
        public float deltaTime;
        public EntityCommandBuffer ecb;
        private void Execute(GameAspect game)
        {
            game.SpawnTimer -= deltaTime;

            if(!game.TimeToSpawn)
            {
                return;
            }

            game.SpawnTimer = game.SpawnRate;

            var newZombie = ecb.Instantiate(game.ZombiePrefab);
        }
    }
}
