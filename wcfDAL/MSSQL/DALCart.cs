using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALCart : DALBase, IDALCart
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
        /// <param name="autoCommit">是否自动提交事务</param>
        /// <returns></returns>
        public bool InsertCart( int shopUserID, int shopCodeID, int shopNum, int shopState, DateTime shopTime, bool autoCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10705" );
            Para.AddOrcNewInParameter( "i_isCommit", autoCommit ? 0 : 1 );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewInParameter( "i_shopuserid", shopUserID );
            Para.AddOrcNewInParameter( "i_shopcodeid", shopCodeID );
            Para.AddOrcNewInParameter( "i_shopnum", shopNum );
            Para.AddOrcNewInParameter( "i_shopstate", shopState );
            Para.AddOrcNewInParameter( "i_shoptime", shopTime );
            Dal.ExecuteNonQuery( "yun_Cart.f_addCart" );//pro_CartInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal > 0;//1成功，0失败
        }
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
        public int InsertToCart( int shopUserID, int shopCodeID, int shopNum, int shopState, DateTime shopTime, bool autoCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10710" );
            Para.AddOrcNewInParameter( "i_isCommit", autoCommit ? 0 : 1 );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewInParameter( "i_shopuserid", shopUserID );
            Para.AddOrcNewInParameter( "i_shopcodeid", shopCodeID );
            Para.AddOrcNewInParameter( "i_shopnum", shopNum );
            Para.AddOrcNewInParameter( "i_shopstate", shopState );
            Para.AddOrcNewInParameter( "i_shoptime", shopTime );
            Dal.ExecuteNonQuery( "yun_Cart.f_addCartElse" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;//1成功，0失败
        }
        #endregion

        #region 获取当前用户的购物车信息
        /// <summary>
        /// 获取当前用户的购物车信息
        /// 已过滤结束状态的商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public DataSet GetCartListByUserID( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10704" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Cart.sp_getCartListByUserID" );//Pro_CartGetListByUserID
        }
        #endregion

        #region 获取用户某个条码的购物车信息
        /// <summary>
        /// 获取用户某个条码的购物车信息
        /// </summary>
        /// <param name="userID">当前用户ID</param>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        public DataSet GetCartInfo( int userID, int codeID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10703" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_codeid", codeID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Cart.sp_getCartInfoByUserID" );//Pro_CartGetInfo
        }
        #endregion

        #region 根据购物车ID删除购物车信息
        /// <summary>
        /// 根据购物车ID删除购物车信息
        /// </summary>
        /// <param name="shopIdStr">购物车ID串</param>
        /// <returns></returns>
        public bool DeleteCartByIdStr( string shopIdStr )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "10701" );
            Para.AddOrcNewInParameter( "i_shopidstr", shopIdStr );
            Dal.ExecuteNonQuery( "yun_Cart.f_delCartByShopId" );//pro_CartDeleteByIdStr
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal > 0;//>0:返回影响行数  0:异常 -1:失败,影响行数为0
        }
        #endregion

        #region 修改购物车记录
        /// <summary>
        /// 修改购物车记录
        /// </summary>
        /// <param name="shopID">购物车ID</param>
        /// <param name="shopNum">购买人次</param>
        /// <param name="shopState">状态，默认0</param>
        /// <returns></returns>
        public bool UpdataCartInfoByID( int shopID, int shopNum, int shopState )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "10706" );
            Para.AddOrcNewInParameter( "i_shopid", shopID );
            Para.AddOrcNewInParameter( "i_shopnum", shopNum );
            Para.AddOrcNewInParameter( "i_shopstate", shopState );
            Dal.ExecuteNonQuery( "yun_Cart.f_modCartByShopID" );//Pro_CartUpdateInfoByID
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal > 0;//>0:返回影响行数  0:异常 -1:失败,影响行数为0
        }
        #endregion

        #region 删除当前用户的购物车信息
        /// <summary>
        /// 删除当前用户的购物车信息
        /// </summary>
        /// <param name="userID">当前用户ID</param>
        /// <param name="autoCommit">是否自动提交事务</param>
        /// <returns>成功：1，失败：0</returns>
        public int DeleteCartByUserID( int userID, bool autoCommit )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10702" );
            Para.AddOrcNewInParameter( "i_isCommit", autoCommit ? 0 : 1 );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Dal.ExecuteNonQuery( "yun_Cart.f_delCartByUserId" );//pro_CartDeleteByUserID
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;//>0:返回影响行数  0:异常 -1:失败,影响行数为0
        }
        #endregion

        #region 批量更新会员购物车记录的状态
        /// <summary>
        /// 批量更新会员购物车记录的状态
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="shopState"></param>
        /// <returns></returns>
        public bool UpdateCartStateBatch( int userID, int shopState )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10708" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_shopstate", shopState );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_Cart.f_modMoreCartByUserID" );//  pro_CartUpdateStateBatch
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal > 0;
        }
        #endregion

        #region 获取用户购物车商品列表
        /// <summary>
        /// 获取用户购物车商品列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public DataSet GetUserCartGoodsList( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10709" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_cart.sp_getcartgoodsbyuserid" );
        }
        #endregion

        #region 判断条码是否已失效并获取其正在进行的期数
        /// <summary>
        /// 判断条码是否已失效并获取其正在进行的期数
        /// </summary>
        /// <param name="codeIDStr">条码ＩＤ串</param>
        /// <returns></returns>
        public DataSet GetUnuseGoodsNextPeriod( string codeIDStr )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10711" );
            Para.AddOrcNewInParameter( "i_codeIDStr", codeIDStr );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_Cart.sp_getUnuseGoodsNextPeriod" );
        }
        #endregion

        #region 根据商品条码串删除购物车中的商品
        /// <summary>
        /// 根据商品条码串删除购物车中的商品
        /// </summary>
        /// <param name="userID">用户ＩＤ</param>
        /// <param name="codeIDStr">条码ＩＤ串</param>
        /// <returns></returns>
        public int DeleteCartByCodeIDStr( int userID, string codeIDStr )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10712" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_CodeIDStr", codeIDStr );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_Cart.f_delCartByCodeIDStr" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
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
        public int CheckUserPaypwdForPay( int userID, int usePointVal, int isUseBalance, int useBroker )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "10713" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_points", usePointVal );
            Para.AddOrcNewInParameter( "i_isBalance", isUseBalance );
            Para.AddOrcNewInParameter( "i_broker", useBroker );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_Cart.f_chkIsNeedPayPwdByCart" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 0 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 获取支付订单号
        /// <summary>
        /// 获取支付订单号
        /// </summary>
        /// <returns></returns>
        public DataTable GetPayShopID()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12322" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataTable( "yun_PayMentRecord.sp_getPayShopID" );
        }
        #endregion
    }
}
