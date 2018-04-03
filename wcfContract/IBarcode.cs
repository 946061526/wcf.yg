using System;
using System.Data;
using System.ServiceModel;

namespace wcfNSYGShop
{
    /// <summary>
    /// 商品期数相关接口
    /// </summary>
    public partial interface IWCFContract
    {
        #region 获取已经开奖的商品条码信息10404
        /// <summary>
        /// 获取已经开奖的商品条码信息10404
        /// </summary>
        /// <param name="codeID"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetBarcodeRNOInfo( int codeID ); 
        #endregion

        #region 获取所有揭晓记录
        /// <summary>
        /// 获取所有揭晓记录
        /// </summary>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="totalCount">总记录数，不返回则为0</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetBarcodeRaffleList( int FIdx, int EIdx, int isCount, out int totalCount );
        /// <summary>
        /// 获取所有揭晓记录1220101
        /// </summary>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="sortID">商品类别ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="totalCount">总记录数，不返回则为0</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetBarcodeRaffleListEx( int FIdx, int EIdx, int sortID, int isCount, out int totalCount );
        #endregion

        #region 手机版获得最新揭晓详情信息10303
        /// <summary>
        /// 手机版获得最新揭晓详情信息10303
        /// </summary>
        /// <param name="codeId">条码ID</param>
        /// <param name="retVal">1正常，-1本条码为正在进行中的状态</param>
        /// <returns></returns>
        [OperationContract]
        DataSet appGetRaffleBaseInfo( int codeId, out int retVal );
        /// <summary>
        /// 手机版获得最新揭晓详情信息
        /// </summary>
        /// <param name="codeId">条码ID</param>
        /// <param name="retVal">1正常，-1本条码为正在进行中的状态</param>
        /// <returns></returns>
        [OperationContract]
        DataSet mGetRaffleBaseInfo( int codeId, out int retVal );
        #endregion

        #region 返回条码的揭晓时间
        /// <summary>
        /// 返回条码的揭晓时间
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        [OperationContract]
        DateTime GetCodeRTime( int codeID );
        #endregion

        #region 获取商品条码信息
        /// <summary>
        /// 获取商品条码信息
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetBarcodeInfoByID( int codeID );
        #endregion

        #region 手机版计算结果页：中奖条码揭晓信息
        /// <summary>
        /// 手机版计算结果页：中奖条码揭晓信息
        /// </summary>
        /// <param name="codeID"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet mGetBarcodeLotteryInfo( int codeID );
        #endregion

        #region 获得最新揭晓详情信息
        /// <summary>
        /// 获得最新揭晓详情信息
        /// </summary>
        /// <param name="codeId"></param>
        /// <param name="retVal">1:正常;-1:本条码非揭晓状态;-2 没有进行中的期数</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetRaffleBaseInfo( int codeId, out int retVal );
        #endregion

        #region 获取符合指定时间前的等待开奖的条码列表
        /// <summary>
        /// 获取符合指定时间前的等待开奖的条码列表
        /// </summary>
        /// <param name="timeSpan">揭晓时间间隔</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetWaitLotteryList( int timeSpan );
        #endregion

        #region 更新定时揭晓商品期数的状态
        /// <summary>
        /// 更新定时揭晓商品期数的状态
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool UpdateBarcodeStateForAutoRTime();
        #endregion

        #region 限购模块

        /// <summary>
        /// 获取限购商品最新揭晓记录
        /// </summary>
        /// <param name="quantity">获取数量</param>
        /// <param name="lastTime">上一次读取时间</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetLimitBuyNewLotteryNote( int quantity, DateTime lastTime );

        /// <summary>
        /// 检测用户对于某期限购商品的购买情况
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="codeID">期数ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet CheckLimitBuyForUser( int userID, int codeID );

        #endregion
    }
}
