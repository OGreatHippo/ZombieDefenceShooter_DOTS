using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace ZDS_DOTS
{
    public struct GameProperties : IComponentData
    {
        public float2 spawnArea;
        public uint maxNumberOfEnemies;
        public uint currentNumberOfEnemies;
        public uint numberOfEnemiesToWin;
        public Entity zombies;
        public float spawnTimer;
        public Entity spawnPoint;
    }

    public struct SpawnTimer : IComponentData
    {
        public float value;
    }

    public struct SpawnPoints : IComponentData
    {
        public NativeArray<float3> value;
    }
}

