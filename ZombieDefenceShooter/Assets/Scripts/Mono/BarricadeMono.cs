using Unity.Entities;
using UnityEngine;

namespace ZDS_DOTS
{
    public class BarricadeMono : MonoBehaviour
    {
        public uint currentHealth;
        public uint maxHealth;
    }

    public class BarricadeBaker : Baker<BarricadeMono>
    {
        public override void Bake(BarricadeMono authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new BarricadeProperties
            {
                currentHealth = authoring.currentHealth,
                maxHealth = authoring.maxHealth,
                transform = authoring.transform.position
            });

            AddComponent<BarricadeTag>(entity);
            AddBuffer<BarricadeDamageBufferElement>(entity);
        }
    }
}
