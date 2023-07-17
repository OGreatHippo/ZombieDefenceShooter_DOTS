using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ZDS_DOTS
{
    public readonly partial struct GameAspect : IAspect
    {
        public readonly Entity zombie;
        //private readonly RefRW<LocalTransform> transform;
        private readonly RefRO<GameProperties> gameProperties;
        private readonly RefRW<RandomSpawn> randomSpawn;
        private readonly RefRW<SpawnTimer> spawnTimer;

        public uint numberOfEnemiesToSpawn => gameProperties.ValueRO.maxNumberOfEnemies;
        public uint currentNumberOfEnemies => gameProperties.ValueRO.currentNumberOfEnemies;
        public uint numberOfEnemiesToWin => gameProperties.ValueRO.numberOfEnemiesToWin;
        public Entity zombiePrefab => gameProperties.ValueRO.zombies;

        //public LocalTransform GetRandomSpawnLocation()
        //{
        //    return new LocalTransform
        //    {
        //        Position = GetRandomPosition(),
        //        Rotation = quaternion.identity,
        //        Scale = 1f
        //    };
        //}

        //private float3 GetRandomPosition()
        //{
        //    float3 randomPos;

        //    randomPos = randomSpawn.ValueRW.random.NextFloat3(minCorner, maxCorner);

        //    return randomPos;
        //}

        //private float3 minCorner => transform.ValueRO.Position - HalfDimensions;
        //private float3 maxCorner => transform.ValueRO.Position + HalfDimensions;
        //private float3 HalfDimensions => new()
        //{
        //    x = gameProperties.ValueRO.spawnArea.x * 0.5f,
        //    y = 0f,
        //    z = gameProperties.ValueRO.spawnArea.z * 0.5f
        //};

        public float ZombieSpawnTimer
        {
            get => spawnTimer.ValueRO.value;
            set => spawnTimer.ValueRW.value = value;
        }

        public bool TimeToSpawnZombie => ZombieSpawnTimer <= 0f;

        public float ZombieSpawnRate => gameProperties.ValueRO.spawnTimer;

        public Entity ZombiePrefab => gameProperties.ValueRO.zombies;
    }
}

