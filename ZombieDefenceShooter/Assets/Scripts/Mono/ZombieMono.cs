using Unity.Entities;
using UnityEngine;

namespace ZDS_DOTS
{
    public class ZombieMono : MonoBehaviour
    {
        public float walkSpeed;
        public uint damage;
        public uint attackSpeed;
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

            AddComponent(entity, new ZombieAttackProperties
            {
                damage = authoring.damage,
                attackSpeed = authoring.attackSpeed
            });

            AddComponent(entity, new ZombieTimer
            {
                value = authoring.attackSpeed
            });
        }
    }
}
