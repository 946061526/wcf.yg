using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALUserMsg
    {
        #region 获取会员所有信息统计:FriendCount,sysMsgCount,privMsgCount
        /// <summary>
        /// 获取会员所有信息统计
        /// FriendCount,sysMsgCount,privMsgCount
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        DataSet GetUserMsgCount( int userID );
        #endregion

        #region 检测发送者是否可以发私信给接收者
        /// <summary>
        /// 检测发送者是否可以发私信给接收者
        /// </summary>
        /// <param name="senderUserID">发送者ID</param>
        /// <param name="inceptUserID">接收者ID</param>
        /// <returns></returns>
        int CheckUserPrivMsgSend( int senderUserID, int inceptUserID );
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
        int InsertUserMessage( int userID, string msgContent, DateTime msgTime, int msgType );
        #endregion

        #region 删除会员系统信息记录
        /// <summary>
        /// 删除会员系统信息记录
        /// </summary>
        /// <param name="msgID">信息ID</param>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        int DeleteUserMessage( int msgID, int userID );
        #endregion

        #region 删除会员全部系统信息记录
        /// <summary>
        /// 删除会员全部系统信息记录
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        int DeleteUserMessageAll( int userID );
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
        DataSet GetMemberCenterForUserMessageList( int userID, int FIdx, int EIdx, bool isCount, out int totalCount, out int privMsgCount );
        #endregion

        #region 私信数据调用 2012.8
        /// <summary>
        /// 屏蔽某私信记录
        /// </summary>
        /// <param name="msgID">消息ID</param>
        /// <param name="userID">接收会员ID</param>
        /// <param name="oppUserID">会话对方会员ID</param>
        /// <returns></returns>
        int DeleteUserPrivMsg( int msgID, int userID, int oppUserID );

        /// <summary>
        /// 清空某好友所有私信记录
        /// </summary>
        /// <param name="userID">接收会员ID</param>
        /// <param name="senderUserID">发送会员ID</param>
        /// <returns></returns>
        int DeleteUserPrivMsgHead( int userID, int senderUserID );

        /// <summary>
        /// 清空会员所有私信记录
        /// </summary>
        /// <param name="userID">接收会员ID</param>
        /// <returns></returns>
        int DeleteUserPrivMsgHeadAll( int userID );

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
        DataSet GetUserPrivMsgDetailList( int userID, int sendUserID, int FIdx, int EIdx, bool isCount, out int totalCount );

        /// <summary>
        /// 获取会员所有私信分页记录
        /// </summary>
        /// <param name="userID">接收会员ID</param>
        /// <param name="FIdx">记录开始序号</param>
        /// <param name="EIdx">记录结束序号</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        DataSet GetUserPrivMsgList( int userID, int FIdx, int EIdx, bool isCount, out int totalCount );
        #endregion

        #region 手机版清除会员所有消息[系统、好友申请、私信]
        /// <summary>
        /// 手机版清除会员所有消息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        int ClearUserAllMessage( int userID );
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
        DataSet GetReplyMsgPageByUserID( int userID, int FIdx, int EIdx, int isCount, out int totalCount );
        #endregion

        #region 用户删除晒单或话题的评论回复消息
        /// <summary>
        /// 用户删除晒单或话题的评论回复消息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="msgID">消息ID 等于0则删除全部</param>
        /// <returns></returns>
        int DeleteReplyMsgByUserID( int userID, int msgID );
        #endregion
    }
}
