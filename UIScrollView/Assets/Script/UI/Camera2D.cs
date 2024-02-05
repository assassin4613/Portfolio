using UnityEngine;

using Observer;

namespace Game
{
	[RequireComponent(typeof(Camera))]
	public class Camera2D : MonoBehaviour, IObserver
	{
		public int minWidth;
		public int minHeight;
		public bool matchWidth;
		[HideInInspector] public int screenWidth;
		[HideInInspector] public int screenHeight;

		Subject _subject;

		public Subject subject
		{ 
			get
			{
				if (_subject == null)
				{ 
					_subject = new Subject();
				}

				return _subject;
			}
		}

		public int Priority { get; set; }
		public int ID { get; set; }

		private Camera _cam;

		public void OnEnable()
		{
			if (GameManager.Instance == null)
			{
				return;
			}

			ScreenManager screenManager = GameManager.Instance.screenManager;
			OnScreenSize(screenManager.ScreenWidth, screenManager.ScreenHeight);

			screenManager.subject.AddObserver(this);
		}

		public void OnDisable()
		{
			if (GameManager.Instance == null)
			{
				return;
			}

			ScreenManager screenManager = GameManager.Instance.screenManager;
			screenManager.subject.RemoveObserver(this);
		}

		public void OnResponse(object obj)
		{
			ScreenManager screenManager = obj as ScreenManager;
			if (screenManager != null)
			{
				OnScreenSize(screenManager.ScreenWidth, screenManager.ScreenHeight);
			}
		}

		public void OnScreenSize(int screenWidth, int screenHeight)
		{
			if (_cam == null)
			{
				_cam = GetComponent<Camera>();
			}

			if (_cam.orthographic == false)
			{
				_cam.orthographic = true;
			}

			int orthographicSize = GetOrthographicSize(screenWidth, screenHeight);
			_cam.orthographicSize = orthographicSize;

			orthographicSize *= 2;

			this.screenWidth = (screenWidth * orthographicSize) / screenHeight;
			this.screenHeight = orthographicSize;

			subject.OnNotify();
		}

		public int GetOrthographicSize(int screenWidth, int screenHeight)
		{
			int orthographicSize = 0;
			float addRate = 0.0f;

			if (matchWidth)
			{
				orthographicSize = Mathf.RoundToInt((screenHeight * minWidth) / screenWidth);
				if (orthographicSize < minHeight)
				{
					addRate = (float)minHeight / orthographicSize;
					orthographicSize = Mathf.RoundToInt(orthographicSize * addRate);
				}
			}
			else
			{
				orthographicSize = minHeight;
				int width = (screenWidth * minHeight) / screenHeight;
				if (width < minWidth)
				{
					addRate = (float)minWidth / width;
					orthographicSize = Mathf.RoundToInt(orthographicSize * addRate);
				}
			}

			return Mathf.RoundToInt(orthographicSize * 0.5f);
		}
	}
}
