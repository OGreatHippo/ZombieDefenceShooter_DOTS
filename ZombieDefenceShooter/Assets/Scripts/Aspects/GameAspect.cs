using System.Numerics;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ZDS_DOTS
{
    public readonly partial struct GameAspect : IAspect
    {
        public readonly Entity entity;

        private readonly RefRO<GameProperties> properties;
        private readonly RefRW<SpawnPoints> spawnPoints;
        private readonly RefRW<SpawnTimer> spawnTimer;

        public float2 SpawnDimensions => properties.ValueRO.spawnDimensions;
        public Entity SpawnPointPrefab => properties.ValueRO.spawnPointPrefab;

        public bool SpawnPointInitialised()
        {
            return spawnPoints.ValueRO.value.IsCreated && SpawnPointCount > 0;
        }

        public int SpawnPointCount => (int)properties.ValueRO.spawnDimensions.x / (int)properties.ValueRO.spawnDimensions.y;

        public LocalTransform GetTransform(float3 pos)
        {
            return new LocalTransform
            {
                Position = pos,
                Rotation = new quaternion(0, -90f, 0, 0),
                Scale = 1f
            };
        }

        private float3 GetSpawnPoint(int i) => spawnPoints.ValueRO.value.Value.value[i];

        public float SpawnTimer
        {
            get => spawnTimer.ValueRO.value;
            set => spawnTimer.ValueRW.value = value;
        }

        public bool TimeToSpawn => SpawnTimer <= 0f;

        public float SpawnRate => properties.ValueRO.spawnRate;

        public Entity ZombiePrefab => properties.ValueRO.zombiePrefab;
    }
}
