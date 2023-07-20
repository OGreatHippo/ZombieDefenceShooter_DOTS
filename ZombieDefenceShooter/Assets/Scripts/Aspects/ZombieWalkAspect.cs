using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ZDS_DOTS
{
    public readonly partial struct ZombieWalkAspect : IAspect
    {
        private readonly RefRO<ZombieProperties> properties;
        private readonly RefRW<LocalTransform> localTransform;
        private readonly RefRO<BarricadeProperties> barricadeProperties;

        public void Move(float deltaTime)
        {
            if(math.distance(barricadeProperties.ValueRO.transform, localTransform.ValueRO.Position) >= barricade_Distance)
            {
                localTransform.ValueRW.Position += math.left() * properties.ValueRO.walkSpeed * deltaTime;
            }
        }

        private const float barricade_Distance = 5;
    }
}
