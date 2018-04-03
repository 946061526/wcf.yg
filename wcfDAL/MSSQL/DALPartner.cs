using System.Data;

namespace wcfNSYGShop
{
    public class DALPartner : DALBase, IDALPartner
    {
        #region IDisposable 成员

        public void Dispose()
        {

        }

        #endregion

        #region 添加网吧信息
        /// <summary>
        /// 添加网吧信息
        /// </summary>
        /// <param name="inviteUserID">邀请者ID</param>
        /// <param name="barNO">网吧标识</param>
        /// <param name="barName">网吧名称</param>
        /// <param name="barMemo">网吧备注</param>
        /// <param name="inviteUrl">邀请链接</param>
        /// <returns></returns>
        public int InsertBarInfo( int inviteUserID, string barNO, string barName, string barMemo, string inviteUrl )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "15001" );
            Para.AddOrcNewInParameter( "i_Invituserid", inviteUserID );
            Para.AddOrcNewInParameter( "i_barNO", barNO );
            Para.AddOrcNewInParameter( "i_barName", barName );
            Para.AddOrcNewInParameter( "i_barMemo", barMemo );
            Para.AddOrcNewInParameter( "i_invitlink", inviteUrl );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_InterNetBar.f_addInterNetBar" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion

        #region 修改网吧信息
        /// <summary>
        /// 修改网吧信息
        /// </summary>
        /// <param name="barID">记录ID</param>
        /// <param name="barNO">网吧标识</param>
        /// <param name="barName">网吧名称</param>
        /// <param name="barMemo">网吧备注</param>
        /// <param name="inviteUrl">邀请链接</param>
        /// <returns></returns>
        public int UpdateBarInfo( int barID, string barNO, string barName, string barMemo, string inviteUrl )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "15002" );
            Para.AddOrcNewInParameter( "i_barID", barID );
            Para.AddOrcNewInParameter( "i_barNO", barNO );
            Para.AddOrcNewInParameter( "i_barName", barName );
            Para.AddOrcNewInParameter( "i_barMemo", barMemo );
            Para.AddOrcNewInParameter( "i_invitlink", inviteUrl );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_InterNetBar.f_modNetBarInfoByBarID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion

        #region 添加网吧邀请用户的关系数据
        /// <summary>
        /// 添加网吧邀请用户的关系数据
        /// </summary>
        /// <param name="barNO">网吧标识</param>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public int InsertBarInviteUser( string barNO, int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "15005" );
            Para.AddOrcNewInParameter( "i_barNO", barNO );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_InterNetBar.f_addNetBarIVTUsers" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion

        #region 分页获取网吧信息列表
        /// <summary>
        /// 分页获取网吧信息列表
        /// </summary>
        /// <param name="barNO">网吧标识</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <returns></returns>
        public DataSet GetBarInfoPageList( string barNO, int FIdx, int EIdx, int isCount, out int totalCount, out int totalPerson )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "15004" );
            Para.AddOrcNewInParameter( "i_barNO", barNO );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_InterNetBar.sp_getNetBarPage" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            totalPerson = GetOrcTotalCount( isCount, _DS, "totalPerson" );
            return _DS;
        }
        #endregion

    }
}
