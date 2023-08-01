using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ZDS_DOTS
{
    public class PlayerMono : MonoBehaviour
    {
        public uint damage;
        public uint attackSpeed;
        public GameObject bullet;
    }

    public class PlayerBaker : Baker<PlayerMono>
    {
        public override void Bake(PlayerMono authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new PlayerProperties
            {
                damage = authoring.damage,
                attackSpeed = authoring.attackSpeed,
                bullet = GetEntity(authoring.bullet, TransformUsageFlags.Dynamic)
            });

            AddComponent<ShootTimer>(entity);
        }
    }
}
