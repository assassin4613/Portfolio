using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
	public class LoadDataManager
	{
		private bool isInitLoad = false;

		private List<SkillData> skillDataList = new List<SkillData>();
		public List<SkillData> SkillDataList { get { return skillDataList; } }

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
            skillDataList = LoadData<SkillData>("DataTable/SkillData");
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

		List<T> LoadData<T>(string path)
		{
			return JsonConvert.DeserializeObject<List<T>>(LoadJsonData(path));
            //return JsonUtility.FromJson<Serialization<T>>(LoadJsonData(path)).ToList();
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
