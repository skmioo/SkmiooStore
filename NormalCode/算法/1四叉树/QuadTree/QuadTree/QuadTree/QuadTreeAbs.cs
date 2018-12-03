using System.Collections.Generic;

public abstract class QuadTreeAbs<T> where T : class
{
    /// <summary>
    /// 向四叉树中插入节点
    /// </summary>
    /// <param name="item"></param>
    /// <param name="bounds"></param>
    public abstract void Insert(T item, Rect bounds);
    /// <summary>
    /// 向四叉树中移除节点
    /// </summary>
    /// <param name="item"></param>
    public abstract void Remove(T item);
    /// <summary>
    /// 从四叉树中检索指定矩形内的元素（元素的边界被指定矩形包含）
    /// </summary>
    /// <param name="bounds"></param>
    /// <returns></returns>
    public abstract IEnumerable<T> GetInsideItems(Rect bounds);
    /// <summary>
    /// 从四叉树中检索指定矩形内的元素（元素的边界跟指定矩形有交集）
    /// </summary>
    /// <param name="bounds"></param>
    /// <returns></returns>
    public abstract IEnumerable<T> GetIntersectedItems(Rect bounds);
    /// <summary>
    /// 指定的包含所有元素的边界重新构建四叉树
    /// </summary>
    /// <param name="bounds"></param>
    public abstract void Restructure(Rect bounds);
    /// <summary>
    /// 判断指定矩形的的元素个数是否是小于thresholdCount参数指定的值（与指定矩形相交即可算作矩形内的元素）
    /// </summary>
    /// <param name="bounds"></param>
    /// <param name="thresholdCount"></param>
    /// <returns></returns>
    public abstract bool PredicateItemsCount(Rect bounds, int thresholdCount);
}

