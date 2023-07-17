using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ZDS_DOTS
{
    public readonly partial struct GameAspect : IAspect
    {
        private readonly RefRW<LocalTransform> spawnTransform;

        public readonly Entity zombie;
        private readonly RefRO<GameProperties> gameProperties;
        private readonly RefRW<SpawnPoints> spawnPoints;
        private readonly RefRW<SpawnTimer> spawnTimer;

        public uint numberOfEnemiesToSpawn => gameProperties.ValueRO.maxNumberOfEnemies;
        public uint currentNumberOfEnemies => gameProperties.ValueRO.currentNumberOfEnemies;
        public uint numberOfEnemiesToWin => gameProperties.ValueRO.numberOfEnemiesToWin;
        public Entity zombiePrefab => gameProperties.ValueRO.zombies;
        public Entity spawnPrefab => gameProperties.ValueRO.spawnPoint;

        public NativeArray<float3> SpawnPoints
        {
            get => spawnPoints.ValueRO.value;
            set => spawnPoints.ValueRW.value = value;
        }

        public LocalTransform GetSpawnPointTransform(float3 position)
        {
            return new LocalTransform
            {
                Position = position,
                Rotation = new quaternion(0, -90, 0, 0),
                Scale = 1f
            };
        }

        private float3 MinCorner => spawnTransform.ValueRO.Position - HalfDimensions;
        private float3 MaxCorner => spawnTransform.ValueRO.Position + HalfDimensions;
        private float3 HalfDimensions => new()
        {
            x = gameProperties.ValueRO.spawnArea.x * 0.5f,
            y = 0f,
            z = gameProperties.ValueRO.spawnArea.y * 0.5f
        };

        public float ZombieSpawnTimer
        {
            get => spawnTimer.ValueRO.value;
            set => spawnTimer.ValueRW.value = value;
        }

        public bool TimeToSpawnZombie => ZombieSpawnTimer <= 0f;

        public float ZombieSpawnRate => gameProperties.ValueRO.spawnTimer;

        public Entity ZombiePrefab => gameProperties.ValueRO.zombies;

        public float2 SpawnArea => gameProperties.ValueRO.spawnArea;

        //public LocalTransform GetZombieSpawnPoint()
        //{
        //    return new LocalTransform
        //    {
        //        Position = ,
        //        Rotation = ,
        //        Scale =
        //    };
        //}
    }
}

