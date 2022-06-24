using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityEngine.UI.Collections
{
    /// <summary>
    /// 比较费内存，但插入速度快
    /// 查询速度快
    /// 删除速度快
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class IndexedSet<T> : IList<T>
    {
        //这是一个容器，它提供：
        // - 唯一的item
        // - 快速随机移除
        // - 快速唯一包含到最后
        // - 顺序访问
        //This is a container that gives:
        //  - Unique items
        //  - Fast random removal
        //  - Fast unique inclusion to the end
        //  - Sequential access

        //缺点：
        // - 使用更多内存
        // - 排序不是持久的
        // - 不是序列化友好的。
        //Downsides:
        //  - Uses more memory
        //  - Ordering is not persistent
        //  - Not Serialization Friendly.
        //我们使用字典来加速列表查找，这使得保证没有重复（集合）变得更快
        //We use a Dictionary to speed up list lookup, this makes it cheaper to guarantee no duplicates (set)
        //When removing we move the last item to the removed item position, this way we only need to update the index cache of a single item. (fast removal)
        //Order of the elements is not guaranteed. A removal will change the order of the items.

        readonly List<T> m_List = new List<T>();
        Dictionary<T, int> m_Dictionary = new Dictionary<T, int>();

        public void Add(T item)
        {
            m_List.Add(item);
            m_Dictionary.Add(item, m_List.Count - 1);
        }

        public bool AddUnique(T item)
        {
            if (m_Dictionary.ContainsKey(item))
                return false;

            m_List.Add(item);
            m_Dictionary.Add(item, m_List.Count - 1);

            return true;
        }

        public bool Remove(T item)
        {
            int index = -1;
            if (!m_Dictionary.TryGetValue(item, out index))
                return false;

            RemoveAt(index);
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            m_List.Clear();
            m_Dictionary.Clear();
        }

        public bool Contains(T item)
        {
            return m_Dictionary.ContainsKey(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            m_List.CopyTo(array, arrayIndex);
        }

        public int Count { get { return m_List.Count; } }
        public bool IsReadOnly { get { return false; } }
        public int IndexOf(T item)
        {
            int index = -1;
            if (m_Dictionary.TryGetValue(item, out index))
                return index;
            return -1;
        }

        public void Insert(int index, T item)
        {
            //We could support this, but the semantics would be weird. Order is not guaranteed..
            throw new NotSupportedException("Random Insertion is semantically invalid, since this structure does not guarantee ordering.");
        }

        /// <summary>
        /// 快速移除
        /// 当该对象是最后一个是直接移除，如果不是最后一个跟最后一个位置交换，并移除最后一个的数据(目标移除位置)
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            T item = m_List[index];
            m_Dictionary.Remove(item);
            if (index == m_List.Count - 1)
                m_List.RemoveAt(index);
            else
            {
                int replaceItemIndex = m_List.Count - 1;
                T replaceItem = m_List[replaceItemIndex];
                m_List[index] = replaceItem;
                m_Dictionary[replaceItem] = index;
                m_List.RemoveAt(replaceItemIndex);
            }
        }

        public T this[int index]
        {
            get { return m_List[index]; }
            set
            {
                T item = m_List[index];
                m_Dictionary.Remove(item);
                m_List[index] = value;
                m_Dictionary.Add(item, index);
            }
        }

        public void RemoveAll(Predicate<T> match)
        {
            //I guess this could be optmized by instead of removing the items from the list immediatly,
            //We move them to the end, and then remove all in one go.
            //But I don't think this is going to be the bottleneck, so leaving as is for now.
            int i = 0;
            while (i < m_List.Count)
            {
                T item = m_List[i];
                if (match(item))
                    Remove(item);
                else
                    i++;
            }
        }

        //Sorts the internal list, this makes the exposed index accessor sorted as well.
        //But note that any insertion or deletion, can unorder the collection again.
        public void Sort(Comparison<T> sortLayoutFunction)
        {
            //There might be better ways to sort and keep the dictionary index up to date.
            m_List.Sort(sortLayoutFunction);
            //Rebuild the dictionary index.
            for (int i = 0; i < m_List.Count; ++i)
            {
                T item = m_List[i];
                m_Dictionary[item] = i;
            }
        }
    }
}
