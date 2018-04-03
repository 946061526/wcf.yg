using System;
using System.Data;
using System.ServiceModel;

namespace wcfNSYGShop
{
    public partial interface IWCFContract
    {
        #region 获取新闻信息
        /// <summary>
        /// 获取新闻信息
        /// </summary>
        /// <param name="newsID">新闻ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetNewsInfoByID( int newsID );
        #endregion
    }
}
