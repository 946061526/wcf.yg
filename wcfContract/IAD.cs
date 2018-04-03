using System.Data;
using System.ServiceModel;

namespace wcfNSYGShop
{
    /// <summary>
    /// 站点广告接口
    /// </summary>
    public partial interface IWCFContract
    {
        #region 根据分类ID获取可显示的广告列表10204
        /// <summary>
        /// 根据分类ID获取可显示的广告列表10204
        /// </summary>
        /// <param name="sortID">分类ID号</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetADListForPage( int sortID );
        #endregion
    }
}
