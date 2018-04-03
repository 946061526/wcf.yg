using System;
using System.Data;
using System.ServiceModel;

namespace wcfNSYGShop
{
    /// <summary>
    /// 网站缓存相关操作接口
    /// </summary>
    public partial interface IWCFContract
    {
        #region 根据ID获取模板记录
        /// <summary>
        /// 根据ID获取模板记录
        /// </summary>
        /// <param name="siteID"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetSiteCacheByID( int siteID );
        #endregion
    }
}
