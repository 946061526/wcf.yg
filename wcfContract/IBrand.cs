using System;
using System.Data;
using System.ServiceModel;

namespace wcfNSYGShop
{
    public partial interface IWCFContract
    {
        #region 获取某分类下的品牌列表
        /// <summary>
        /// 获取某分类下的品牌列表
        /// </summary>
        /// <param name="sortID"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetBrandBySortID( int sortID );
        #endregion
    }
}
