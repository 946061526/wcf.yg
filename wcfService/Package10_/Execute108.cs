using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 获取全站历史云购记录10801
        /// <summary>
        /// 获取全站历史云购记录10801
        /// </summary>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        public static DataSet GetUsersHistoryBuyRecords( out int count, params object[] para )
        {
            int FIdx = (int)para[0];
            int EIdx = (int)para[1];
            DateTime beginTime = (DateTime)para[2];
            DateTime endTime = (DateTime)para[3];
            int isCount = (int)para[4];
            DataSet _DS = null;
            count = 0;
            try
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _DS = _DAL.GetUsersHistoryBuyRecords( FIdx, EIdx, beginTime, endTime, isCount, out count );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UserBuy.GetUsersHistoryBuyRecords抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 获取开奖基数计算的100条记录10802
        /// <summary>
        /// 获取开奖基数计算的100条记录10802
        /// </summary>
        /// <param name="endTime">截止时间</param>
        /// <returns></returns>
        public static DataSet GetRaffleDataByTime( params object[] para )
        {
            DateTime endTime = (DateTime)para[0];
            DataSet _DS = null;
            try
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _DS = _DAL.GetRaffleDataByTime( endTime );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UserBuy.GetRaffleDataByTime Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 获取网站最新100条云购记录10803
        /// <summary>
        /// 获取网站最新100条云购记录10803
        /// </summary>
        /// <param name="buyID">buyID</param>
        /// <returns></returns>
        public static DataSet GetUserBuyRecentlyList( params object[] para )
        {
            int buyID = (int)para[0];
            DataSet _DS = null;
            try
            {
                IDALUserBuy _DAL = new DALUserBuy();
                _DS = _DAL.GetUserBuyRecentlyList( buyID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UserBuy.GetUserBuyRecentlyList抛出异常：" + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 获取一个时间段的前后N条记录10804
        /// <summary>
        /// 获取一个时间段的前后N条记录10804
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns></returns>
        public static DataSet GetUserBuyRecordsEndView( params object[] para )
        {
            DateTime time = (DateTime)para[0];
            DataSet _DSRes = null;
            try
            {
                IDALUserBuy _DAL = new DALUserBuy();
                DataSet _DSTmp = _DAL.GetUserBuyRecordsEndView( time );
                _DAL = null;

                //oracle那边返回表为两个，第一个最新5条[可能为空表]，第二个后面105条
                if ( _DSTmp != null && _DSTmp.Tables.Count == 2 && _DSTmp.Tables[1].Rows.Count == 105 )
                {
                    _DSRes = new DataSet();
                    _DSRes.Tables.Add( _DSTmp.Tables[0].Copy() );
                    DataTable _DT = _DSTmp.Tables[1].Clone();
                    _DT.TableName = "Table2";
                    for ( int i = 0; i < 5; i++ )//把后面5条放到第三个表
                    {
                        _DT.ImportRow( _DSTmp.Tables[1].Rows[100] );
                        _DSTmp.Tables[1].Rows.RemoveAt( 100 );
                    }
                    _DSRes.Tables.Add( _DSTmp.Tables[1].Copy() );
                    _DSRes.Tables.Add( _DT );
                    _DT = null;
                }
                _DSTmp = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "UserBuy.GetUserBuyRecordsEndView抛出异常：" + ex.Message );
            }
            return _DSRes;
        }
        #endregion
    }
}
