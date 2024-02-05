using UnityEngine;
using UnityEngine.UI;

using TMPro;

namespace Game
{
    public class UISkillCellData
    {
        public int index;
        public string name;
        public string desc;   
        public SKILL_CATEGORY category;
        public int[] efficacyArr;
        public string iconName;
    }

    public class SkillScrollViewCell : UIScrollViewCell<UISkillCellData>
    {
        [SerializeField] private TextMeshProUGUI itemName;
        [SerializeField] private TextMeshProUGUI desc;

        public override void UpdateContent(UISkillCellData itemData)
        {
            itemName.text = itemData.name;
            desc.text = itemData.desc.ToString();
        }

        public void OnClickedButton()
        {
            Debug.Log(itemName.text.ToString());
        }

    }
}
