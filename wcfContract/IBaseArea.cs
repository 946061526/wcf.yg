using System.Data;
using System.ServiceModel;

namespace wcfNSYGShop
{
    /// <summary>
    /// 配送区域相关接口
    /// </summary>
    public partial interface IWCFContract
    {
        #region 获取某区域ID下的子区域列表
        /// <summary>
        /// 获取某区域ID下的子区域列表
        /// </summary>
        /// <param name="sortID">区域ID(取省份时传值为1)</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetChildAreaByID( int areaID );
        #endregion
    }
}
