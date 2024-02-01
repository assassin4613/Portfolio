using System;
using System.Collections;
using System.Collections.Generic;


namespace Game
{
	[Serializable]
	public class SkillData : IDisposable
	{
		public int ShopID;

		///  <summary>
		///  [이름]
		///  </summary>
		public string Name;

		/// <summary>
		/// [카테고리]
		/// </summary>
		public SKILL_CATEGORY Category;

		///  <summary>
		///  [상세정보]
		///  </summary>
		public string Description;

		/// <summary>
		/// [스킬효과]
		/// </summary>
		public int[] EfficacyArr;

		///  <summary>
		///  [Icon]
		///  </summary>
		public string IconName;

		private bool disposed = false;

		public SkillData(int id, string name, SKILL_CATEGORY category, string description, int[] efficacyArr, string iconName)
		{
			ShopID = id;
			Name = name;
			Category = category;
			Description = description;
			EfficacyArr = efficacyArr;
			IconName = iconName;
		}

		public void Dispose()
		{
			Dispose(true);
			System.GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
				}

				disposed = true;
			}
		}
	}
}
