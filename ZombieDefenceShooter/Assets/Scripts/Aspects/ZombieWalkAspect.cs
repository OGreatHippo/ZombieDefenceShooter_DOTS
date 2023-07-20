using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ZDS_DOTS
{
    public readonly partial struct ZombieWalkAspect : IAspect
    {
        public readonly Entity entity;
        private readonly RefRO<ZombieProperties> properties;
        private readonly RefRW<LocalTransform> localTransform;

        public void Move(float deltaTime)
        {
            localTransform.ValueRW.Position += math.left() * properties.ValueRO.walkSpeed * deltaTime;
        }

        public bool InStoppingRange(float3 barricadePos, float distance)
        {
            return math.distance(barricadePos.x, localTransform.ValueRO.Position.x) <= distance;
        }
    }
}
