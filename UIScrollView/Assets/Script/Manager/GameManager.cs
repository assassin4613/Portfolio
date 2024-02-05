using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameManager : Singleton<GameManager>
    {
        private LoadDataManager loadDataManager;
        public LoadDataManager LoadDataManager
        {
            get { return loadDataManager; }
        }
                
        public ScreenManager screenManager;
        public UIManager uiManager;
        
        List<IManager> managerList = new List<IManager>();
                
        protected virtual void Start()
        {
            loadDataManager = new LoadDataManager();
            managerList.Add( screenManager );
            managerList.Add( uiManager );
        }
        
        protected virtual void Update()
        {
            IManager manager;
            for( int i = 0, icount = managerList.Count; i < icount; ++i )
            {
                manager = managerList[i];
                if( manager != null )
                {
                    manager.ManagerUpdate();
                }
            }
        }
        
        protected virtual void GameLoop()
        {
            IManager manager;
            for( int i = 0, icount = managerList.Count; i < icount; ++i )
            {
                manager = managerList[i];
                if( manager != null )
                {
                    manager.ManagerLoop();
                }
            }
        }
        
        protected virtual void Clear()
        {
            IManager manager;
            for (int i = 0, icount = managerList.Count; i < icount; ++i)
            {
                manager = managerList[i];
                if (manager != null)
                {
                    manager.ManagerClear();
                }
            }
        }
        
        private IEnumerator Loop()
        { 
            WaitForSeconds wfs = new WaitForSeconds( 1f ); while( true )
            {
                yield return wfs;
                GameLoop();
            }
        }
    }
}