using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALSiteCache 
    {
        #region 根据ID获取模板记录
        /// <summary>
        /// 根据ID获取模板记录
        /// </summary>
        /// <param name="siteID"></param>
        /// <returns></returns>
        DataSet GetSiteCacheByID( int siteID );
        #endregion
    }
}
