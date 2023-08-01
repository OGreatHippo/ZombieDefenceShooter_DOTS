using Unity.Burst;
using Unity.Entities;

namespace ZDS_DOTS
{
    //[UpdateAfter(typeof(InputSystem))] //this should be working and it needs to happen, but for some reason its interfering with the zombiewalkaspect
    [BurstCompile]
    public partial struct ShootSystem : ISystem
    {
        private SystemHandle _handle;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            _handle = state.World.GetExistingSystem<InputSystem>(); //this is not supported and gets an error, but works anyway
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            bool shouldShoot = SystemAPI.GetComponent<ShootInput>(_handle).value;

            float deltaTime = SystemAPI.Time.DeltaTime;
            var ecbSingleton = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();

            new ShootJob
            {
                shouldShoot = shouldShoot,
                deltaTime = deltaTime,
                ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged)
            }.Run();
        }
    }

    [BurstCompile]
    public partial struct ShootJob : IJobEntity
    {
        public float deltaTime;
        public EntityCommandBuffer ecb;
        public bool shouldShoot;

        [BurstCompile]
        private void Execute(PlayerAspect player)
        {
            if(shouldShoot)
            {
                player.Shoot(deltaTime, ecb);
            }
        }
    }
}
