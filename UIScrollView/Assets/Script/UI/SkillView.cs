using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class SKillView : MonoBehaviour
    {
        [SerializeField]
        private SkillScrollViewController scrollController;
        
        [SerializeField]
        private List<TabAction> mainTab;

        private SKILL_CATEGORY viewTabCategory = SKILL_CATEGORY.NONE;

        private Dictionary<SKILL_CATEGORY, List<SkillData>> skillDataDic = new Dictionary<SKILL_CATEGORY, List<SkillData>>();

        private void Start()
        {
            SetData();
            SetTabAction();
            UpdateScroll(SKILL_CATEGORY.FIRE);
        }
        
        public void SetTabAction()
        {
            for (int i = 0; i < mainTab.Count; i++)
            {
                mainTab[i].SetTabAction(UpdateScroll);
            }
        }
        
        public void SetData()
        {
            var skillList = GameManager.Instance.LoadDataManager.SkillDataList;
            
            for (int i = 0; i <= (int)SKILL_CATEGORY.EARTH; i++)
            {
                var fireList = skillList.FindAll(data => data.Category == (SKILL_CATEGORY)i);
                skillDataDic.Add((SKILL_CATEGORY)i, fireList);
            }
        }

        public void UpdateScroll(SKILL_CATEGORY category)
        {
            if (viewTabCategory != category)
            {
                viewTabCategory = category;

                List<UISkillCellData> cellDataList = new List<UISkillCellData>();
                SetSkillItemData(skillDataDic[category], cellDataList);
                scrollController.LoadData(cellDataList); 
            }
        }

        public void SetSkillItemData(List<SkillData> skillDataList, List<UISkillCellData> cellDatas)
        {
            for (int i = 0; i < skillDataList.Count; i++)
            {
                var data = skillDataList[i];
                var cellData = new UISkillCellData();
                cellData.index = cellDatas.Count;
                cellData.name = data.Name;
                cellData.desc = data.Description;
                cellData.efficacyArr = data.EfficacyArr;
                cellData.iconName = data.IconName;
                        
                cellDatas.Add(cellData);
            }
        }
    }
}
