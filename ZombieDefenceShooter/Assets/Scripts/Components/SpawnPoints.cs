using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace ZDS_DOTS
{
    public struct SpawnPoints : IComponentData
    {
        public BlobAssetReference<SpawnPointsBlob> value;
    }

    public struct SpawnPointsBlob
    {
        public BlobArray<float3> value;
    }
}
