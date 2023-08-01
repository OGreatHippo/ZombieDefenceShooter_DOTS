using Unity.Entities;
using Unity.Transforms;

namespace ZDS_DOTS
{
    public readonly partial struct BulletAspect : IAspect
    {
        public readonly Entity entity;

        private readonly RefRW<BulletProperties> properties;
        private readonly RefRW<LocalTransform> localTransform;
    }
}
