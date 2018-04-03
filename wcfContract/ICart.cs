using System;
using System.Data;
using System.ServiceModel;

namespace wcfNSYGShop
{
    /// <summary>
    /// 购物车相关接口
    /// </summary>
    public partial interface IWCFContract
    {
        #region 添加购物车
        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="shopUserID">用户ID</param>
        /// <param name="shopCodeID">商品条码ID</param>
        /// <param name="shopNum">云购人次</param>
        /// <param name="shopState">云购状态，0为选中</param>
        /// <param name="shopTime">添加时间</param>
        /// <returns></returns>
        [OperationContract]
        bool InsertCart( int shopUserID, int shopCodeID, int shopNum, int shopState, DateTime shopTime );

        /// <summary>
        /// 批量添加购物车
        /// </summary>
        /// <param name="shopUserID">用户ID</param>
        /// <param name="shopCodeIDStr">商品条码ID</param>
        /// <param name="shopNumStr">云购人次</param>
        /// <param name="shopStateStr">云购状态，0为选中</param>
        /// <param name="shopTime">添加时间</param>
        /// <returns></returns>
        [OperationContract]
        int InsertCartEx( int shopUserID, string shopCodeIDStr, string shopNumStr, string shopStateStr, DateTime shopTime );

        #endregion

        #region 添加购物车--2014.12改版
        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="shopUserID">用户ID</param>
        /// <param name="shopCodeID">商品条码ID</param>
        /// <param name="shopNum">云购人次</param>
        /// <param name="shopState">云购状态，0为选中</param>
        /// <param name="shopTime">添加时间</param>
        /// <returns></returns>
        [OperationContract]
        int InsertToCart( int shopUserID, string shopCodeIDStr, string shopNumStr, string shopStateStr, DateTime shopTime );
        #endregion

        #region 获取当前用户的购物车信息
        /// <summary>
        /// 获取当前用户的购物车信息
        /// 已过滤结束状态的商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetCartListByUserID( int userID );
        #endregion

        #region 获取用户某个条码的购物车信息
        /// <summary>
        /// 获取用户某个条码的购物车信息
        /// </summary>
        /// <param name="userID">当前用户ID</param>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetCartInfo( int userID, int codeID );
        #endregion

        #region 根据购物车ID删除购物车信息
        /// <summary>
        /// 根据购物车ID删除购物车信息
        /// </summary>
        /// <param name="shopIdStr">购物车ID串</param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteCartByIdStr( string shopIdStr );
        #endregion

        #region 修改购物车记录
        /// <summary>
        /// 修改购物车记录
        /// </summary>
        /// <param name="shopID">购物车ID</param>
        /// <param name="shopNum">购买人次</param>
        /// <param name="shopState">状态，默认0</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdataCartInfoByID( int shopID, int shopNum, int shopState );
        #endregion

        #region 删除当前用户的购物车信息
        /// <summary>
        /// 删除当前用户的购物车信息
        /// </summary>
        /// <param name="userID">当前用户ID</param>
        /// <returns>成功：1，失败：0</returns>
        [OperationContract]
        int DeleteCartByUserID( int userID );
        #endregion

        #region 批量更新会员购物车记录的状态
        /// <summary>
        /// 批量更新会员购物车记录的状态
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="shopState"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateCartStateBatch( int userID, int shopState );
        #endregion

        #region 获取用户购物车列表
        /// <summary>
        /// 获取用户购物车列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUserCartGoodsList( int userID );
        #endregion

        #region 判断条码是否已失效并获取其正在进行的期数
        /// <summary>
        /// 判断条码是否已失效并获取其正在进行的期数
        /// </summary>
        /// <param name="codeIDStr">条码ＩＤ串</param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetUnuseGoodsNextPeriod( string codeIDStr );
        #endregion

        #region 根据商品条码串删除用户购物车中的商品
        /// <summary>
        /// 根据商品条码串删除购物车中的商品
        /// </summary>
        /// <param name="userID">用户ＩＤ</param>
        /// <param name="codeIDStr">条码ＩＤ串</param>
        /// <returns></returns>
        [OperationContract]
        int DeleteCartByCodeIDStr( int userID, string codeIDStr );
        #endregion

        #region 检测用户支付时是否需要使用支付密码
        /// <summary>
        /// 检测用户支付时是否需要使用支付密码
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="usePointVal">使用福分值</param>
        /// <param name="isUseBalance">是否启用余额支付</param>
        /// <returns></returns>
        [OperationContract]
        int CheckUserPaypwdForPay( int userID, int usePointVal, int isUseBalance );
        #endregion
    }
}
