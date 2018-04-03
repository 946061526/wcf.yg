using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALCart
    {
        #region void DisposeConn() 关闭并释放连接对象资源  Edit:2010.02.08
        /// <summary>
        /// 关闭并释放连接资源
        /// </summary>
        void DisposeConn();
        #endregion
        #region void TranBegin() 事务开始  Edit:2010.12.24
        /// <summary>
        /// 启用事务
        /// </summary>
        void TranBegin();
        #endregion
        #region void TranCommit() 提交事务  Edit:2010.12.24
        /// <summary>
        /// 提交事务
        /// </summary>
        void TranCommit();
        #endregion
        #region void TranRollBack() 回滚事务  Edit:2010.12.24
        /// <summary>
        /// 回滚事务
        /// </summary>
        void TranRollBack();
        #endregion
        #region bool IsUseTrans 获取事务状态  Edit:2010.12.24
        /// <summary>
        /// 获取事务状态,true:表顺利执行
        /// </summary>
        bool IsUseTrans
        {
            get;
        }
        #endregion

        #region 添加购物车
        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="shopUserID">用户ID</param>
        /// <param name="shopCodeID">商品条码ID</param>
        /// <param name="shopNum">云购人次</param>
        /// <param name="shopState">云购状态，0为选中</param>
        /// <param name="autoCommit">是否自动提交事务</param>
        /// <param name="shopTime">添加时间</param>
        /// <returns></returns>
        bool InsertCart( int shopUserID, int shopCodeID, int shopNum, int shopState, DateTime shopTime, bool autoCommit );
        #endregion

        #region 添加购物车--2014.12改版
        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="shopUserID">用户ID</param>
        /// <param name="shopCodeID">商品条码ID</param>
        /// <param name="shopNum">云购人次</param>
        /// <param name="shopState">云购状态，0为选中</param>
        /// <param name="autoCommit">是否自动提交事务</param>
        /// <param name="shopTime">添加时间</param>
        /// <returns></returns>
        int InsertToCart( int shopUserID, int shopCodeID, int shopNum, int shopState, DateTime shopTime, bool autoCommit );
        #endregion

        #region 获取当前用户的购物车信息
        /// <summary>
        /// 获取当前用户的购物车信息
        /// 已过滤结束状态的商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        DataSet GetCartListByUserID( int userID );
        #endregion

        #region 获取用户某个条码的购物车信息
        /// <summary>
        /// 获取用户某个条码的购物车信息
        /// </summary>
        /// <param name="userID">当前用户ID</param>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        DataSet GetCartInfo( int userID, int codeID );
        #endregion

        #region 根据购物车ID删除购物车信息
        /// <summary>
        /// 根据购物车ID删除购物车信息
        /// </summary>
        /// <param name="shopIdStr">购物车ID串</param>
        /// <returns></returns>
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
        bool UpdataCartInfoByID( int shopID, int shopNum, int shopState );
        #endregion

        #region 删除当前用户的购物车信息
        /// <summary>
        /// 删除当前用户的购物车信息
        /// </summary>
        /// <param name="userID">当前用户ID</param>
        /// <param name="autoCommit">是否自动提交事务</param>
        /// <returns>成功：1，失败：0</returns>
        int DeleteCartByUserID( int userID, bool autoCommit );
        #endregion

        #region 批量更新会员购物车记录的状态
        /// <summary>
        /// 批量更新会员购物车记录的状态
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="shopState"></param>
        /// <returns></returns>
        bool UpdateCartStateBatch( int userID, int shopState );
        #endregion

        #region 获取用户购物车列表
        /// <summary>
        /// 获取用户购物车列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        DataSet GetUserCartGoodsList( int userID );
        #endregion

        #region 判断条码是否已失效并获取其正在进行的期数
        /// <summary>
        /// 判断条码是否已失效并获取其正在进行的期数
        /// </summary>
        /// <param name="codeIDStr">条码ＩＤ串</param>
        /// <returns></returns>
        DataSet GetUnuseGoodsNextPeriod( string codeIDStr );
        #endregion

        #region 根据商品条码串删除用户购物车中的商品
        /// <summary>
        /// 根据商品条码串删除购物车中的商品
        /// </summary>
        /// <param name="userID">用户ＩＤ</param>
        /// <param name="codeIDStr">条码ＩＤ串</param>
        /// <returns></returns>
        int DeleteCartByCodeIDStr( int userID, string codeIDStr );
        #endregion

        #region 检测用户支付时是否需要使用支付密码
        /// <summary>
        /// 检测用户支付时是否需要使用支付密码
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="usePointVal">使用福分值</param>
        /// <param name="isUseBalance">是否启用余额支付</param>
        /// <param name="useBroker">使用佣金值</param>
        /// <returns></returns>
        int CheckUserPaypwdForPay( int userID, int usePointVal, int isUseBalance, int useBroker );
        #endregion

        #region 获取支付订单号
        /// <summary>
        /// 获取支付订单号
        /// </summary>
        /// <returns></returns>
        DataTable GetPayShopID();
        #endregion
    }
}
