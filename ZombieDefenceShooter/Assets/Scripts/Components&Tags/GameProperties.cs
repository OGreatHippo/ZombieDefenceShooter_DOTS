using Unity.Entities;
using Unity.Mathematics;

namespace ZDS_DOTS
{
    public struct GameProperties : IComponentData
    {
        public float3 spawnArea;
        public uint maxNumberOfEnemies;
        public uint currentNumberOfEnemies;
        public uint numberOfEnemiesToWin;
        public Entity zombies;
        public float spawnTimer;
    }

    public struct SpawnTimer : IComponentData
    {
        public float value;
    }
}

