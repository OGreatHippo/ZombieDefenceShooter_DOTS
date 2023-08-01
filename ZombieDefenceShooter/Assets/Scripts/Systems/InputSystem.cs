using Unity.Entities;
using UnityEngine;

namespace ZDS_DOTS
{
    public partial class InputSystem : SystemBase
    {
        protected override void OnCreate()
        {
            EntityManager.AddComponent<ShootInput>(SystemHandle);
        }

        protected override void OnUpdate()
        {
            var shootInput = new ShootInput
            {
                value = Input.GetMouseButton(0)
            };

            EntityManager.SetComponentData(SystemHandle, shootInput);
        }
    }

    public struct ShootInput : IComponentData
    {
        public bool value;
    }
}
