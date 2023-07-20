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
        private readonly RefRO<BarricadeProperties> barricadeProperties;

        public void Move(float deltaTime)
        {
            localTransform.ValueRW.Position += math.left() * properties.ValueRO.walkSpeed * deltaTime;
        }

        public bool InStoppingRange()
        {
            return math.distance(barricadeProperties.ValueRO.transform.x, localTransform.ValueRO.Position.x) <= barricadeDistance;
        }

        public const float barricadeDistance = 5f;
    }
}
