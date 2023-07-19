using System.Numerics;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ZDS_DOTS
{
    public readonly partial struct GameAspect : IAspect
    {
        public readonly Entity entity;

        private readonly RefRO<GameProperties> properties;
        
        public float2 SpawnDimensions => properties.ValueRO.spawnDimensions;
        public Entity SpawnPointPrefab => properties.ValueRO.spawnPointPrefab;

        public LocalTransform GetTransform(float3 pos)
        {
            return new LocalTransform
            {
                Position = pos,
                Rotation = new quaternion(0, -90f, 0, 0),
                Scale = 1f
            };
        }
    }
}
