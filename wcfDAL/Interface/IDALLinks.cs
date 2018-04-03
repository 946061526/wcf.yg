using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALLinks
    {
        /// <summary>
        /// 获取链接列表
        /// </summary>
        /// <param name="type">类别</param>
        /// <returns></returns>
        DataSet GetLinksInfoByType( int type );
    }
}
