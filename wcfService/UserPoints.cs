using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
    {
        #region 获取用户福分
        /// <summary>
        /// 获取用户福分
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public long GetUserPointsByUserId( int userId )
        {
            long _Points = 0L;
            if ( userId > 0 )
            {
                try
                {
                    IDALUserPoints _DAL = new DALUserPoints();
                    _Points = _DAL.GetUserPointsByUserId( userId );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserPoints.GetUserPointsByUserId抛出异常：" + ex.Message );
                }
            }
            return _Points;
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
        public bool UpdateUserPoints( int userID, int pointNum, int logType, DateTime logTime, int refrenceID, string logDesc )
        {
            bool _Result = false;
            try
            {
                IDALUserPoints _DAL = new DALUserPoints();
                _Result = _DAL.UpdateUserPoints( userID, pointNum, logType, logTime, refrenceID, logDesc ) > 0;
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UserPoints.UserPointsUpdatePoint抛出异常：" + ex.Message );
            }
            return _Result;
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
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 && FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALUserPoints _DAL = new DALUserPoints();
                    _DS = _DAL.GetUserPointsLogPageList( userID, FIdx, EIdx, beginTime, endTime, isCount, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserPoints.GetUserPointsLogPageList Exception:" + ex.Message );
                }
            }
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
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 && FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALUserPoints _DAL = new DALUserPoints();
                    _DS = _DAL.GetInvitedMemberInfoList(userID, FIdx, EIdx, startTime, endTime, isCount, out totalCount);
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserPoints.GetInvitedMemberInfoList Exception:" + ex.Message );
                }
            }
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
            DataSet _DS = null;
            count = 0;
            if ( userID > 0 && FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALUserPoints _DAL = new DALUserPoints();
                    _DS = _DAL.GetMemberCenterCommissionList( FIdx, EIdx, beginTime, endTime, userID, isCount, out count );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserPoints.GetMemberCenterCommissionList Exception:" + ex.Message );
                }
            }
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
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALUserPoints _DAL = new DALUserPoints();
                    _DS = _DAL.GetUserBrokerageSummary( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserPoints.GetUserBrokerageSummary Exception:" + ex.Message );
                }
            }
            return _DS;
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
            DataSet _DS = null;
            count = 0;
            if ( userID > 0 && FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALUserPoints _DAL = new DALUserPoints();
                    _DS = _DAL.GetMemberCenterMentionList( userID, FIdx, EIdx, beginTime, endTime, isCount, out count );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserPoints.GetMemberCenterMentionList Exception:" + ex.Message );
                }
            }
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
            int _Result = -3;
            if ( userID > 0 )
            {
                try
                {
                    IDALUserPoints _DAL = new DALUserPoints();
                    _Result = _DAL.ApplyUserBrokerageToBank( userID, money, serviceMoney, bankName, bankUser, bankDetail, bankAccount, userTel );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserPoints.ApplyUserBrokerageToBank Exception:" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 会员佣金直接充值
        /// <summary>
        /// 会员佣金直接充值
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="money">充值金额</param>
        /// <returns></returns>
        public bool ApplyUserBrokerageToAccount( int userID, decimal money )
        {
            bool _Flag = false;
            if ( userID > 0 && money > 0m )
            {
                try
                {
                    IDALUserPoints _DAL = new DALUserPoints();
                    _Flag = _DAL.ApplyUserBrokerageToAccount( userID, money ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserPoints.ApplyUserBrokerageToAccount Exception:" + ex.Message );
                }
            }
            return _Flag;
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
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALUserPoints _DAL = new DALUserPoints();
                    _DS = _DAL.GetUserBrokerageApplyLastest( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserPoints.GetUserBrokerageApplyLastest" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
    }
}
