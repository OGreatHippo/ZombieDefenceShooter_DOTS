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
        public uint spawnRate;
    }

    public struct SpawnTimer : IComponentData 
    {
        public float value;
    }
}
