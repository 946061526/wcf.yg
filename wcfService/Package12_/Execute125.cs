using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 获取QQ群帐号列表12503
        /// <summary>
        /// 获取QQ群帐号列表12503
        /// </summary>
        /// <param name="areaID">区域</param>
        /// <param name="key">查询关键字</param>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public static DataSet GetQQAccountPageList( out int totalCount, params object[] para )
        {
            int areaID = (int)para[0];
            string key = (string)para[1];
            int FIdx = (int)para[2];
            int EIdx = (int)para[3];
            bool isCount = (bool)para[4];
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALQQ _DAL = new DALQQ();
                _DS = _DAL.GetQQAccountPageList( areaID, key, FIdx, EIdx, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "QQ.GetQQAccountPageList Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 获取QQ群帐号置顶列表12504
        /// <summary>
        /// 获取QQ群帐号置顶列表12504
        /// </summary>
        /// <returns></returns>
        public static DataSet GetQQAccountTopList()
        {
            DataSet _DS = null;
            try
            {
                IDALQQ _DAL = new DALQQ();
                _DS = _DAL.GetQQAccountTopList();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "QQ.GetQQAccountTopList Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 从qq授权信息表中获取会员ID 12507
        /// <summary>
        /// 从qq授权信息表中获取会员ID 12507
        /// </summary>
        /// <param name="openId">用户身份唯一标识</param>
        /// <returns>存在则userID，不存在则0</returns>
        public static int GetUserIDFromQQAuth( params object[] para )
        {
            string openId = (string)para[0];
            int _UserID = 0;
            if ( openId != "" )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _UserID = _DAL.GetUserIDFromQQAuth( openId );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserIDFromQQAuth1抛出异常：" + ex.Message );
                }
            }
            return _UserID;
        }
        #endregion
        #region 从qq授权信息表中获取会员ID 12507
        /// <summary>
        /// 从qq授权信息表中获取会员ID 12507
        /// </summary>
        /// <param name="openId">用户身份唯一标识</param>
        /// <returns>存在则userID，不存在则0</returns>
        public static int GetUserIDFromQQAuth( out int isAutoLogin, params object[] para )
        {
            isAutoLogin = 0;
            string openId = (string)para[0];
            int _UserID = 0;
            if ( openId != "" )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _UserID = _DAL.GetUserIDFromQQAuth( openId, out isAutoLogin );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.GetUserIDFromQQAuth2抛出异常：" + ex.Message );
                }
            }
            return _UserID;
        }
        #endregion
        #region qq登录后填写相关信息12508
        /// <summary>
        /// qq登录后填写相关信息12508
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="openId">用户身份唯一标识</param>
        /// <param name="accessToken">用户授权信息</param>
        /// <returns></returns>
        public static int InsertQQAuth( params object[] para )
        {
            int userID = (int)para[0];
            string openId = (string)para[1];
            string accessToken = (string)para[2];
            int _Result = 0;
            if ( userID > 0 && openId != "" )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.InsertQQAuth( userID, openId, accessToken ) ? 1 : 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.InsertQQAuth抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion
        #region QQ授权自动完成注册信息12509

        /// <summary>
        /// QQ授权自动完成注册信息12509
        /// 返回值：
        /// >0 注册成功userID
        /// -1 注册失败
        /// </summary>
        /// <param name="userEmail">注册邮件地址（qqlogin_[Guid]@qq.com产生）</param>
        /// <param name="userPwd">登录密码（随机产生）</param>
        /// <param name="userIP">注册IP</param>
        /// <param name="invitedUserID">邀请者ID</param>
        /// <param name="marketUserID"></param>
        /// <param name="openID">用户身份唯一标识</param>
        /// <param name="accessToken">用户授权信息</param>
        /// <returns></returns>
        public static int SkipQQAuthRegister( params object[] para )
        {
            string userEmail = (string)para[0];
            string userPwd = (string)para[1];
            string userIP = (string)para[2];
            int invitedUserID = (int)para[3];
            int marketUserID = (int)para[4];
            string openID = (string)para[5];
            string accessToken = (string)para[6];
            int _Result = 0;
            if ( userEmail != "" && userPwd != "" && openID != "" )
            {
                try
                {
                    IDALUsers _DAL = new DALUsers();
                    _Result = _DAL.SkipQQAuthRegister( userEmail, userPwd, userIP, invitedUserID, marketUserID, openID, accessToken );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "Users.SkipQQAuthRegister抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }

        #endregion
    }
}
