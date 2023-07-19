using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ZDS_DOTS
{
    public class GameMono : MonoBehaviour
    {
        public float2 spawnDimensions;
        public GameObject spawnPointPrefab;
    }

    public class Baker : Baker<GameMono>
    {
        public override void Bake(GameMono authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new GameProperties
            {
                spawnDimensions = authoring.spawnDimensions,
                spawnPointPrefab = GetEntity(authoring.spawnPointPrefab, TransformUsageFlags.Dynamic)
            });
        }
    }
}
