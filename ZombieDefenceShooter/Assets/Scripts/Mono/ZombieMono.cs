using Unity.Entities;
using UnityEngine;

namespace ZDS_DOTS
{
    public class ZombieMono : MonoBehaviour
    {
        public float walkSpeed;
    }

    public class ZombieBaker : Baker<ZombieMono>
    {
        
        public override void Bake(ZombieMono authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new ZombieProperties
            {
                walkSpeed = authoring.walkSpeed
            });
        }
    }
}
