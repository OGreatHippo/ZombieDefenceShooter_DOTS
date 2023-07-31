using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ZDS_DOTS
{
    public struct GameProperties : IComponentData
    {
        public float2 spawnDimensions;
        public float3 transform;
        public float2 gameObjPos;
        public Entity spawnPointPrefab;
        public Entity zombiePrefab;
        public float spawnRate;

        public uint maxSpawns;
        public uint currentSpawns;
        public uint remainingSpawns;
    }

    public struct SpawnTimer : IComponentData 
    {
        public float value;
    }
}
