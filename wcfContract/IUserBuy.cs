using System;
using System.Data;
using System.ServiceModel;

namespace wcfNSYGShop
{
    /// <summary>
    /// 云购记录相关接口
    /// </summary>
    public partial interface IWCFContract
    {
        #region 获取商品的某期的所有云购记录
        /// <summary>
        /// 获取商品的某期的所有云购记录
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <param name="FIdx">开始记录编号</param>
        /// <param name="EIdx">结束记录编号</param>
        /// <param name="sortType">排序方式：0倒序  1正序</param>
        /// <param name="isCount">是否统计总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserBuyListByBarcode( int codeID, int FIdx, int EIdx, int sortType, int isCount, out int totalCount );
        #endregion

        #region 获取一个时间段的前后N条记录
        /// <summary>
        /// 获取一个时间段的前后N条记录
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserBuyRecordsEndView( DateTime time );
        #endregion

        #region 会员中心 - 用户云购记录各状态(1-3)统计
        /// <summary>
        /// 会员中心 - 用户云购记录各状态(1-3)统计
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterUserBuyStateTotal( int userID );
        #endregion

        #region 会员中心-我的云购记录分页列表
        /// <summary>
        /// 会员中心-我的云购记录分页列表
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="state">状态</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="userID">会员ID</param>
        /// <param name="keyWords">关键字</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">返回总记录数</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterBuyList( int FIdx, int EIdx, int state, DateTime beginTime, DateTime endTime, int userID, string keyWords, int isCount, out int count );
        #endregion

        #region 会员中心-查询会员云购的商品详情
        /// <summary>
        /// 会员中心-查询会员云购的商品详情
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterUserBuyDetail( int userID, int codeID );
        #endregion

        #region 个人主页-获取会员最新云购记录
        /// <summary>
        /// 个人主页-获取会员最新云购记录
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserWebPageBuyList( int userID, int FIdx, int EIdx, int isCount, out int totalCount );
        #endregion

        #region 获取网站最新100条云购记录
        /// <summary>
        /// 获取网站最新100条云购记录
        /// </summary>
        /// <param name="buyID">buyID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserBuyRecentlyList( int buyID );
        #endregion

        #region 获取全站历史云购记录
        /// <summary>
        /// 获取全站历史云购记录
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUsersHistoryBuyRecords( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int isCount, out int count );
        #endregion

        #region 12条最新云购记录
        /// <summary>
        /// 12条最新云购记录
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserBuyLast();
        #endregion

        #region 中奖用户所有云购码列表12603
        /// <summary>
        /// 中奖用户所有云购码列表12603
        /// </summary>
        /// <param name="codeId"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserBuyRnoList( int codeId );
        #endregion

        #region 获取大于云购ID的云购信息
        /// <summary>
        /// 获取大于云购ID的云购信息
        /// </summary>
        /// <param name="buyid"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserBuyNewList( int buyid );
        #endregion

        #region 获取所有商品条码总售出份额
        /// <summary>
        /// 获取所有商品条码总售出份额
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Int64 GetBarcodeSalesTotal();
        #endregion

        #region 根据buyID获取相应的云购码
        /// <summary>
        /// 根据buyID获取相应的云购码
        /// </summary>
        /// <param name="codeID"></param>
        /// <param name="buyID"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserBuyCodeByBuyid( int codeID, int buyID );
        #endregion

        #region 获取会员某期商品的购买数量(商品列表页)
        /// <summary>
        /// 获取会员某期商品的购买数量(商品列表页)
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="codeID"></param>
        /// <returns></returns>
        [OperationContract]
        int GetUserBuyCountByCodeID( int userID, int codeID );
        #endregion

        #region 获取某用户某商品编号的详细云购记录(商品详细页)
        /// <summary>
        /// 获取某用户某商品编号的详细云购记录(商品详细页)
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="codeID"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserBuyListByCodeID( int userID, int codeID, int quantity );
        #endregion

        #region 获取会员退购记录
        /// <summary>
        /// 获取会员退购记录
        /// </summary>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="userid"></param>
        /// <param name="keyWords"></param>
        /// <param name="isCount"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterBuyRefund( int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int userid, string keyWords, int isCount, out int count );
        #endregion

        #region 会员中心-查询会员云购的商品所有云够码
        /// <summary>
        /// 会员中心-查询会员云购的商品所有云够码
        /// </summary>
        /// <param name="userid">会员ID</param>
        /// <param name="codeid">条码ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetMemberCenterUserBuyRno( int userid, int codeid );
        #endregion

        #region 90后天退购
        /// <summary>
        /// 90后天退购
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="buyIDs">购买ID</param>
        /// <returns></returns>
        [OperationContract]
        bool RefundUserBuyAfter90( int userID, string buyIDs );
        #endregion

        #region 返回商品指定范围内的历史期数列表
        /// <summary>
        /// 返回商品指定范围内的历史期数列表
        /// (小于等于当前期数列表)
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="codePeriod">当前期数</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetGoodsHistoryPeriod( int goodsID, int codePeriod );
        #endregion

        #region 获取离指定的云购码最接近的幸运云购码
        /// <summary>
        /// 获取离指定的云购码最接近的幸运云购码
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <param name="rnoNum">指定的云购码</param>
        /// <returns></returns>
        [OperationContract]
        int GetNearestRno( int codeID, int rnoNum );
        #endregion

        #region 获取开奖基数计算的100条记录
        /// <summary>
        /// 获取开奖基数计算的100条记录
        /// </summary>
        /// <param name="endTime">截止时间</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetRaffleDataByTime( DateTime endTime );
        #endregion

        #region 返回本周人气排行商品信息
        /// <summary>
        /// 返回本周人气排行商品信息
        /// </summary>
        /// <param name="quantity">获取数目</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserBuyForWeekRanking( int quantity );
        #endregion
    }
}
