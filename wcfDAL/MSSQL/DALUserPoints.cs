using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALUserPoints : DALBase, IDALUserPoints
    {
        #region 获取用户福分
        /// <summary>
        /// 获取用户福分
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public long GetUserPointsByUserId( int userId )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12944" );
            Para.AddOrcNewInParameter( "i_userid", userId );
            Para.AddOrcNewCursorParameter( "o_result" );
            string _Result = Dal.ExecuteString( "yun_UserBehaver.sp_getUserPointByUserID" );//pro_UserPointsGetPointByUserID
            return ToInt64( _Result );
        }
        #endregion

        #region 更新用户福分\日志
        /// <summary>
        /// 更新用户福分\日志
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="pointNum">福分值</param>
        /// <param name="logType">福分日志类型</param>
        /// <param name="logTime">记录日志时间</param>
        /// <param name="refrenceID">福分来源ID</param>
        /// <param name="logDesc">日志描述</param>
        /// <returns></returns>
        public int UpdateUserPoints( int userID, int pointNum, int logType, DateTime logTime, int refrenceID, string logDesc )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12947" );
            Para.AddOrcNewInParameter( "i_logUserID", userID );
            Para.AddOrcNewInParameter( "i_logPointNum", pointNum );
            Para.AddOrcNewInParameter( "i_logType", logType );
            Para.AddOrcNewInParameter( "i_logTime", logTime );
            Para.AddOrcNewInParameter( "i_logRefrenceID", refrenceID );
            Para.AddOrcNewInParameter( "i_logDescript", logDesc );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_modUserPointsByUserID" );//pro_UserPointsUpdatePoint
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 用户福分详细信息列表
        /// <summary>
        /// 用户福分详细信息列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">截止序号</param>
        /// <param name="IsCount">是否返回总记录数 0：不返回，1：返回</param>
        /// <returns></returns>
        public DataSet GetUserPointsLogPageList( int userID, int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12945" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_starttime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_UserBehaver.sp_getUserPointLogByUserID" );//pro_UserPointsLogPageList
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region 成功邀请会员列表
        /// <summary>
        /// 成功邀请会员列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始编号</param>
        /// <param name="EIdx">截至编号</param>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">截至时间</param>
        /// <param name="isCount">是否返回总数据行 0:否，1:返回</param>
        /// <param name="totalCount">总行数</param>
        /// <returns></returns>
        public DataSet GetInvitedMemberInfoList(int userID, int FIdx, int EIdx, DateTime startTime, DateTime endTime, int isCount, out int totalCount)
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11733" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_startTime", startTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            Para.AddOrcNewCursorParameter("o_result_stat");
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getInviteInfoByUserid" );
            totalCount = GetOrcTotalCount( isCount, _DS );//总记录数
            return _DS;
        }
        #endregion

        #region 会员中心-获取佣金明细列表
        /// <summary>
        /// 会员中心-获取佣金明细列表
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userID">会员ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        public DataSet GetMemberCenterCommissionList( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int userID, int isCount, out int count )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12908" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_starttime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_UserBehaver.sp_getBrokerLogPageByUserID" );//pro_UserBrokerageLogPageList
            count = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region 获取用户佣金总收入与总提取
        /// <summary>
        /// 获取用户佣金总收入与总提取
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public DataSet GetUserBrokerageSummary( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12909" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_UserBehaver.sp_getSomeStatInfoByUserID" );//pro_UserBrokerageSummary
        }
        #endregion

        #region 获取会员佣金提现列表记录
        /// <summary>
        /// 获取会员佣金提现列表记录
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="isCount"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public DataSet GetMemberCenterMentionList( int userID, int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int isCount, out int count )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12905" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_starttime", beginTime );
            Para.AddOrcNewInParameter( "i_endTime", endTime );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_UserBehaver.sp_getBrokeragePageByUserID" );//pro_UserBrokerageApplyPageList
            count = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region 会员佣金提现申请
        /// <summary>
        /// 会员佣金提现申请
        /// 1成功，-1不足100，-2执行失败
        /// </summary>
        /// <param name="userID">申请者</param>
        /// <param name="money">提现金额</param>
        /// <param name="serviceMoney">手续费</param>
        /// <param name="bankName">银行名称</param>
        /// <param name="bankUser">开户者</param>
        /// <param name="bankDetail">开户支行</param>
        /// <param name="BankAccount">开户账号</param>
        /// <param name="userTelePho">联系电话</param>
        /// <returns></returns>
        public int ApplyUserBrokerageToBank( int userID, decimal money, decimal serviceMoney, string bankName, string bankUser, string bankDetail, string bankAccount, string userTel )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12907" );
            Para.AddOrcNewInParameter( "i_applyUserID", userID );
            Para.AddOrcNewInParameter( "i_applyFetchMoney", money );
            Para.AddOrcNewInParameter( "i_applyServiceMoney", serviceMoney );
            Para.AddOrcNewInParameter( "i_applyBankName", bankName );
            Para.AddOrcNewInParameter( "i_applyBankUser", bankUser );
            Para.AddOrcNewInParameter( "i_applyBankDetail", bankDetail );
            Para.AddOrcNewInParameter( "i_applyBankAccount", bankAccount );
            Para.AddOrcNewInParameter( "i_applyUserTelePho", userTel );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_modApplyBroToAccount" );//pro_UserBrokerageApplyToBank
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;//1成功，-1不足100
        }
        #endregion

        #region 会员佣金直接充值
        /// <summary>
        /// 会员佣金直接充值
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="money">充值金额</param>
        /// <returns></returns>
        public int ApplyUserBrokerageToAccount( int userID, decimal money )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12906" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_fetchMoney", money );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_modBroderageToAccount" );//pro_UserBrokerageApplyToAccount
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;//1成功，-1失败
        }
        #endregion

        #region 获取用户最近一条佣金提现申请记录
        /// <summary>
        /// 获取用户最近一条佣金提现申请记录
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetUserBrokerageApplyLastest( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12904" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_UserBehaver.sp_getOneBrokerageByUserID" );//pro_UserBrokerageApplyGetLastByUserID
        }
        #endregion

        #region 根据申请ID获取某条佣金提现记录
        /// <summary>
        /// 根据申请ID获取某条佣金提现记录
        /// </summary>
        /// <param name="applyID">申请ID</param>
        /// <returns></returns>
        public DataSet GetBrokerInfoByApplyID( int applyID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "13114" );
            Para.AddOrcNewInParameter( "i_apllyid", applyID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_WXAuto.sp_getbrokerInfoByapplyid" );
        }
        #endregion
    }
}
