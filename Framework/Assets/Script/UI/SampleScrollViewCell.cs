using UnityEngine;
using UnityEngine.UI;


namespace Game
{
    public class UISampleCellData
    {
        public int index;
        public string name;
    }

    public class SampleScrollViewCell : UIScrollViewCell<UISampleCellData>
    {
        [SerializeField] private Text itemIndex;
        [SerializeField] private Text itemName;

        public override void UpdateContent(UISampleCellData itemData)
        {
            itemIndex.text = itemData.index.ToString();
            itemName.text = itemData.name;
        }

        public void OnClickedButton()
        {
            Debug.Log(itemName.text.ToString());
        }

    }
}
