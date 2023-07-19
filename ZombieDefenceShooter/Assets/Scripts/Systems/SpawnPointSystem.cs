using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

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

            var ecb = new EntityCommandBuffer(Allocator.Temp);

            var builder = new BlobBuilder(Allocator.Temp);
            ref var spawnPoints = ref builder.ConstructRoot<SpawnPointsBlob>();
            var arrayBuilder = builder.Allocate(ref spawnPoints.value, game.SpawnPointCount);

            var spList = new NativeList<float3>(Allocator.Temp);

            for(uint x = 15; x <= game.SpawnDimensions.x; x++)
            {
                for (uint z = 0; z <= game.SpawnDimensions.y; z++)
                {
                    var spawnPoint = ecb.Instantiate(game.SpawnPointPrefab);
                    var spawnTransform = game.GetTransform(new float3(x, 0, z));

                    ecb.SetComponent(spawnPoint, spawnTransform);

                    spList.Add(spawnTransform.Position);
                }
            }

            for (int i = 0; i < game.SpawnPointCount; i++)
            {
                arrayBuilder[i] = spList[i];
            }

            var blobAsset = builder.CreateBlobAssetReference<SpawnPointsBlob>(Allocator.Persistent);
            ecb.SetComponent(gameEntity, new SpawnPoints { value = blobAsset });
            builder.Dispose();

            ecb.Playback(state.EntityManager);
        }
    }
}
