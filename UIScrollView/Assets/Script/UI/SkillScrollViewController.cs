using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
   public class SkillScrollViewController : UIScrollViewController<UISkillCellData>
   {
      public void LoadData(List<UISkillCellData> cellData)
      {
         if(tableData != null)
            tableData.Clear();
         
         tableData = cellData;
         InitializeTableView();
      }

      protected override void Start()
      {
         base.Start();
         //LoadData();
      }

      public void OnPressCell(SkillScrollViewCell cell)
      {
         Debug.Log("Cell Click");
         Debug.Log(tableData[cell.Index].name);
      }
   }
}
