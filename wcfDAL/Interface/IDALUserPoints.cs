using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALUserPoints
    {
        #region 获取用户福分
        /// <summary>
        /// 获取用户福分
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        long GetUserPointsByUserId( int userId );
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
        int UpdateUserPoints( int userID, int pointNum, int logType, DateTime logTime, int refrenceID, string logDesc );
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
        DataSet GetUserPointsLogPageList( int userID, int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int isCount, out int totalCount );
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
        DataSet GetInvitedMemberInfoList(int userID, int FIdx, int EIdx, DateTime startTime, DateTime endTime, int isCount, out int totalCount);
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
        DataSet GetMemberCenterCommissionList( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int userID, int isCount, out int count );
        #endregion

        #region 获取用户佣金总收入与总提取
        /// <summary>
        /// 获取用户佣金总收入与总提取
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        DataSet GetUserBrokerageSummary( int userID );
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
        DataSet GetMemberCenterMentionList( int userID, int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int isCount, out int count );
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
        int ApplyUserBrokerageToBank( int userID, decimal money, decimal serviceMoney, string bankName, string bankUser, string bankDetail, string bankAccount, string userTel );
        #endregion

        #region 会员佣金直接充值
        /// <summary>
        /// 会员佣金直接充值
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="money">充值金额</param>
        /// <returns></returns>
        int ApplyUserBrokerageToAccount( int userID, decimal money );
        #endregion

        #region 获取用户最近一条佣金提现申请记录
        /// <summary>
        /// 获取用户最近一条佣金提现申请记录
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        DataSet GetUserBrokerageApplyLastest( int userID );
        #endregion

        #region 根据申请ID获取某条佣金提现记录
        /// <summary>
        /// 根据申请ID获取某条佣金提现记录
        /// </summary>
        /// <param name="applyID">申请ID</param>
        /// <returns></returns>
        DataSet GetBrokerInfoByApplyID( int applyID );
        #endregion
    }
}
