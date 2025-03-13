using UnityEngine;

namespace Utils
{
    public static class TransformExtensions
    {
        public static void DestroyAllChildren(this Transform transform)
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}