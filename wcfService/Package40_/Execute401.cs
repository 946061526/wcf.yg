using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class ExecuteFun
    {

        #region 运营应用相关
        #region 修改用户基本信息40103
        /// <summary>
        /// app相关操作记录40103
        /// </summary>
        /// <param name="IMEI">IMEI码</param>
        /// <param name="appMarketCode">应用平台代码</param>
        /// <param name="operateType">1.下载且激活app,2.在app上注册,3.在app上登录,4.卸载app</param>
        /// <param name="loginUserID">登录用户ID</param>
        /// <param name="registerUserID">注册用户ID</param>
        /// <param name="device">设备型号</param>
        /// <param name="sysVer">系统版本</param>
        /// <param name="appVer">app版本</param>
        /// <returns></returns>
        public static int appUsingTheApp( params object[] para )
        {
            int _Result = 0;
            try
            {
                string _IMEI = (string)para[0];
                string _AppMarketCode = (string)para[1];
                int _OperateType = (int)para[2];
                int _LoginUserID = (int)para[3];
                int _RegisterUserID = (int)para[4];
                string _Device = (string)para[5];
                string _SysVer = (string)para[6];
                string _AppVer = (string)para[7];
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.appUsingTheApp( _IMEI, _AppMarketCode, _OperateType, _LoginUserID, _RegisterUserID, _Device, _SysVer, _AppVer );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                _Result = -202;
                UtilityFile.AddLogErrMsg( "appUsingTheApp Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
        #endregion
        #region APP弹窗引导用户评论或反馈
        #region APP用户评论校验40105
        /// <summary>
        /// APP用户评论校验40105
        /// </summary>
        /// <param name="imei"></param>
        /// <param name="userID"></param>
        /// <param name="buyDayNum">扫描天数，默认14</param>
        /// <param name="getGoodsNum">近两周内获得商品数量的最低值，默认3</param>
        /// <param name="appMarketCode">应用平台代码，默认appstore</param>
        /// <param name="appVer">app版本</param>
        /// <param name="sDayNum">意见反馈，多少日不再提示，默认180天</param>
        /// <param name="nDayNum">下次再说，多少日内不再提示，默认60天</param>
        /// <param name="percent">消费金额与获得总价比，默认1</param>
        /// <returns></returns>
        public static int ChkAppUserComment( params object[] para )
        {
            int _Result = 0;
            try
            {
                string _Imei = (string)para[0];
                int _UserID = (int)para[1];
                int _BuyDayNum = (int)para[2];
                int _GetGoodsNum = (int)para[3];
                string _AppMarketCode = (string)para[4];
                string _AppVer = (string)para[5];
                int _SDayNum = (int)para[6];
                int _NDayNum = (int)para[7];
                double _Percent = (double)para[8];
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.ChkAppUserComment(_Imei, _UserID, _BuyDayNum, _GetGoodsNum, _AppMarketCode, _AppVer, _SDayNum, _NDayNum, _Percent );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                _Result = -202;
                UtilityFile.AddLogErrMsg( "ChkAppUserComment Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region APP用户评论校验40106
        /// <summary>
        /// 弹窗用户选择记录40106
        /// </summary>
        /// <param name="imei"></param>
        /// <param name="userID"></param>
        /// <param name="appMarketCode">-应用平台代码，默认appstore</param>
        /// <param name="appVer">app版本</param>
        /// <param name="commentType">1-好评;2-反馈意见;3-下次再说</param>
        /// <returns></returns>
        public static int AddAppComments( params object[] para )
        {
            int _Result = 0;
            try
            {
                string _Imei = (string)para[0];
                int _UserID = (int)para[1];
                string _AppMarketCode = (string)para[2];
                string _AppVer = (string)para[3];
                int _CommentType = (int)para[4];
                IDALUsers _DAL = new DALUsers();
                _Result = _DAL.AddAppComments(_Imei, _UserID, _AppMarketCode, _AppVer, _CommentType );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                _Result = -202;
                UtilityFile.AddLogErrMsg( "AddAppComments Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
        #endregion

    }
}
