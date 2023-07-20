using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ZDS_DOTS
{
    public class GameMono : MonoBehaviour
    {
        public float2 spawnDimensions;
        public GameObject spawnPointPrefab;
        public GameObject zombiePrefab;
        public uint spawnRate;
        public uint randomSeed;
    }

    public class Baker : Baker<GameMono>
    {
        public override void Bake(GameMono authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new GameProperties
            {
                spawnDimensions = authoring.spawnDimensions,
                spawnPointPrefab = GetEntity(authoring.spawnPointPrefab, TransformUsageFlags.Dynamic),
                zombiePrefab = GetEntity(authoring.zombiePrefab, TransformUsageFlags.Dynamic),
                spawnRate = authoring.spawnRate
            });

            AddComponent<SpawnPoints>(entity);
            AddComponent<SpawnTimer>(entity);

            AddComponent(entity, new GameRandom
            {
                random = Unity.Mathematics.Random.CreateFromIndex(authoring.randomSeed)
            });
        }
    }
}
