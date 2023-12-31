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
        public float spawnRate;
        public uint randomSeed;

        public uint maxSpawns;
        public uint currentSpawns;
        public uint remainingSpawns;
    }

    public class GameBaker : Baker<GameMono>
    {
        public override void Bake(GameMono authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new GameProperties
            {
                spawnDimensions = authoring.spawnDimensions,
                spawnPointPrefab = GetEntity(authoring.spawnPointPrefab, TransformUsageFlags.Dynamic),
                zombiePrefab = GetEntity(authoring.zombiePrefab, TransformUsageFlags.Dynamic),
                spawnRate = authoring.spawnRate,
                transform = authoring.gameObject.transform.position,
                maxSpawns = authoring.maxSpawns,
                currentSpawns = authoring.currentSpawns,
                remainingSpawns = authoring.remainingSpawns
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
