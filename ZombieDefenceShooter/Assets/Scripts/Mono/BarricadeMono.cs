using Unity.Entities;
using UnityEngine;

namespace ZDS_DOTS
{
    public class BarricadeMono : MonoBehaviour
    {
        public uint health;
    }

    public class BarricadeBaker : Baker<BarricadeMono>
    {
        public override void Bake(BarricadeMono authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new BarricadeProperties
            {
                health = authoring.health,
                transform = authoring.transform.position
            });

            AddComponent<BarricadeTag>(entity);
                
        }
    }
}
