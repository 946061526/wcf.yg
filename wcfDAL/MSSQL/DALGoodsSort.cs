using System.Data;

namespace wcfNSYGShop
{
    public class DALGoodsSort : DALBase, IDALGoodsSort
    {
        #region 回分类的上级目录层次，单反>相机>数码
        /// <summary>
        /// 回分类的上级目录层次，单反>相机>数码
        /// </summary>
        /// <param name="sortID">类别ID</param>
        /// <returns></returns>
        public DataSet GetSortSupPosition( int sortID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12809" );
            Para.AddOrcNewInParameter( "i_Sortid", sortID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_TotalSort.sp_getPreviousBySortID" );//pro_SortGetSupPosition
        }
        #endregion

        #region 返回二级分类列表（有商品上架的分类）
        /// <summary>
        /// 返回二级分类列表（有商品上架的分类）
        /// </summary>
        /// <returns></returns>
        public DataSet GetSortLevel2NaviList()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12805" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_TotalSort.sp_getSecChildSort" );//pro_SortGetLevel2NaviList
        }
        #endregion

        #region 获取某分类ID下的子分类列表
        /// <summary>
        /// 获取某分类ID下的子分类列表
        /// </summary>
        /// <param name="sortID">分类ID</param>
        /// <returns></returns>
        public DataSet GetChildSort( int sortID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12802" );
            Para.AddOrcNewInParameter( "i_Sortid", sortID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_TotalSort.sp_getNextSortBySortID" );//pro_SortGetChildList
        }
        #endregion

        #region 获取分类信息
        /// <summary>
        /// 获取分类信息
        /// </summary>
        /// <param name="sortID">分类ID</param>
        /// <returns>返回MDLGoodsSort实例，反之返回null</returns>
        public DataSet GetSortInfoByID( int sortID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12803" );
            Para.AddOrcNewInParameter( "i_Sortid", sortID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_TotalSort.sp_getSortBySortID" );//pro_SortGetInfoByID
        }
        #endregion
    }
}
