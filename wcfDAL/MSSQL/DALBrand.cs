using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALBrand : DALBase , IDALBrand
    {
        #region 获取某分类下的品牌列表
        /// <summary>
        /// 获取某分类下的品牌列表
        /// </summary>
        /// <param name="sortID"></param>
        /// <returns></returns>
        public DataSet GetBrandBySortID( int sortID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12203" );
            Para.AddOrcNewInParameter( "i_SortID", sortID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_PageForAny.sp_getGoodsOnSortBySortID" );//pro_PageForBrandListBySortID
        }
        #endregion
    }
}
