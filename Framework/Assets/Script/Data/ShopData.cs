using System;
using System.Collections;
using System.Collections.Generic;


namespace Game
{
	[Serializable]
	public class ShopData : IDisposable
	{
		public int ShopID;

		///  <summary>
		///  [이름]
		///  </summary>
		public string Name;

		///  <summary>
		///  [상세정보]
		///  </summary>
		public string Description;

		///  <summary>
		///  [가격]
		///  </summary>
		public int Price;

		///  <summary>
		///  [패키지 아이템 목록]
		///  </summary>
		public int[] PackageID;

		private bool disposed = false;

		public ShopData(int id, string name, int price, int[] packageID)
		{
			ShopID = id;
			Name = name;
			Description = "";
			Price = price;
			PackageID = packageID;
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
