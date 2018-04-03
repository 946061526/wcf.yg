using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALQQ : DALBase, IDALQQ
    {
        /// <summary>
        /// 获取QQ群帐号置顶列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetQQAccountTopList()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12504" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_QQAccount.sp_getQQAccountTopList" );//pro_QQAccountTopList
        }

        /// <summary>
        /// 获取QQ群帐号列表
        /// </summary>
        /// <param name="areaID">区域</param>
        /// <param name="key">查询关键字</param>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public DataSet GetQQAccountPageList( int areaID, string key, int FIdx, int EIdx, bool isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12503" );
            Para.AddOrcNewInParameter( "i_areaid", areaID );
            Para.AddOrcNewInParameter( "i_key", key );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount ? 1 : 0 );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_QQAccount.sp_getQQPageListByAreaID" );//pro_QQAccountPageList
            totalCount = GetOrcTotalCount( isCount ? 1 : 0, _DS );
            return _DS;
        }
    }
}
