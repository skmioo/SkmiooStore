using System;
using System.Collections.Generic;

public class QuadTree<T> : QuadTreeAbs<T> where T : class
{

    internal class QuadNodeItem
    {
        public QuadNodeItem(T item, Rect bounds)
        {
            Datum = item;
            Bounds = bounds;
        }

        public T Datum { get; private set; }
        public Rect Bounds { get; private set; }
    }

    internal class QuadTreeNode
    {
        private List<QuadNodeItem> _Items = new List<QuadNodeItem>();
        private Rect _Bounds;
        private QuadTreeNode _TopLeftNode;
        private QuadTreeNode _TopRightNode;
        private QuadTreeNode _BottomLeftNode;
        private QuadTreeNode _BottomRightNode;

        public List<QuadNodeItem> Items
        {
            get { return _Items; }
        }

        public Rect Bounds
        {
            get { return _Bounds; }
        }

        public QuadTreeNode(Rect bounds)
        {
            _Bounds = bounds;
        }

        #region Insert
        public QuadTreeNode Insert(QuadNodeItem item, ref Rect bounds, int depth, int maxDepth)
        {
            if (depth < maxDepth)
            {
                QuadTreeNode child = GetItemContainerNode(ref bounds);
                if (child != null)
                {
                    return child.Insert(item, ref bounds,depth + 1, maxDepth);
                }
            }
            _Items.Add(item);
            return this;
        }

        private QuadTreeNode GetItemContainerNode(ref Rect bounds)
        {
            double halfWidth = _Bounds.Width / 2;
            double halfHeight = _Bounds.Height / 2;
            QuadTreeNode child = null;
            if (_TopLeftNode == null)
            {
                Rect topLeftRect = new Rect(_Bounds.X,_Bounds.Y,halfWidth,halfHeight);
                if (topLeftRect.Contains(bounds))
                {
                    _TopLeftNode = new QuadTreeNode(topLeftRect);
                    child = _TopLeftNode;
                }
            }
            else if (_TopLeftNode._Bounds.Contains(bounds))
            {
                child = _TopLeftNode;
            }
            if (child == null)
            {
                if (_TopRightNode == null)
                {
                    Rect topRightRect = new Rect(_Bounds.X + halfWidth, _Bounds.Y, halfWidth, halfHeight);

                    if (topRightRect.Contains(bounds))
                    {
                        _TopRightNode = new QuadTreeNode(topRightRect);
                        child = _TopRightNode;
                    }
                }
                else if (_TopRightNode._Bounds.Contains(bounds))
                {
                    child = _TopRightNode;
                }
            }

            if (child == null)
            {
                if (_BottomRightNode == null)
                {
                    Rect bottomRightRect = new Rect(_Bounds.X + halfWidth, _Bounds.Y + halfHeight, halfWidth, halfHeight);

                    if (bottomRightRect.Contains(bounds))
                    {
                        _BottomRightNode = new QuadTreeNode(bottomRightRect);
                        child = _BottomRightNode;
                    }
                }
                else if (_BottomRightNode._Bounds.Contains(bounds))
                {
                    child = _BottomRightNode;
                }
            }

            if (child == null)
            {
                if (_BottomLeftNode == null)
                {
                    Rect bottomLeftRect = new Rect(_Bounds.X, _Bounds.Y + halfHeight, halfWidth, halfHeight);

                    if (bottomLeftRect.Contains(bounds))
                    {
                        _BottomLeftNode = new QuadTreeNode(bottomLeftRect);
                        child = _BottomLeftNode;
                    }
                }
                else if (_BottomLeftNode._Bounds.Contains(bounds))
                {
                    child = _BottomLeftNode;
                }
            }
            return child;
        
        }

        #endregion


        #region Get Inside Items

        public IEnumerable<T> GetIntersectedItems(ref Rect bounds)
        {

        }
        #endregion
    }

    public override IEnumerable<T> GetInsideItems(Rect bounds)
    {
        throw new NotImplementedException();
    }

    public override IEnumerable<T> GetIntersectedItems(Rect bounds)
    {
        throw new NotImplementedException();
    }

    public override void Insert(T item, Rect bounds)
    {
        throw new NotImplementedException();
    }

    public override bool PredicateItemsCount(Rect bounds, int thresholdCount)
    {
        throw new NotImplementedException();
    }

    public override void Remove(T item)
    {
        throw new NotImplementedException();
    }

    public override void Restructure(Rect bounds)
    {
        throw new NotImplementedException();
    }
}