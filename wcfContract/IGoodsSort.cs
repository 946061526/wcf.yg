using System.Data;
using System.ServiceModel;

namespace wcfNSYGShop
{
    public partial interface IWCFContract
    {
        #region 回分类的上级目录层次，单反>相机>数码
        /// <summary>
        /// 回分类的上级目录层次，单反>相机>数码
        /// </summary>
        /// <param name="sortID">类别ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetSortSupPosition( int sortID );
        #endregion

        #region 返回二级分类列表（有商品上架的分类）
        /// <summary>
        /// 返回二级分类列表（有商品上架的分类）
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DataSet GetSortLevel2NaviList();
        #endregion
    }
}
