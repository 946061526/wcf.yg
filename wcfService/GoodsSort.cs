using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
    {
        #region 回分类的上级目录层次，单反>相机>数码
        /// <summary>
        /// 回分类的上级目录层次，单反>相机>数码
        /// </summary>
        /// <param name="sortID">类别ID</param>
        /// <returns></returns>
        public DataSet GetSortSupPosition( int sortID )
        {
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

        #region 返回二级分类列表（有商品上架的分类）
        /// <summary>
        /// 返回二级分类列表（有商品上架的分类）
        /// </summary>
        /// <returns></returns>
        public DataSet GetSortLevel2NaviList()
        {
            DataSet _DS = null;
            try
            {
                IDALGoodsSort _DAL = new DALGoodsSort();
                _DS = _DAL.GetSortLevel2NaviList();
                _DAL = null;
            }
            catch( Exception ex ) {
                UtilityFile.AddLogErrMsg( "" + ex.Message );
            }
            return _DS;
        }
        #endregion
    }
}
