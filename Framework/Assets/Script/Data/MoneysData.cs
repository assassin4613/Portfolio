using System.Collections;
using System.Collections.Generic;

namespace Game
{
	[System.Serializable]
	public class MoneysData : System.IDisposable
	{
		///  <summary>
		///  [ID]
		///  </summary>
		public readonly int ShopID;

		///  <summary>
		///  [보상타입]
		///  </summary>
		public readonly REWARD_TYPE Type;

		///  <summary>
		///  [이름]
		///  </summary>
		public readonly string Name;

		///  <summary>
		///  [수량]
		///  </summary>
		public readonly int Count;

		private bool disposed = false;

		public MoneysData()
		{
			ShopID = 0;
			Type = REWARD_TYPE.NONE;
			Name = "";
			Count = 0;
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
