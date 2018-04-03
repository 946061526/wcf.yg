using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALAD
    {
        /// <summary>
        /// 根据分类ID获取可显示的广告列表
        /// </summary>
        /// <param name="sortID">分类ID号</param>
        /// <returns></returns>
        DataSet GetADListForPage( int sortID );
    }
}
