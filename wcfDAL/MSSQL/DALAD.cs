using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALAD : DALBase, IDALAD
    {
        /// <summary>
        /// 根据分类ID获取可显示的广告列表
        /// </summary>
        /// <param name="sortID">分类ID号</param>
        /// <returns></returns>
        public DataSet GetADListForPage( int sortID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10204" );
            Para.AddOrcNewInParameter( "i_sortid", sortID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Advertise.sp_getADInfoByisShow" );//pro_ADGetListForPage
        }
    }
}
