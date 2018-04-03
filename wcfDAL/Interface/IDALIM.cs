using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALIM : IDisposable
    {
        #region 获取所有IM服务器的IP记录
        /// <summary>
        /// 获取所有IM服务器的IP记录
        /// </summary>
        /// <returns></returns>
        DataSet GetIMServerIPTable();
        #endregion
    }
}
