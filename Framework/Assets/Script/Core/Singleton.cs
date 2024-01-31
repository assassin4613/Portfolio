using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static bool shuttingDown = false;
        private static object lockObj = new object();
        private static T instance;

        public static T Instance
        {
            get
            {
                if( shuttingDown )
                {
                    return null;
                }
                
                lock( lockObj )
                {
                    if( instance == null )
                    {
                        instance = (T)FindObjectOfType( typeof( T ) );

                        GameObject singletonObject = null;
                        if( instance == null )
                        {
                            singletonObject = new GameObject();
                            instance = singletonObject.AddComponent<T>();
                        }
                        else
                        {
                            singletonObject = instance.gameObject;
                        }

                        DontDestroyOnLoad( singletonObject );
                        singletonObject.name = typeof( T ).ToString() + " (Singleton)";
                    }

                    return instance;
                }
            }
        }

        private void OnApplicationQuit()
        {
            shuttingDown = true;
        }

        private void OnDestroy()
        {
            shuttingDown = true;
        }
    }
}
