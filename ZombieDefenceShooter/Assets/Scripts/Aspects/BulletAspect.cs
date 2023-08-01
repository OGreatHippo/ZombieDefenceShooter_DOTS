using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ZDS_DOTS
{
    public readonly partial struct BulletAspect : IAspect
    {
        public readonly Entity entity;

        private readonly RefRW<BulletProperties> properties;
        private readonly RefRW<LocalTransform> localTransform;

        public void Move(float deltaTime)
        {
            localTransform.ValueRW.Position += math.right() * properties.ValueRO.speed * deltaTime;
        }
    }
}
