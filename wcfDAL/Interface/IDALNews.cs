using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALNews
    {
        /// <summary>
        /// 获取新闻信息
        /// </summary>
        /// <param name="newsID">新闻ID</param>
        /// <returns></returns>
        DataSet GetNewsInfoByID( int newsID );
    }
}
