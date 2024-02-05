using UnityEngine;

using Observer;

namespace Game
{
    public class ScreenManager : MonoBehaviour, IManager
    {
        Subject _subject;
        public Subject subject
        {
            get
            {
                if( _subject == null )
                {
                    _subject = new Subject();
                }

                return _subject;
            }
        }

        public int ScreenWidth { get; private set; } = 0;
        
        public int ScreenHeight { get; private set; } = 0;
        
        public ScreenManager()
        {
            ManagerUpdate();
        }
        
        public void ManagerUpdate()
        {
            if( ScreenWidth != Screen.width || ScreenHeight != Screen.height )
            {
                ScreenWidth = Screen.width;
                ScreenHeight = Screen.height;

                subject.OnNotify();
            }
        }

        public void ManagerLoop() {}

        public void ManagerClear()
        {
            if( _subject != null )
            {
                _subject.OnClear();
            }
        }
    }
}
