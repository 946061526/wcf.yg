using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALUserMsg : DALBase, IDALUserMsg
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11705" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getFriendMsgByUserID" );//pro_MemberCenterForGetUserMsgCount
        }
        #endregion

        #region 检测发送者是否可以发私信给接收者
        /// <summary>
        /// 检测发送者是否可以发私信给接收者
        /// 2禁止所有人  1只允许好友发  0异常  -1 UserFriendLink的相关数据不存在
        /// </summary>
        /// <param name="senderUserID">发送者ID</param>
        /// <param name="inceptUserID">接收者ID</param>
        /// <returns></returns>
        public int CheckUserPrivMsgSend( int senderUserID, int inceptUserID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12952" );
            Para.AddOrcNewInParameter( "i_sendUserID", senderUserID );
            Para.AddOrcNewInParameter( "i_resvUserID", inceptUserID );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_chkUserIsSendMsgByUserID" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
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
        public int InsertUserMessage( int userID, string msgContent, DateTime msgTime, int msgType )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12942" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewInParameter( "i_msgContent", msgContent );
            Para.AddOrcNewInParameter( "i_msgTime", msgTime );
            Para.AddOrcNewInParameter( "i_isSys", msgType );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_addSysInfoOfUser" );//pro_UserMessageInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 删除会员系统信息记录
        /// <summary>
        /// 删除会员系统信息记录
        /// </summary>
        /// <param name="msgID">信息ID</param>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public int DeleteUserMessage( int msgID, int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12940" );
            Para.AddOrcNewInParameter( "i_msgid", msgID );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_delSysInfoOfUserByMsgID" );//pro_UserMessageDelete
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 删除会员全部系统信息记录
        /// <summary>
        /// 删除会员全部系统信息记录
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public int DeleteUserMessageAll( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12941" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_delSysInfoOfUserByUserID" );//pro_UserMessageDeleteALL
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
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

            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11729" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount ? 1 : 0 );
            Para.AddOrcNewCursorParameter( "o_result" );
            Para.AddOrcNewCursorParameter( "o_result_msg" );
            DataSet _DSTmp = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getUserSysInfoByUserid" );//pro_MemberCenterForUserMessageList
            if ( _DSTmp != null && _DSTmp.Tables.Count == 2 && _DSTmp.Tables[1].Rows.Count > 0 )
            {
                _DS = new DataSet();
                _DS.Tables.Add( _DSTmp.Tables[0].Copy() );
                totalCount = GetOrcTotalCount( isCount ? 1 : 0, _DS );

                privMsgCount = ToInt32( _DSTmp.Tables[1].Rows[0][0] );
            }
            _DSTmp = null;
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
        public int DeleteUserPrivMsg( int msgID, int userID, int oppUserID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12948" );
            Para.AddOrcNewInParameter( "i_msgID", msgID );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewInParameter( "i_oppUserID", oppUserID );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_modUserPrivMsgByUserID" );//pro_UserPrivMsgDetailDelete
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        /// <summary>
        /// 清空某好友所有私信记录
        /// </summary>
        /// <param name="userID">接收会员ID</param>
        /// <param name="senderUserID">发送会员ID</param>
        /// <returns></returns>
        public int DeleteUserPrivMsgHead( int userID, int senderUserID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12949" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewInParameter( "i_senderUserID", senderUserID );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_modFridPrivMsgByUserID" );//pro_UserPrivMsgHeadDelete
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }

        /// <summary>
        /// 清空会员所有私信记录
        /// </summary>
        /// <param name="userID">接收会员ID</param>
        /// <returns></returns>
        public int DeleteUserPrivMsgHeadAll( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12950" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_modVipPrivMsgByUserID" );//pro_UserPrivMsgHeadDeleteALL
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11736" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_sendUserID", sendUserID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount ? 1 : 0 );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getPrivMsgByUserid" );//pro_MemberCenterForUserPrivMsgDetailList
            totalCount = GetOrcTotalCount( isCount ? 1 : 0, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11737" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount ? 1 : 0 );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getAllPrivMsgByUserid" );//pro_MemberCenterForUserPrivMsgList
            totalCount = GetOrcTotalCount( isCount ? 1 : 0, _DS );
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12969" );
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_modclearAllMsgByUserID" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion

        #region 分页获取晒单或话题的评论回复消息列表
        /// <summary>
        /// 分页获取晒单或话题的评论回复消息列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <returns></returns>
        public DataSet GetReplyMsgPageByUserID( int userID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "11764" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_IsCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_MemberCenter.sp_getReplyMsgPageByUserid" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region 用户删除晒单或话题的评论回复消息
        /// <summary>
        /// 用户删除晒单或话题的评论回复消息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="msgID">消息ID 等于0则删除全部</param>
        /// <returns></returns>
        public int DeleteReplyMsgByUserID( int userID, int msgID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter("11765");
            Para.AddOrcNewInParameter( "i_userid", userID );
            Para.AddOrcNewInParameter( "i_msgID", msgID );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_MemberCenter.f_delReplyMsgByUserID" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );
        }
        #endregion
    }
}
