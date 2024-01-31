using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
   public class SampleScrollViewController : UIScrollViewController<UISampleCellData>
   {
      public void LoadData(List<UISampleCellData> cellData)
      {
         if(tableData != null)
            tableData.Clear();
         
         tableData = cellData;
         InitializeTableView();
      }

      protected override void Start()
      {
         base.Start();
      }

      public void OnPressCell(SampleScrollViewCell cell)
      {
         Debug.Log("Cell Click");
         Debug.Log(tableData[cell.Index].name);
      }
   }
}
