using System;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class UIScrollViewCell<T> : MonoBehaviour
    {
        public RectTransform CachedRectTransform => GetComponent<RectTransform>();
        
        public int Index { get; set; }

        public float Height
        {
            get
            {
                return CachedRectTransform.sizeDelta.y;
            }
            set
            {
                Vector2 sizeDelta = CachedRectTransform.sizeDelta;
                sizeDelta.y = value;
                CachedRectTransform.sizeDelta = sizeDelta;
            }
        }

        public float Width
        {
            get
            {
                return CachedRectTransform.sizeDelta.x;
            }
            set
            {
                Vector2 sizeDelta = CachedRectTransform.sizeDelta;
                sizeDelta.x = value;
                CachedRectTransform.sizeDelta = sizeDelta;
            } 
        }

        public Vector2 Top
        {
            get
            {
                Vector3[] corners = new Vector3[4];
                CachedRectTransform.GetLocalCorners(corners);
                return CachedRectTransform.anchoredPosition + new Vector2(0.0f, corners[1].y);
            }
            set
            {
                Vector3[] corners = new Vector3[4];
                CachedRectTransform.GetLocalCorners(corners);
                CachedRectTransform.anchoredPosition = value - new Vector2(0.0f, corners[1].y);
            }
        }

        public Vector2 Bottom
        {
            get
            {
                Vector3[] corners = new Vector3[4];
                CachedRectTransform.GetLocalCorners(corners);
                return CachedRectTransform.anchoredPosition + new Vector2(0.0f, corners[3].y);
            }
            set
            {
                Vector3[] corners = new Vector3[4];
                CachedRectTransform.GetLocalCorners(corners);
                CachedRectTransform.anchoredPosition = value - new Vector2(0.0f, corners[3].y);
            } 
        }
        
        public Vector2 Left
        {
            get
            {
                Vector3[] corners = new Vector3[4];
                CachedRectTransform.GetLocalCorners(corners);
                return CachedRectTransform.anchoredPosition + new Vector2(corners[0].x, 0.0f);
            }
            set
            {
                Vector3[] corners = new Vector3[4];
                CachedRectTransform.GetLocalCorners(corners);
                CachedRectTransform.anchoredPosition = value - new Vector2(corners[0].x, 0.0f);
            }
        }

        public Vector2 Right
        {
            get
            {
                Vector3[] corners = new Vector3[4];
                CachedRectTransform.GetLocalCorners(corners);
                return CachedRectTransform.anchoredPosition + new Vector2(corners[2].x, 0.0f);
            }
            set
            {
                Vector3[] corners = new Vector3[4];
                CachedRectTransform.GetLocalCorners(corners);
                CachedRectTransform.anchoredPosition = value - new Vector2(corners[2].x, 0.0f);
            } 
        }
        
        public abstract void UpdateContent(T itemData);
    }
}
