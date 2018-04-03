using System;
using System.Data;
using System.ServiceModel;

namespace wcfNSYGShop
{
    public partial interface IWCFContract
    {
        #region 获取链接列表
        /// <summary>
        /// 获取链接列表
        /// </summary>
        /// <param name="type">类别</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetLinksInfoByType( int type );
        #endregion
    }
}
