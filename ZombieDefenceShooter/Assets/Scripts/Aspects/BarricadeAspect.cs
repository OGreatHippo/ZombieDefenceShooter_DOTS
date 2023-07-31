using Unity.Entities;

namespace ZDS_DOTS
{
    public readonly partial struct BarricadeAspect : IAspect
    {
        public readonly Entity entity;

        private readonly RefRW<BarricadeProperties> properties;
        private readonly DynamicBuffer<BarricadeDamageBufferElement> buffer;

        public void DamageBarricade()
        {
            foreach (var bufferElement in buffer) 
            {
                properties.ValueRW.currentHealth -= bufferElement.value;
            }

            buffer.Clear();
        }
    }
}
