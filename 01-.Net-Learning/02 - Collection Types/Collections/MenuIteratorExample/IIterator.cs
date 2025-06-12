using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CollectionsBasic.MenuIteratorExample
{
    #region 6.3 迭代器
    //如果我们的列表 不管是什么类型 都实现下面的接口模式 那就有一个统一的访问方式
    public interface IIterator<T> //IEnumerator
    {
        /// <summary>
        /// 返回当前对象
        /// </summary>
        T Current { get; }
        /// <summary>
        /// 能否定位到下一个对象
        /// </summary>
        /// <returns></returns>
        bool MoveNext();
        /// <summary>
        /// 重置
        /// </summary>
        void Reset();
    }
    #endregion
}
