using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;

namespace ZDS_DOTS
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct SpawnSpawnPointsSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<GameProperties>();
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
            
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;

            var gameEntity = SystemAPI.GetSingletonEntity<GameProperties>();
            var game = SystemAPI.GetAspect<GameAspect>(gameEntity);

            var ecb = new EntityCommandBuffer(Allocator.Temp);
            var spawnPoints = new NativeList<float3>(Allocator.Temp);
           
            for(uint i = 0; i < game.SpawnArea.x; i++)
            {
                for (uint j = 0; j < game.SpawnArea.y; j++)
                {
                    var newSpawnPoint = ecb.Instantiate(game.spawnPrefab);
                    var newSpawnTransform = game.GetSpawnPointTransform(new float3(i, 0, j));

                    spawnPoints.Add(newSpawnTransform.Position);
                }
            }

            game.SpawnPoints = spawnPoints.ToArray(Allocator.Persistent);

            ecb.Playback(state.EntityManager);
        }
    }
}

