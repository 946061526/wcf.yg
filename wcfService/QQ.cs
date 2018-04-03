using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
    {
        #region 获取QQ群帐号置顶列表
        /// <summary>
        /// 获取QQ群帐号置顶列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetQQAccountTopList()
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

        #region 获取QQ群帐号列表
        /// <summary>
        /// 获取QQ群帐号列表
        /// </summary>
        /// <param name="areaID">区域</param>
        /// <param name="key">查询关键字</param>
        /// <param name="FIdx">开始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public DataSet GetQQAccountPageList( int areaID, string key, int FIdx, int EIdx, bool isCount, out int totalCount )
        {
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
    }
}
