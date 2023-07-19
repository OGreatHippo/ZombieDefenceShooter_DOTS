using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ZDS_DOTS
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct SpawnPointSystem : ISystem
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

            var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);

            for(uint x = 0; x < game.SpawnDimensions.x; x++)
            {
                for (uint z = 0; z < game.SpawnDimensions.y; z++)
                {
                    var spawnPoint = ecb.Instantiate(game.SpawnPointPrefab);
                    var spawnTransform = game.GetTransform(new float3(x, 0, z));
                }
            }

            ecb.Playback(state.EntityManager);
        }
    }
}
