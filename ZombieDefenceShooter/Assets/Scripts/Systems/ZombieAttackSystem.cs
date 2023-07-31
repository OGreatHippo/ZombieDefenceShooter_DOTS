using Unity.Burst;
using Unity.Entities;

namespace ZDS_DOTS
{
    [BurstCompile]
    [UpdateAfter(typeof(ZombieSystem))]
    public partial struct ZombieAttackSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<BarricadeTag>();
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
            var barricadeEntity = SystemAPI.GetSingletonEntity<BarricadeTag>();

            new AttackJob
            {
                deltaTime = deltaTime,
                ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged).AsParallelWriter(),
                barricadeEntity = barricadeEntity
            }.ScheduleParallel();
        }
    }

    [BurstCompile]
    public partial struct AttackJob : IJobEntity
    {
        public float deltaTime;
        public EntityCommandBuffer.ParallelWriter ecb;
        public Entity barricadeEntity;

        [BurstCompile]
        private void Execute(ZombieAttackAspect zombie, [ChunkIndexInQuery] int sortKey)
        {
            zombie.Attack(deltaTime, ecb, sortKey, barricadeEntity);
        }
    }
}
