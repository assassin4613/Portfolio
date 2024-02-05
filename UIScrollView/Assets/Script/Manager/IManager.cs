using UnityEngine;

namespace Game
{
    public interface IManager
    {
        void ManagerUpdate();
        void ManagerLoop();
        void ManagerClear();
    }
}
