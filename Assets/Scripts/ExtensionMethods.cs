using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExtensionMethods
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Calls GetComponent and logs an error if it returns null
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T GetRequiredComponent<T>(this MonoBehaviour obj) where T : Component
        {
            T component = obj.GetComponent<T>();

            if (component == null)
            {
                Debug.LogError("Expected to find component of type " + typeof(T) + " but found none", obj);
            }

            return component;
        }

        public static Quaternion ToZAxisRotation(this Vector2 vector)
        {
            return Quaternion.Euler(0, 0, Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg);
        }
    }
}