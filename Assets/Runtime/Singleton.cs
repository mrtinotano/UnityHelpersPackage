using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace voodooTest
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance
        {
            get
            {
                if (instance == null)
                    instance = FindObjectOfType<T>();

                return instance;
            }
        }

        private static T instance;

        protected virtual void Awake()
        {
            instance = this as T;
        }
    }
}
