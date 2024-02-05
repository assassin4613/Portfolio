using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    [RequireComponent(typeof(ScrollRect))]
    [RequireComponent(typeof(RectTransform))]
    public class UIScrollViewController<T> : MonoBehaviour
    {
        enum ArrayMode
        {
            HORIZONTAL = 0,
            VERTICAL = 1,
            GRID = 2
        }
        
        protected List<T> tableData = new List<T>();
        
        [SerializeField] 
        protected GameObject cellBase = null;
        [SerializeField] 
        private RectOffset padding;
        [SerializeField] 
        private ArrayMode arrayMode = ArrayMode.HORIZONTAL;
        [SerializeField] 
        private float spacingWidth = 0.0f;
        [SerializeField] 
        private float spacingHeight = 0.0f;
        [SerializeField] 
        private RectOffset visibleRectPadding = null;

        private LinkedList<UIScrollViewCell<T>> cells = new LinkedList<UIScrollViewCell<T>>();
        private Rect visibleRect;
        private Vector2 prevScrollPos;

        public RectTransform CachedRectTransform => GetComponent<RectTransform>();
        public ScrollRect CachedScrollRect => GetComponent<ScrollRect>();

        protected virtual void Start()
        {
            cellBase.SetActive(false);
            CachedScrollRect.onValueChanged.AddListener(OnScrollPosChanged);
        }

        protected void InitializeTableView()
        {
            UpdateScrollViewSize();
            UpdateVisibleRect();

            if (cells.Count < 1)
            {
                if (arrayMode == ArrayMode.VERTICAL)
                {
                    Vector2 cellTop = new Vector2(0.0f, -padding.top);

                    for (int i = 0; i < tableData.Count; i++)
                    {
                        float cellHeight = GetCellHeightAtIndex(i);
                        Vector2 cellBottom = cellTop + new Vector2(0.0f, -cellHeight);

                        if ((cellTop.y <= visibleRect.y && cellTop.y > visibleRect.y - visibleRect.height)
                            || (cellBottom.y <= visibleRect.y && cellBottom.y >= visibleRect.y - visibleRect.height))
                        {
                            UIScrollViewCell<T> cell = CreateCellForIndex(i);
                            cell.Top = cellTop;
                            break;
                        }

                        cellTop = cellBottom + new Vector2(0.0f, spacingHeight);
                    }
                }
                else
                {
                    Vector2 cellLeft = new Vector2(padding.left, 0.0f);

                    for (int i = 0; i < tableData.Count; i++)
                    {
                        float cellWidth = GetCellWidthAtIndex(i);
                        Vector2 cellRight = cellLeft + new Vector2(cellWidth, 0.0f);

                        if ((cellLeft.x >= visibleRect.x && cellLeft.x < visibleRect.x + visibleRect.width)
                            || (cellRight.x >= visibleRect.x && cellRight.x <= visibleRect.x + visibleRect.width))
                        {
                            UIScrollViewCell<T> cell = CreateCellForIndex(i);
                            cell.Left = cellLeft;
                            break;
                        }

                        cellLeft = cellRight + new Vector2(spacingWidth, 0.0f);
                    }
                }

                SetFillVisibleRectWithCells();
            }
            else
            {
                LinkedListNode<UIScrollViewCell<T>> node = cells.First;
                UpdateCellForIndex(node.Value, node.Value.Index);
                node = node.Next;

                while (node != null)
                {
                    UpdateCellForIndex(node.Value, node.Previous.Value.Index + 1);

                    if (arrayMode == ArrayMode.VERTICAL)
                    {
                        node.Value.Top = node.Previous.Value.Bottom + new Vector2(0.0f, -spacingHeight);
                    }
                    else
                    {
                        node.Value.Left = node.Previous.Value.Right + new Vector2(spacingWidth, 0.0f); 
                    }

                    node = node.Next;
                }

                SetFillVisibleRectWithCells();
            }
        }

        protected virtual float GetCellWidthAtIndex(int index)
        {
            return cellBase.GetComponent<RectTransform>().sizeDelta.x;
        }
        
        protected virtual float GetCellHeightAtIndex(int index)
        {
            return cellBase.GetComponent<RectTransform>().sizeDelta.y;
        }

        protected void UpdateScrollViewSize()
        {
            Vector2 sizeDelta = CachedScrollRect.content.sizeDelta;
            
            if (arrayMode == ArrayMode.VERTICAL)
            {
                float contentHeight = 0.0f;

                for (int i = 0; i < tableData.Count; i++)
                {
                    contentHeight += GetCellHeightAtIndex(i);

                    if (i > 0)
                        contentHeight += spacingHeight;
                }
                
                sizeDelta.y = padding.top + contentHeight + padding.bottom;
            }
            else
            {
                float contentWidth = 0.0f;

                for (int i = 0; i < tableData.Count; i++)
                {
                    contentWidth += GetCellWidthAtIndex(i);

                    if (i > 0)
                        contentWidth += spacingWidth;
                }
                
                sizeDelta.x = padding.left + contentWidth + padding.right;
            } 

            CachedScrollRect.content.sizeDelta = sizeDelta;
        }

        private UIScrollViewCell<T> CreateCellForIndex(int index)
        {
            GameObject obj = Instantiate(cellBase);
            obj.SetActive(true);

            UIScrollViewCell<T> cell = obj.GetComponent<UIScrollViewCell<T>>();
            Vector3 scale = cell.transform.localScale;
            Vector2 sizeDelta = cell.CachedRectTransform.sizeDelta;
            Vector2 offsetMin = cell.CachedRectTransform.offsetMin;
            Vector2 offsetMax = cell.CachedRectTransform.offsetMax;
            
            cell.transform.SetParent(cellBase.transform.parent);

            cell.transform.localScale = scale;
            cell.CachedRectTransform.sizeDelta = sizeDelta;
            cell.CachedRectTransform.offsetMin = offsetMin;
            cell.CachedRectTransform.offsetMax = offsetMax;

            UpdateCellForIndex(cell, index);

            cells.AddLast(cell);
            
            return cell;
        }

        private void UpdateCellForIndex(UIScrollViewCell<T> cell, int index)
        {
            cell.Index = index;

            if (cell.Index >= 0 && cell.Index <= tableData.Count - 1)
            {
                cell.gameObject.SetActive(true);
                cell.UpdateContent(tableData[cell.Index]);
                
                if(arrayMode == ArrayMode.VERTICAL)
                    cell.Height = GetCellHeightAtIndex(cell.Index);
                else
                    cell.Width = GetCellWidthAtIndex(cell.Index); 
            }
            else
            {
                cell.gameObject.SetActive(false);
            }
        }

        private void UpdateVisibleRect()
        {
            visibleRect.x = CachedScrollRect.content.anchoredPosition.x + visibleRectPadding.left;
            visibleRect.y = -CachedScrollRect.content.anchoredPosition.y + visibleRectPadding.top;

            visibleRect.width = CachedRectTransform.rect.width + visibleRectPadding.left + visibleRectPadding.right;
            visibleRect.height = CachedRectTransform.rect.height + visibleRectPadding.top + visibleRectPadding.bottom;
        }

        private void SetFillVisibleRectWithCells()
        {
            if (cells.Count < 1)
                return;

            UIScrollViewCell<T> lastCell = cells.Last.Value;
            int nextCellDataIndex = lastCell.Index + 1;

            if (arrayMode == ArrayMode.VERTICAL)
            {
                Vector2 nextCellTop = lastCell.Bottom + new Vector2(0.0f, -spacingHeight);

                while (nextCellDataIndex < tableData.Count && nextCellTop.y >= visibleRect.y - visibleRect.height)
                {
                    UIScrollViewCell<T> cell = CreateCellForIndex(nextCellDataIndex);
                    cell.Top = nextCellTop;

                    lastCell = cell;
                    nextCellDataIndex = lastCell.Index + 1;
                    nextCellTop = lastCell.Bottom + new Vector2(0.0f, -spacingHeight);
                }
            }
            else
            {
                Vector2 nextCellLeft = lastCell.Right + new Vector2(spacingWidth, 0.0f);

                while (nextCellDataIndex < tableData.Count && nextCellLeft.x <= -visibleRect.x + visibleRect.width)
                {
                    UIScrollViewCell<T> cell = CreateCellForIndex(nextCellDataIndex);
                    cell.Left = nextCellLeft;

                    lastCell = cell;
                    nextCellDataIndex = lastCell.Index + 1;
                    nextCellLeft = lastCell.Right + new Vector2(spacingWidth, 0.0f);
                } 
            }
        }

        public void OnScrollPosChanged(Vector2 scrollPos)
        {
            UpdateVisibleRect();
            
            if(arrayMode == ArrayMode.VERTICAL)
                UpdateVerticalCells((scrollPos.y < prevScrollPos.y) ? 1 : -1);
            else
                UpdateHorizontalCells((scrollPos.x > prevScrollPos.x) ? 1 : -1);
            
            prevScrollPos = scrollPos;
        }

        private void UpdateVerticalCells(int scrollDirection)
        {
            if (cells.Count < 1)
                return;

            if (scrollDirection > 0)
            {
                UIScrollViewCell<T> firstCell = cells.First.Value;

                while (firstCell.Bottom.y > visibleRect.y)
                {
                    UIScrollViewCell<T> lastCell = cells.Last.Value;
                    UpdateCellForIndex(firstCell, lastCell.Index + 1);
                    firstCell.Top = lastCell.Bottom + new Vector2(0.0f, -spacingHeight);

                    cells.AddLast(firstCell);
                    cells.RemoveFirst();
                    firstCell = cells.First.Value;
                }
                
                SetFillVisibleRectWithCells();
            }
            else if (scrollDirection < 0)
            {
                UIScrollViewCell<T> lastCell = cells.Last.Value;

                while (lastCell.Top.y < visibleRect.y - visibleRect.height)
                {
                    UIScrollViewCell<T> firstCell = cells.First.Value;
                    UpdateCellForIndex(lastCell, firstCell.Index - 1);
                    lastCell.Bottom = firstCell.Top + new Vector2(0.0f, spacingHeight);

                    cells.AddFirst(lastCell);
                    cells.RemoveLast();
                    lastCell = cells.Last.Value;
                }
            }
        }
        
        private void UpdateHorizontalCells(int scrollDirection)
        {
            if (cells.Count < 1)
                return;

            if (scrollDirection > 0)
            {
                UIScrollViewCell<T> firstCell = cells.First.Value;

                while (firstCell.Right.x < -visibleRect.x)
                {
                    UIScrollViewCell<T> lastCell = cells.Last.Value;
                    UpdateCellForIndex(firstCell, lastCell.Index + 1);
                    firstCell.Left = lastCell.Right + new Vector2( spacingWidth, 0.0f);

                    cells.AddLast(firstCell);
                    cells.RemoveFirst();
                    firstCell = cells.First.Value;
                }
                
                SetFillVisibleRectWithCells();
            }
            else if (scrollDirection < 0)
            {
                UIScrollViewCell<T> lastCell = cells.Last.Value;

                while (lastCell.Left.x > -visibleRect.x + visibleRect.width)
                {
                    UIScrollViewCell<T> firstCell = cells.First.Value;
                    UpdateCellForIndex(lastCell, firstCell.Index - 1);
                    lastCell.Right = firstCell.Left + new Vector2(-spacingWidth, 0.0f);

                    cells.AddFirst(lastCell);
                    cells.RemoveLast();
                    lastCell = cells.Last.Value;
                }
            }
        }
    }
}
