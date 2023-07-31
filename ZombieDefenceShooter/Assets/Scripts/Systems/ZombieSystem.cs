using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ZDS_DOTS
{
    [BurstCompile]
    [UpdateAfter(typeof(SpawnZombieSystem))]
    public partial struct ZombieSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {

        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;
            var ecbSingleton = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();
            float distance = 1.1f;

            var barricadeEntity = SystemAPI.GetSingletonEntity<BarricadeTag>();
            float3 barricadeTransform = SystemAPI.GetComponent<LocalTransform>(barricadeEntity).Position;
            
            new WalkJob
            {
                deltaTime = deltaTime,
                ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged).AsParallelWriter(),
                distance = distance,
                barricadeTransform = barricadeTransform
            }.ScheduleParallel();
        }
    }

    [BurstCompile]
    public partial struct WalkJob : IJobEntity
    {
        public float deltaTime;
        public EntityCommandBuffer.ParallelWriter ecb;
        public float distance;
        public float3 barricadeTransform;

        [BurstCompile]
        private void Execute(ZombieWalkAspect zombie, [ChunkIndexInQuery] int sortKey)
        {
            zombie.Move(deltaTime);

            if (zombie.InStoppingRange(barricadeTransform, distance))
            {
                ecb.SetComponentEnabled<ZombieWalkProperties>(sortKey, zombie.entity, false);
                ecb.SetComponentEnabled<ZombieAttackProperties>(sortKey, zombie.entity, true);
            }

            else
            {
                ecb.SetComponentEnabled<ZombieWalkProperties>(sortKey, zombie.entity, true);
                ecb.SetComponentEnabled<ZombieAttackProperties>(sortKey, zombie.entity, false);
            }
        }
    }
}
