using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALPartner : IDisposable
    {
        #region 添加网吧信息
        /// <summary>
        /// 添加网吧信息
        /// </summary>
        /// <param name="inviteUserID">邀请者ID</param>
        /// <param name="barNO">网吧标识</param>
        /// <param name="barName">网吧名称</param>
        /// <param name="barMemo">网吧备注</param>
        /// <param name="inviteUrl">邀请链接</param>
        /// <returns></returns>
        int InsertBarInfo( int inviteUserID, string barNO, string barName, string barMemo, string inviteUrl );
        #endregion

        #region 修改网吧信息
        /// <summary>
        /// 修改网吧信息
        /// </summary>
        /// <param name="barID">记录ID</param>
        /// <param name="barNO">网吧标识</param>
        /// <param name="barName">网吧名称</param>
        /// <param name="barMemo">网吧备注</param>
        /// <param name="inviteUrl">邀请链接</param>
        /// <returns></returns>
        int UpdateBarInfo( int barID, string barNO, string barName, string barMemo, string inviteUrl );
        #endregion

        #region 添加网吧邀请用户的关系数据
        /// <summary>
        /// 添加网吧邀请用户的关系数据
        /// </summary>
        /// <param name="barNO">网吧标识</param>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        int InsertBarInviteUser( string barNO, int userID );
        #endregion

        #region 分页获取网吧信息列表
        /// <summary>
        /// 分页获取网吧信息列表
        /// </summary>
        /// <param name="barNO">网吧标识</param>
        /// <param name="FIdx">起始</param>
        /// <param name="EIdx">结束</param>
        /// <param name="isCount">是否统计总数</param>
        /// <param name="totalCount">返回总记录数</param>
        /// <param name="totalPerson">返回总邀请人数</param>
        /// <returns></returns>
        DataSet GetBarInfoPageList( string barNO, int FIdx, int EIdx, int isCount, out int totalCount, out int totalPerson );
        #endregion
    }
}
