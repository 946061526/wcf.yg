using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALBaseArea : DALBase, IDALBaseArea
    {
        #region 获取某区域ID下的子区域列表
        /// <summary>
        /// 获取某区域ID下的子区域列表
        /// </summary>
        /// <param name="sortID">区域ID</param>
        /// <returns></returns>
        public DataSet GetChildAreaByID( int areaID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10507" );
            Para.AddOrcNewInParameter( "i_areaid", areaID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_basearea.sp_getChildTypeByAreaid" );//pro_GetAreaChildList
        }
        #endregion
    }
}
