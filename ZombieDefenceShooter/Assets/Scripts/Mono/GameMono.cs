using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ZDS_DOTS
{
    public class GameMono : MonoBehaviour
    {
        public float2 spawnArea;
        public uint maxNumberOfEnemies = 5;
        public uint currentNumberOfEnemies;
        public uint numberOfEnemiesToWin;
        public GameObject zombies;
        public float spawnTimer;
        public GameObject spawnPoint;

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
                    spawnTimer = authoring.spawnTimer,
                    spawnPoint = GetEntity(authoring.spawnPoint, TransformUsageFlags.Dynamic)
                });

                AddComponent<SpawnTimer>(entity);
                AddComponent<SpawnPoints>(entity);
            }
        }
    }
}

