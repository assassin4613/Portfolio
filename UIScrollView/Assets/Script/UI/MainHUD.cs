using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class MainHUD : MonoBehaviour
    {
        [SerializeField]
        private Button skillBtn;

        private void Start()
        {
           skillBtn.onClick.AddListener(OnSkillBtnClick);
        }

        private void OnSkillBtnClick()
        {
            GameManager.Instance.uiManager.LoadUI( "SkillView" );
        }   
    }
}
