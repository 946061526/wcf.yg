using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 返回二级分类列表（有商品上架的分类）12805
        /// <summary>
        /// 返回二级分类列表（有商品上架的分类）12805
        /// </summary>
        /// <returns></returns>
        public static DataSet GetSortLevel2NaviList()
        {
            DataSet _DS = null;
            try
            {
                IDALGoodsSort _DAL = new DALGoodsSort();
                _DS = _DAL.GetSortLevel2NaviList();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 回分类的上级目录层次，单反>相机>数码12809
        /// <summary>
        /// 回分类的上级目录层次，单反>相机>数码12809
        /// </summary>
        /// <param name="sortID">类别ID</param>
        /// <returns></returns>
        public static DataSet GetSortSupPosition( params object[] para )
        {
            int sortID = (int)para[0];
            DataSet _DS = null;
            try
            {
                IDALGoodsSort _DAL = new DALGoodsSort();
                _DS = _DAL.GetSortSupPosition( sortID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GoodsSort.GetSortSupPosition Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 获取某分类ID下的子分类列表12802
        /// <summary>
        /// 获取某分类ID下的子分类列表
        /// </summary>
        /// <param name="sortID">分类ID</param>
        /// <returns></returns>
        public static DataSet GetChildSort( object[] para )
        {
            DataSet _DS = null;
            try
            {
                int _SortID = (int)para[0];
                IDALGoodsSort _DAL = new DALGoodsSort();
                _DS = _DAL.GetChildSort( _SortID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogMsg( "GoodsSort.GetChildSort Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 获取分类信息12803
        /// <summary>
        /// 获取分类信息
        /// </summary>
        /// <param name="sortID">分类ID</param>
        /// <returns>返回MDLGoodsSort实例，反之返回null</returns>
        public static DataSet GetSortInfoByID( object[] para )
        {
            DataSet _DS = null;
            try
            {
                int _SortID = (int)para[0];
                IDALGoodsSort _DAL = new DALGoodsSort();
                _DS = _DAL.GetSortInfoByID( _SortID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogMsg( "GoodsSort.GetSortInfoByID Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
    }
}
