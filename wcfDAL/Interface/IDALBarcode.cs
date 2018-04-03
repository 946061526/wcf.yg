using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALBarcode
    {
        #region 获取已经开奖的商品条码信息
        /// <summary>
        /// 获取已经开奖的商品条码信息
        /// </summary>
        /// <param name="codeID">商品条码</param>
        /// <returns></returns>
        DataSet GetBarcodeRNOInfo( int codeID );
        #endregion

        #region 获取所有揭晓记录
        /// <summary>
        /// 获取所有揭晓记录
        /// </summary>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="sortID">商品类别ID</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="totalCount">总记录数，不返回则为0</param>
        /// <returns></returns>
        DataSet GetBarcodeRaffleList( int FIdx, int EIdx, int sortID, int isCount, out int totalCount );
        #endregion

        #region 手机版获得最新揭晓详情信息
        /// <summary>
        /// 手机版获得最新揭晓详情信息
        /// </summary>
        /// <param name="codeId">条码ID</param>
        /// <param name="retVal">1正常，-1本条码为正在进行中的状态</param>
        /// <returns></returns>
        DataSet appGetRaffleBaseInfo( int codeId, out int retVal );
        /// <summary>
        /// 手机版获得最新揭晓详情信息
        /// </summary>
        /// <param name="codeId">条码ID</param>
        /// <param name="retVal">1正常，-1本条码为正在进行中的状态</param>
        /// <returns></returns>
        DataSet mGetRaffleBaseInfo( int codeId, out int retVal );
        #endregion

        #region 返回条码的揭晓时间
        /// <summary>
        /// 返回条码的揭晓时间
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        DateTime GetCodeRTime( int codeID );
        #endregion

        #region 获取商品条码信息
        /// <summary>
        /// 获取商品条码信息
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <param name="useDG">是否通过DG库查询,true:DG查询</param>
        /// <returns></returns>
        DataSet GetBarcodeInfoByID( int codeID, bool useDG );
        #endregion

        #region 手机版计算结果页：中奖条码揭晓信息
        /// <summary>
        /// 手机版计算结果页：中奖条码揭晓信息
        /// </summary>
        /// <param name="codeID"></param>
        /// <returns></returns>
        DataSet mGetBarcodeLotteryInfo( int codeID );
        #endregion

        #region 获得最新揭晓详情信息
        /// <summary>
        /// 获得最新揭晓详情信息
        /// </summary>
        /// <param name="codeId"></param>
        /// <param name="retVal">1:正常;-1:本条码非揭晓状态;-2 没有进行中的期数</param>
        /// <returns></returns>
        DataSet GetRaffleBaseInfo( int codeId, out int retVal );
        #endregion

        #region 获取符合指定时间前的等待开奖的条码列表
        /// <summary>
        /// 获取符合指定时间前的等待开奖的条码列表
        /// </summary>
        /// <param name="timeSpan">揭晓时间间隔</param>
        /// <returns></returns>
        DataSet GetWaitLotteryList( int timeSpan );
        #endregion

        #region 更新定时揭晓商品期数的状态
        /// <summary>
        /// 更新定时揭晓商品期数的状态
        /// </summary>
        /// <returns></returns>
        bool UpdateBarcodeStateForAutoRTime();
        #endregion

        #region 限购模块

        /// <summary>
        /// 获取限购商品最新揭晓记录
        /// </summary>
        /// <param name="quantity">获取数量</param>
        /// <param name="lastTime">上一次读取时间</param>
        /// <returns></returns>
        DataSet GetLimitBuyNewLotteryNote( int quantity, DateTime lastTime );

        /// <summary>
        /// 检测用户对于某期限购商品的购买情况
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="codeID">期数ID</param>
        /// <returns>
        /// 返回表记录：
        ///     空表：异常；
        ///     有行：codeID:-1 本期已满员，〉0正常(字段：codeID，codeLimitBuy[限购人次]，buyNum[已购人次]，codeState[期数状态]，codeRemainNum[期数剩余人次])
        /// </returns>
        DataSet CheckLimitBuyForUser( int userID, int codeID );

        #endregion

        #region 获取商品条码的介绍详情【房产】
        /// <summary>
        /// 获取商品条码的介绍详情【房产】
        /// </summary>
        /// <param name="codeID">期数ID</param>
        /// <returns></returns>
        DataSet GetBarcodeDescByCodeID( int codeID );
        #endregion

        #region 更改商品条码揭晓状态并返回结果集[1分钟计算，3分钟揭晓]
        /// <summary>
        /// 更改商品条码揭晓状态并返回结果集[1分钟计算，3分钟揭晓]
        /// </summary>
        /// <returns></returns>
        DataSet GetBarcodeLotteryList();
        #endregion

        //===========ERP Start===========
        #region 添加一定期数的条码10413
        /// <summary>
        /// 添加一定期数的条码
        /// </summary>
        /// <param name="goodsID"></param>
        /// <param name="codePrice"></param>
        /// <param name="codeQuantity"></param>
        /// <param name="codeLimitBuyNum"></param>
        /// <param name="codeCount"></param>
        /// <param name="applyID"></param>
        /// <param name="applyNum"></param>
        /// <param name="executant"></param>
        /// <returns></returns>
        int InsertBarcodeByGoodsID( int goodsID, decimal codePrice, int codeQuantity, int codeLimitBuyNum, int codeCount, int applyID, int applyNum, string executant );

        #endregion

        #region 批量删除商品的条码
        /// <summary>
        /// 批量删除商品的条码
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="codeCount">批量删除数目</param>
        /// <returns></returns>
        int DeleteBarcodeByGoodsID( int goodsID, int codeCount, string executant );
        #endregion

        #region 分页获取商品所有期数列表（可按期数状态筛选）
        /// <summary>
        /// 分页获取商品所有期数列表（可按期数状态筛选）
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="state">状态：－10全部，－1未售卖，1进行中，2已满员，3已揭晓</param>
        /// <param name="FIdx">起始编号</param>
        /// <param name="EIdx">结束编号</param>
        /// <param name="IsCount">是否统计总数</param>
        /// <param name="totalCount">输出总记录数</param>
        /// <returns></returns>
        DataSet GetGoodsBarcodePageList( int goodsID, int state, int FIdx, int EIdx, int IsCount, out int totalCount );
        #endregion

        #region 获取商品条码剩余期数数目
        /// <summary>
        /// 获取商品条码剩余期数数目
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <returns></returns>
        int GetRemainPeriodCountByGoodsID( int goodsID );
        #endregion

        #region 修改特殊类商品的条码详情
        /// <summary>
        /// 修改特殊类商品的条码详情
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <param name="goodsName">条码商品名称</param>
        /// <param name="barAttachName">条码附加标题</param>
        /// <param name="barGoodsAllPic">条码商品详情里的所有图片名称，英文逗号隔开</param>
        /// <param name="barGoodsDescription">条码商品详情</param>
        /// <returns></returns>
        int UpdateBarGoodsDescByCodeID( int codeID, string goodsName, string barAttachName, string barGoodsAllPic, string barGoodsDescription );
        #endregion

        #region 根据上架商品ID调整未出售的条码价格
        /// <summary>
        /// 根据上架商品ID调整未出售的条码价格
        /// </summary>
        /// <param name="goodsID">商品ID</param>
        /// <param name="salePrice">价值</param>
        /// <param name="codeQuantity">总需参与人次</param>
        /// <param name="executant">操作者</param>
        /// <returns></returns>
        int UpdateBarcodePriceByGoodsID( int goodsID, decimal salePrice, int codeQuantity, string executant );
        #endregion

        #region 根据条码ID查询房产的详情描述信息
        /// <summary>
        /// 根据条码ID查询房产的详情描述信息
        /// </summary>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        DataSet GetHouseInfoByCodeID( int codeID );
        #endregion

        //===========ERP End=============
    }
}
