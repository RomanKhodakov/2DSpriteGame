using System;
using UnityEngine;

namespace Test2DGame
{
    internal static partial class BuilderExtension
    {
        public static Vector3 Change(this Vector3 org, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(x ?? org.x, y ?? org.y, z ?? org.z);
        }

        public static Vector2 Change(this Vector2 org, float? x = null, float? y = null)
        {
            return new Vector2(x ?? org.x, y ?? org.y);
        }
    }
}