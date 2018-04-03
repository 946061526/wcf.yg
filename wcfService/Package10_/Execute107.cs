using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 根据购物车ID删除购物车信息10701
        /// <summary>
        /// 根据购物车ID删除购物车信息10701
        /// </summary>
        /// <param name="shopIdStr">购物车ID串</param>
        /// <returns></returns>
        public static int DeleteCartByIdStr( params object[] para )
        {
            string shopIdStr = (string)para[0];
            int _Result = 0;
            if ( !UtilityFun.IsEmptyString( shopIdStr ) )
            {
                try
                {
                    IDALCart _DAL = new DALCart();
                    _Result = _DAL.DeleteCartByIdStr( shopIdStr ) ? 1 : 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Cart.DeleteCartByIdStr抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion
        #region 删除当前用户的购物车信息10702
        /// <summary>
        /// 删除当前用户的购物车信息10702
        /// </summary>
        /// <param name="userID">当前用户ID</param>
        /// <returns>成功：1，失败：0</returns>
        public static int DeleteCartByUserID( params object[] para )
        {
            int userID = (int)para[0];
            int _Result = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALCart _DAL = new DALCart();
                    _Result = _DAL.DeleteCartByUserID( userID, true );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Cart.DeleteCartByUserID抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion
        #region 获取用户某个条码的购物车信息10703
        /// <summary>
        /// 获取用户某个条码的购物车信息10703
        /// </summary>
        /// <param name="userID">当前用户ID</param>
        /// <param name="codeID">条码ID</param>
        /// <returns></returns>
        public static DataSet GetCartInfo( params object[] para )
        {
            int userID = (int)para[0];
            int codeID = (int)para[1];
            DataSet _DS = null;
            if ( userID > 0 && codeID > 0 )
            {
                try
                {
                    IDALCart _DAL = new DALCart();
                    _DS = _DAL.GetCartInfo( userID, codeID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Cart.GetCartInfo抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 获取当前用户的购物车信息10704
        /// <summary>
        /// 获取当前用户的购物车信息10704
        /// 已过滤结束状态的商品
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static DataSet GetCartListByUserID( params object[] para )
        {
            int userID = (int)para[0];
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALCart _DAL = new DALCart();
                    _DS = _DAL.GetCartListByUserID( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Cart.GetCartListByUserID抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 添加购物车10705/1070501
        /// <summary>
        /// 添加购物车10705
        /// </summary>
        /// <param name="shopUserID">用户ID</param>
        /// <param name="shopCodeID">商品条码ID</param>
        /// <param name="shopNum">云购人次</param>
        /// <param name="shopState">云购状态，0为选中</param>
        /// <param name="shopTime">添加时间</param>
        /// <returns></returns>
        public static int InsertCart( params object[] para )
        {
            int _Result = 0;
            int shopUserID = (int)para[0];
            int shopCodeID = (int)para[1];
            int shopNum = (int)para[2];
            int shopState = (int)para[3];
            DateTime shopTime = (DateTime)para[4];

            if ( shopUserID > 0 && shopCodeID > 0 && shopNum >= 0 )
            {
                try
                {
                    IDALCart _DAL = new DALCart();
                    _Result = _DAL.InsertCart( shopUserID, shopCodeID, shopNum, shopState, shopTime, true ) ? 1 : 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Cart.InsertCart抛出异常：" + ex.Message );
                }
            }

            return _Result;
        }
        /// <summary>
        /// 批量添加购物车1070501
        /// </summary>
        /// <param name="shopUserID">用户ID</param>
        /// <param name="shopCodeIDStr">商品条码ID</param>
        /// <param name="shopNumStr">云购人次</param>
        /// <param name="shopStateStr">云购状态，0为选中</param>
        /// <param name="shopTime">添加时间</param>
        /// <returns>-3参数有误，-2异常，0添加购物车失败，1成功</returns>
        public static int InsertCartEx( params object[] para )
        {
            int shopUserID = (int)para[0];
            string shopCodeIDStr = (string)para[1];
            string shopNumStr = (string)para[2];
            string shopStateStr = (string)para[3];
            DateTime shopTime = (DateTime)para[4];

            int _Result = -3;
            string[] _CodeArr = shopCodeIDStr.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
            string[] _NumArr = shopNumStr.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
            string[] _StateArr = shopStateStr.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
            if ( _CodeArr.Length > 0 && _CodeArr.Length == _NumArr.Length )
            {
                try
                {
                    IDALCart _DAL = new DALCart();
                    _DAL.TranBegin();

                    _DAL.DeleteCartByUserID( shopUserID, false );

                    _Result = 1;
                    int _Count = _CodeArr.Length;
                    for ( int i = 0; i < _Count; i++ )
                    {
                        int _ShopCodeID = UtilityFun.ToInt32( _CodeArr[i] );
                        int _ShopNum = UtilityFun.ToInt32( _NumArr[i] );
                        int _ShopState = UtilityFun.ToInt32( _StateArr[i] );
                        //添加到列表
                        if ( _ShopCodeID > 0 && _ShopNum > 0 )
                        {
                            bool _Flag = _DAL.InsertCart( shopUserID, _ShopCodeID, _ShopNum, _ShopState, shopTime, false );

                            if ( !_Flag || !_DAL.IsUseTrans )
                            {
                                _Result = 0;
                                break;
                            }
                        }
                    }

                    if ( _Result == 1 )
                    {
                        _DAL.TranCommit();
                    }
                    else
                    {
                        _Result = 0;
                        _DAL.TranRollBack();
                    }

                    _DAL.DisposeConn();
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    _Result = -2;
                    UtilityFile.AddLogErrMsg( "Cart.InsertCartEx抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion
        #region 修改购物车记录10706
        /// <summary>
        /// 修改购物车记录10706
        /// </summary>
        /// <param name="shopID">购物车ID</param>
        /// <param name="shopNum">购买人次</param>
        /// <param name="shopState">状态，默认0</param>
        /// <returns></returns>
        public static int UpdataCartInfoByID( params object[] para )
        {
            int shopID = (int)para[0];
            int shopNum = (int)para[1];
            int shopState = (int)para[2];
            int _Result = 0;
            try
            {
                IDALCart _DAL = new DALCart();
                _Result = _DAL.UpdataCartInfoByID( shopID, shopNum, shopState ) ? 1 : 0;
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Cart.UpdataCartInfoByID抛出异常：" + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 批量更新会员购物车记录的状态10708
        /// <summary>
        /// 批量更新会员购物车记录的状态10708
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="shopState"></param>
        /// <returns></returns>
        public static int UpdateCartStateBatch( params object[] para )
        {
            int userID = (int)para[0];
            int shopState = (int)para[1];
            int _Flag = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALCart _DAL = new DALCart();
                    _Flag = _DAL.UpdateCartStateBatch( userID, shopState ) ? 1 : 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserBuy.UpdateCartStateBatch Exception:" + ex.Message );
                }
            }
            return _Flag;
        }
        #endregion
        #region 获取用户购物车列表10709
        /// <summary>
        /// 获取用户购物车列表10709
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static DataSet GetUserCartGoodsList( params object[] para )
        {
            int userID = (int)para[0];
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALCart _DAL = new DALCart();
                    _DS = _DAL.GetUserCartGoodsList( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Cart.GetUserCartList Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 添加购物车--2014.12改版10710
        /// <summary>
        /// 添加购物车10710
        /// </summary>
        /// <param name="shopUserID">用户ID</param>
        /// <param name="shopCodeIDStr">商品条码ID</param>
        /// <param name="shopNumStr">云购人次</param>
        /// <param name="shopStateStr">云购状态，0为选中</param>
        /// <param name="shopTime">添加时间</param>
        /// <returns></returns>
        public static int InsertToCart( params object[] para )
        {
            int shopUserID = (int)para[0];
            string shopCodeIDStr = (string)para[1];
            string shopNumStr = (string)para[2];
            string shopStateStr = (string)para[3];
            DateTime shopTime = (DateTime)para[4];

            int _Result = -3;
            string[] _CodeArr = shopCodeIDStr.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
            string[] _NumArr = shopNumStr.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
            string[] _StateArr = shopStateStr.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
            if ( _CodeArr.Length > 0 && _CodeArr.Length == _NumArr.Length )
            {
                IDALCart _DAL = new DALCart();
                try
                {
                    _DAL.TranBegin();

                    _DAL.DeleteCartByUserID( shopUserID, false );

                    int _Count = _CodeArr.Length;
                    for ( int i = 0; i < _Count; i++ )
                    {
                        int _ShopCodeID = UtilityFun.ToInt32( _CodeArr[i] );
                        int _ShopNum = UtilityFun.ToInt32( _NumArr[i] );
                        int _ShopState = UtilityFun.ToInt32( _StateArr[i] );
                        //添加到列表
                        if ( _ShopCodeID > 0 && _ShopNum > 0 )
                        {
                            _DAL.InsertToCart( shopUserID, _ShopCodeID, _ShopNum, _ShopState, shopTime, false );
                        }
                    }

                    _Result = 1;
                    _DAL.TranCommit();
                }
                catch ( Exception ex )
                {
                    _Result = -2;
                    _DAL.TranRollBack();
                    UtilityFile.AddLogErrMsg( "Cart.InsertToCart抛出异常：" + ex.Message );
                }
                finally
                {
                    _DAL.DisposeConn();
                    _DAL = null;
                }
            }
            return _Result;
        }
        #endregion
        #region 判断条码是否已失效并获取其正在进行的期数10711
        /// <summary>
        /// 判断条码是否已失效并获取其正在进行的期数10711
        /// </summary>
        /// <param name="codeIDStr">条码ＩＤ串</param>
        /// <returns></returns>
        public static DataSet GetUnuseGoodsNextPeriod( params object[] para )
        {
            string codeIDStr = (string)para[0];
            DataSet _DS = null;
            if ( !string.IsNullOrEmpty( codeIDStr ) )
            {
                try
                {
                    IDALCart _DAL = new DALCart();
                    _DS = _DAL.GetUnuseGoodsNextPeriod( codeIDStr );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Cart.GetUnuseGoodsNextPeriod Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion
        #region 根据商品条码串删除用户购物车中的商品10712
        /// <summary>
        /// 根据商品条码串删除购物车中的商品10712
        /// </summary>
        /// <param name="userID">用户ＩＤ</param>
        /// <param name="codeIDStr">条码ＩＤ串</param>
        /// <returns></returns>
        public static int DeleteCartByCodeIDStr( params object[] para )
        {
            int userID = (int)para[0];
            string codeIDStr = (string)para[1];
            int _Result = 0;
            if ( userID > 0 && !string.IsNullOrEmpty( codeIDStr ) )
            {
                try
                {
                    IDALCart _DAL = new DALCart();
                    _Result = _DAL.DeleteCartByCodeIDStr( userID, codeIDStr );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Cart.DeleteCartByCodeIDStr Exception:" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion
        #region 检测用户支付时是否需要使用支付密码10713
        /// <summary>
        /// 检测用户支付时是否需要使用支付密码10713
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="usePointVal">使用福分值</param>
        /// <param name="isUseBalance">是否启用余额支付</param>
        /// <returns></returns>
        public static int CheckUserPaypwdForPay( params object[] para )
        {
            int userID = (int)para[0];
            int usePointVal = (int)para[1];
            int isUseBalance = (int)para[2];
            int useBrokerVal = 0;
            if ( para.Length == 4 )
            {
                useBrokerVal = (int)para[3];
            }
            usePointVal = usePointVal > 0 ? usePointVal : 0;
            useBrokerVal = useBrokerVal > 0 ? useBrokerVal : 0;
            int _Result = 0;
            try
            {
                IDALCart _DAL = new DALCart();
                _Result = _DAL.CheckUserPaypwdForPay( userID, usePointVal, isUseBalance, useBrokerVal );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Cart.CheckUserPaypwdForPay Ex:" + ex.Message );
            }
            return _Result;
        }
        #endregion
    }
}
