using System.Data;

namespace wcfNSYGShop
{
    public interface IDALGoodsSort
    {
        #region 回分类的上级目录层次，单反>相机>数码
        /// <summary>
        /// 回分类的上级目录层次，单反>相机>数码
        /// </summary>
        /// <param name="sortID">类别ID</param>
        /// <returns></returns>
        DataSet GetSortSupPosition( int sortID );
        #endregion

        #region 返回二级分类列表（有商品上架的分类）
        /// <summary>
        /// 返回二级分类列表（有商品上架的分类）
        /// </summary>
        /// <returns></returns>
        DataSet GetSortLevel2NaviList();
        #endregion

        #region 获取某分类ID下的子分类列表
        /// <summary>
        /// 获取某分类ID下的子分类列表
        /// </summary>
        /// <param name="sortID">分类ID</param>
        /// <returns></returns>
        DataSet GetChildSort( int sortID );
        #endregion

        #region 获取分类信息
        /// <summary>
        /// 获取分类信息
        /// </summary>
        /// <param name="sortID">分类ID</param>
        /// <returns>返回MDLGoodsSort实例，反之返回null</returns>
        DataSet GetSortInfoByID( int sortID );
        #endregion
    }
}
