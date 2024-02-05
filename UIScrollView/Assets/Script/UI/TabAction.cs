using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    [RequireComponent(typeof(Toggle))]
    public class TabAction : MonoBehaviour
    {
        [SerializeField]
        private SKILL_CATEGORY category = SKILL_CATEGORY.FIRE;
        
        private Toggle toggle;
        private Action<SKILL_CATEGORY> callAction; 
        
        public void SetTabAction(Action<SKILL_CATEGORY> callback)
        {
            if (toggle == null)
            {
                toggle = GetComponent<Toggle>();
            }
            
            callAction = callback;
            
            toggle.onValueChanged.AddListener(OnValueChanged);
        }

        public void OnValueChanged(bool isOn)
        {
            if (isOn)
            {
                callAction(category);
            }
        }
    }
}
