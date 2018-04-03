using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
    {
        #region 获取会员所有信息统计:FriendCount,sysMsgCount,privMsgCount
        /// <summary>
        /// 获取会员所有信息统计
        /// FriendCount,sysMsgCount,privMsgCount
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public DataSet GetUserMsgCount( int userID )
        {
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALUserMsg _DAL = new DALUserMsg();
                    _DS = _DAL.GetUserMsgCount( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserMsg.GetUserMsgCount Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 检测发送者是否可以发私信给接收者
        /// <summary>
        /// 检测发送者是否可以发私信给接收者
        /// </summary>
        /// <param name="senderUserID">发送者ID</param>
        /// <param name="inceptUserID">接收者ID</param>
        /// <returns></returns>
        public int CheckUserPrivMsgSend( int senderUserID, int inceptUserID )
        {
            int _Result = 0;
            if ( senderUserID > 0 && inceptUserID > 0 )
            {
                try
                {
                    IDALUserMsg _DAL = new DALUserMsg();
                    _Result = _DAL.CheckUserPrivMsgSend( senderUserID, inceptUserID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserMsg.CheckUserPrivMsgSend Exception:" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 添加会员系统信息记录
        /// <summary>
        /// 添加会员系统信息记录
        /// </summary>
        /// <param name="userID">接收会员ID</param>
        /// <param name="msgContent">信息内容</param>
        /// <param name="msgTime">发送时间</param>
        /// <param name="msgType">0:系统产生  1：后台管理员所发</param>
        /// <returns></returns>
        public bool InsertUserMessage( int userID, string msgContent, DateTime msgTime, int msgType )
        {
            bool _Result = false;
            if ( userID > 0 && msgContent != "" )
            {
                try
                {
                    IDALUserMsg _DAL = new DALUserMsg();
                    _Result = _DAL.InsertUserMessage( userID, msgContent, msgTime, msgType ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserMsg.InsertUserMessage Exception:" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 删除会员系统信息记录
        /// <summary>
        /// 删除会员系统信息记录
        /// </summary>
        /// <param name="msgID">信息ID</param>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public bool DeleteUserMessage( int msgID, int userID )
        {
            bool _Result = false;
            if ( msgID > 0 && userID > 0 )
            {
                try
                {
                    IDALUserMsg _DAL = new DALUserMsg();
                    _Result = _DAL.DeleteUserMessage( msgID, userID ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserMsg.DeleteUserMessage Exception:" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 删除会员全部系统信息记录
        /// <summary>
        /// 删除会员全部系统信息记录
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public void DeleteUserMessageAll( int userID )
        {
            try
            {
                IDALUserMsg _DAL = new DALUserMsg();
                _DAL.DeleteUserMessageAll( userID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UserMsg.DeleteUserMessageAll Exception:" + ex.Message );
            }
        }
        #endregion

        #region 会员中心 - 查询会员系统信息分页记录
        /// <summary>
        /// 会员中心 - 查询会员系统信息分页记录
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataSet GetMemberCenterForUserMessageList( int userID, int FIdx, int EIdx, bool isCount, out int totalCount, out int privMsgCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            privMsgCount = 0;
            if ( userID > 0 && FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALUserMsg _DAL = new DALUserMsg();
                    _DS = _DAL.GetMemberCenterForUserMessageList( userID, FIdx, EIdx, isCount, out totalCount, out privMsgCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserMsg.GetMemberCenterForUserMessageList Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 私信数据调用 2012.8
        /// <summary>
        /// 屏蔽某私信记录
        /// </summary>
        /// <param name="msgID">消息ID</param>
        /// <param name="userID">接收会员ID</param>
        /// <param name="oppUserID">会话对方会员ID</param>
        /// <returns></returns>
        public bool DeleteUserPrivMsg( int msgID, int userID, int oppUserID )
        {
            bool _Result = false;
            if ( msgID > 0 && userID > 0 && oppUserID > 0 )
            {
                try
                {
                    IDALUserMsg _DAL = new DALUserMsg();
                    _Result = _DAL.DeleteUserPrivMsg( msgID, userID, oppUserID ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserMsg.DeleteUserPrivMsg Exception:" + ex.Message );
                }
            }
            return _Result;
        }

        /// <summary>
        /// 清空某好友所有私信记录
        /// </summary>
        /// <param name="userID">接收会员ID</param>
        /// <param name="senderUserID">发送会员ID</param>
        /// <returns></returns>
        public bool DeleteUserPrivMsgHead( int userID, int senderUserID )
        {
            bool _Result = false;
            if ( userID > 0 && senderUserID > 0 )
            {
                try
                {
                    IDALUserMsg _DAL = new DALUserMsg();
                    _Result = _DAL.DeleteUserPrivMsgHead( userID, senderUserID ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserMsg.DeleteUserPrivMsgHead Exception:" + ex.Message );
                }
            }
            return _Result;
        }

        /// <summary>
        /// 清空会员所有私信记录
        /// </summary>
        /// <param name="userID">接收会员ID</param>
        /// <returns></returns>
        public bool DeleteUserPrivMsgHeadAll( int userID )
        {
            bool _Result = false;
            if ( userID > 0 )
            {
                try
                {
                    IDALUserMsg _DAL = new DALUserMsg();
                    _Result = _DAL.DeleteUserPrivMsgHeadAll( userID ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserMsg.DeleteUserPrivMsgHeadAll Exception:" + ex.Message );
                }
            }
            return _Result;
        }

        /// <summary>
        /// 获取会员单条私信会话分页记录
        /// </summary>
        /// <param name="userID">接收会员ID</param>
        /// <param name="senderUserID">发送会员ID</param>
        /// <param name="FIdx">记录开始序号</param>
        /// <param name="EIdx">记录结束序号</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public DataSet GetUserPrivMsgDetailList( int userID, int sendUserID, int FIdx, int EIdx, bool isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 && sendUserID > 0 && FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALUserMsg _DAL = new DALUserMsg();
                    _DS = _DAL.GetUserPrivMsgDetailList( userID, sendUserID, FIdx, EIdx, isCount, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserMsg.GetUserPrivMsgDetailList Exception:" + ex.Message );
                }
            }
            return _DS;
        }

        /// <summary>
        /// 获取会员所有私信分页记录
        /// </summary>
        /// <param name="userID">接收会员ID</param>
        /// <param name="FIdx">记录开始序号</param>
        /// <param name="EIdx">记录结束序号</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public DataSet GetUserPrivMsgList( int userID, int FIdx, int EIdx, bool isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            if ( userID > 0 && FIdx > 0 && EIdx > FIdx )
            {
                try
                {
                    IDALUserMsg _DAL = new DALUserMsg();
                    _DS = _DAL.GetUserPrivMsgList( userID, FIdx, EIdx, isCount, out totalCount );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserMsg.GetUserPrivMsgList Exception:" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 手机版清除会员所有消息[系统、好友申请、私信]
        /// <summary>
        /// 手机版清除会员所有消息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int ClearUserAllMessage( int userID )
        {
            int _Result = 0;
            try
            {
                IDALUserMsg _DAL = new DALUserMsg();
                _Result = _DAL.ClearUserAllMessage( userID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UserMsg.ClearUserAllMessage Ex:" + ex.Message );
            }
            return _Result;
        }
        #endregion
    }
}
