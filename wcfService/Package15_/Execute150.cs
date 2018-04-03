using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class ExecuteFun
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
        public static int InsertBarInfo( params object[] para )
        {
            int _Result = -200;
            try
            {
                int _InviteUserID = (int)para[0];
                string _BarNO = (string)para[1];
                string _BarName = (string)para[2];
                string _BarMemo = (string)para[3];
                string _InviteUrl = (string)para[4];
                using ( IDALPartner _DAL = new DALPartner() )
                {
                    _Result = _DAL.InsertBarInfo( _InviteUserID, _BarNO, _BarName, _BarMemo, _InviteUrl );
                }
            }
            catch ( Exception ex )
            {
                _Result = -202;
                UtilityFile.AddLogErrMsg( "InsertBarInfo Ex: " + ex.Message );
            }
            return _Result;
        }
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
        public static int UpdateBarInfo( params object[] para )
        {
            int _Result = -200;
            try
            {
                int _BarID = (int)para[0];
                string _BarNO = (string)para[1];
                string _BarName = (string)para[2];
                string _BarMemo = (string)para[3];
                string _InviteUrl = (string)para[4];
                using ( IDALPartner _DAL = new DALPartner() )
                {
                    _Result = _DAL.UpdateBarInfo( _BarID, _BarNO, _BarName, _BarMemo, _InviteUrl );
                }
            }
            catch ( Exception ex )
            {
                _Result = -202;
                UtilityFile.AddLogErrMsg( "UpdateBarInfo Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion

        #region 添加网吧邀请用户的关系数据
        /// <summary>
        /// 添加网吧邀请用户的关系数据
        /// </summary>
        /// <param name="barNO">网吧标识</param>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static int InsertBarInviteUser( params object[] para )
        {
            int _Result = -200;
            try
            {
                string _BarNO = (string)para[0];
                int _UserID = (int)para[1];
                using ( IDALPartner _DAL = new DALPartner() )
                {
                    _Result = _DAL.InsertBarInviteUser( _BarNO, _UserID );
                }
            }
            catch ( Exception ex )
            {
                _Result = -202;
                UtilityFile.AddLogErrMsg( "InsertBarInviteUser Ex: " + ex.Message );
            }
            return _Result;
        }
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
        /// <returns></returns>
        public static DataSet GetBarInfoPageList( out int totalCount, out int totalPerson, params object[] para )
        {
            DataSet _DS = null;
            totalCount = 0;
            totalPerson = 0;
            try
            {
                string _BarNO = (string)para[0];
                int _FIdx = (int)para[1];
                int _EIdx = (int)para[2];
                int _IsCount = (int)para[3];
                using ( IDALPartner _DAL = new DALPartner() )
                {
                    _DS = _DAL.GetBarInfoPageList( _BarNO, _FIdx, _EIdx, _IsCount, out totalCount, out totalPerson );
                }
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetBarInfoPageList Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
    }
}
