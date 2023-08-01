using Unity.Entities;
using UnityEngine;

namespace ZDS_DOTS
{
    public class BulletMono : MonoBehaviour
    {
        public uint speed;
        public uint damage;
    }

    public class BulletBaker : Baker<BulletMono>
    {
        public override void Bake(BulletMono authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new BulletProperties
            {
                speed = authoring.speed,
                damage = authoring.damage,
            });
        }
    }
}
