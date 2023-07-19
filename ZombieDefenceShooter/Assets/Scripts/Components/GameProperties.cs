using Unity.Entities;
using Unity.Mathematics;

namespace ZDS_DOTS
{
    public struct GameProperties : IComponentData
    {
        public float2 spawnDimensions;
        public Entity spawnPointPrefab;
    }
}