using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class LoadDataManager
	{
		private bool isInitLoad = false;

		private List<ShopData> shopDataList = new List<ShopData>();

		public LoadDataManager()
		{
			if (!isInitLoad)
			{
				isInitLoad = true;
				InitLoadData();
			}
		}

		private void InitLoadData()
		{
            LoadShopData("DataTable/ShopData");
        }
		
		string LoadJsonData(string path)
		{
			var jsonText = (Resources.Load(path) as TextAsset).ToString();

			string[] charsTodRemove = new string[] { "\r\n", "\n", "\t", " " };


			foreach (var c in charsTodRemove)
            {
                jsonText = jsonText.Replace(c, string.Empty);
            }	

			Debug.Log(jsonText);

			return jsonText;
		}

		void LoadShopData(string path)
		{
            shopDataList = JsonUtility.FromJson<Serialization<ShopData>>(LoadJsonData(path)).ToList();
		}
	}

    public class Serialization<T>
	{
		[SerializeField]
		List<T> data;
		public List<T> ToList() { return data; }

		public Serialization(List<T> data) 
		{
			this.data = data;	
		}
	}
}
