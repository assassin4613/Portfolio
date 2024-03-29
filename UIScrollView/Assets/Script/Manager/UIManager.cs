using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Observer;
using System.Text;

namespace Game
{
    public class UIManager : MonoBehaviour, IManager
    {
        Subject _subject;
        public Subject subject
        {
            get
            {
                if (_subject == null)
                {
                    _subject = new Subject();
                }

                return _subject;
            }
        }
     
        [SerializeField]
        private Transform viewRoot;
        
        private Dictionary<string, GameObject> viewUIDic = new Dictionary<string, GameObject>();

        readonly string UIPATH = "Prefab/UI/";

        public UIManager()
        {
            ManagerUpdate();
        }

        public void ManagerUpdate()
        {
            subject.OnNotify();
        }

        public void ManagerLoop() { }

        public void ManagerClear()
        {
            if (_subject != null)
            {
                _subject.OnClear();
            }
        }

        public GameObject LoadUI(string Path)
        {
            GameObject go = null;
            if (viewUIDic.TryGetValue(Path, out go))
            {
                return go;
            }
            
            StringBuilder sb = new StringBuilder();
            sb.Append(UIPATH);
            sb.Append(Path);
            go = Resources.Load<GameObject>(sb.ToString());

            if (go == null)
            {
                Debug.LogError("LoadUI Error: " + Path);
                return null;
            }

            go = Instantiate(go, viewRoot);
            go.name = Path;
            viewUIDic.Add(Path, go);

            return go;
        }
    }
}
