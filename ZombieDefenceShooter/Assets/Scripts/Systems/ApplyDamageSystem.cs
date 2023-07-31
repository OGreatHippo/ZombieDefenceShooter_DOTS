using Unity.Burst;
using Unity.Entities;

namespace ZDS_DOTS
{
    [BurstCompile]
    [UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
    [UpdateAfter(typeof(EndSimulationEntityCommandBufferSystem))]
    public partial struct ApplyDamageSystem : ISystem
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
            state.Dependency.Complete();

            foreach(var barricade in SystemAPI.Query<BarricadeAspect>())
            {
                barricade.DamageBarricade();
            }
        }
    }
}
