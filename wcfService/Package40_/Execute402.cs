using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class ExecuteFun
    {

        #region 返回小程序会员中心用户云购信息40201
        /// <summary>
        /// 返回小程序会员中心用户云购信息40201
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static DataSet GetUserBuyInfoByUserID( out int count, params object[] para )
        {
            DataSet _DS = null;
            count = 0;
            try
            {
                int _UserID = (int)para[0];
                DateTime _BeginTime = (DateTime)para[1];
                DateTime _EndTime = (DateTime)para[2];
                int _Fidx = (int)para[3];
                int _Eidx = (int)para[4];
                int _IsCount = (int)para[5];
                if ( _UserID > 0 )
                {
                    IDALUserBuy _DAL = new DALUserBuy();
                    _DS = _DAL.GetUserBuyInfoByUserID( _UserID, _BeginTime, _EndTime, _Fidx, _Eidx, _IsCount, out count );
                    _DAL = null;
                }
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetUserBuyInfoByUserID Ex: " + ex.Message );
            }
            return _DS;
        }

        #endregion
    }
}
