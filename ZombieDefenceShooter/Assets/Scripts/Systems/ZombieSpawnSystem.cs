using Unity.Burst;
using Unity.Entities;

namespace ZDS_DOTS
{
    [BurstCompile]
    public partial struct ZombieSpawnSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<GameProperties>();
        }

    //    [BurstCompile]
    //    public void OnUpdate(ref SystemState state)
    //    {
    //        float deltaTime = SystemAPI.Time.DeltaTime;
    //        var ecbSingleton = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();

    //        new SpawnZombieJob
    //        {
    //            deltaTime = deltaTime,
    //            ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged)

    //        }.Run();
    //    }
    //}

    //[BurstCompile]
    //public partial struct SpawnZombieJob : IJobEntity
    //{
    //    public float deltaTime;
    //    public EntityCommandBuffer ecb;

    //    [BurstCompile]
    //    private void Execute(GameAspect game)
    //    {
    //        game.ZombieSpawnTimer -= deltaTime;

    //        if(!game.TimeToSpawnZombie)
    //        {
    //            return;
    //        }

    //        game.ZombieSpawnTimer = game.ZombieSpawnRate;

    //        var newEnemy = ecb.Instantiate(game.ZombiePrefab);
    //    }
    }
}