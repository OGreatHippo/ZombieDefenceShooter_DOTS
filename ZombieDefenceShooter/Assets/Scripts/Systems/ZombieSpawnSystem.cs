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

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            //state.Enabled = false;

            //var gameEntity = SystemAPI.GetSingletonEntity<GameProperties>();
            //var game = SystemAPI.GetAspect<GameAspect>(gameEntity);

            //var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);

            //for (uint i = 0; i < game.numberOfEnemiesToSpawn; i++)
            //{
            //    var newEnemy = ecb.Instantiate(game.zombiePrefab);
            //    var newEnemyTransform = game.GetRandomSpawnLocation();

            //    ecb.SetComponent(newEnemy, newEnemyTransform);
            //}

            //ecb.Playback(state.EntityManager);

            float deltaTime = SystemAPI.Time.DeltaTime;
            var ecbSingleton = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();

            new SpawnZombieJob
            {
                deltaTime = deltaTime,
                ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged)

            }.Run();
        }
    }

    [BurstCompile]
    public partial struct SpawnZombieJob : IJobEntity
    {
        public float deltaTime;
        public EntityCommandBuffer ecb;

        [BurstCompile]
        private void Execute(GameAspect game)
        {
            game.ZombieSpawnTimer -= deltaTime;

            if(!game.TimeToSpawnZombie)
            {
                return;
            }

            game.ZombieSpawnTimer = game.ZombieSpawnRate;

            var newEnemy = ecb.Instantiate(game.ZombiePrefab);
        }
    }
}