using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ZDS_DOTS
{
    public class GameMono : MonoBehaviour
    {
        public float3 spawnArea;
        public uint maxNumberOfEnemies = 5;
        public uint currentNumberOfEnemies;
        public uint numberOfEnemiesToWin;
        public GameObject zombies;
        public uint random;
        public float spawnTimer;

        public class GameBaker : Baker<GameMono>
        {
            public override void Bake(GameMono authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);

                AddComponent(entity, new GameProperties
                {
                    spawnArea = authoring.spawnArea,
                    maxNumberOfEnemies = authoring.maxNumberOfEnemies,
                    currentNumberOfEnemies = authoring.currentNumberOfEnemies,
                    numberOfEnemiesToWin = authoring.numberOfEnemiesToWin,
                    zombies = GetEntity(authoring.zombies, TransformUsageFlags.Dynamic),
                    spawnTimer = authoring.spawnTimer
                });

                AddComponent(entity, new SpawnTimer
                {
                    value = authoring.spawnTimer
                });

                AddComponent(entity, new RandomSpawn
                {
                    random = Unity.Mathematics.Random.CreateFromIndex(authoring.random)
                });
            }
        }
    }
}

