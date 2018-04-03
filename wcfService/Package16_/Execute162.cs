using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class ExecuteFun
    {

        #region 获取类型项目数量和机构项目数量16201
        /// <summary>
        /// 获取类型项目数量和机构项目数量16201
        /// </summary>
        /// <param name="fundType"></param>
        /// <param name="fundInst"></param>
        /// <returns></returns>
        public static int GetFundItemCount( params object[] para )
        {
            int _Result = 0;
            try
            {
                int _FundType = (int)para[0];
                int _FundInst = (int)para[1];
                using ( IDALGongYi _DAL = new DALGongYi() )
                {
                    _Result = _DAL.GetFundItemCount( _FundType, _FundInst );
                }
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetFundItemCount Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 获取公益项目累计拨出善款16202
        /// <summary>
        /// 获取公益项目累计拨出善款16202
        /// </summary>
        /// <param name="fundType"></param>
        /// <returns></returns>
        public static decimal GetFundItemMoney( params object[] para )
        {
            decimal _Result = 0;
            try
            {
                int _FundType = (int)para[0];
                using ( IDALGongYi _DAL = new DALGongYi() )
                {
                    _Result = _DAL.GetFundItemMoney( _FundType );
                }
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetFundItemMoney Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 公益项目点赞16203
        /// <summary>
        /// 公益项目点赞16203
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="Ip"></param>
        /// <returns></returns>
        public static int ModFundItemHit( params object[] para )
        {
            int _Result = -200;
            try
            {
                int _ItemID = (int)para[0];
                string _Ip = (string)para[1];
                using ( IDALGongYi _DAL = new DALGongYi() )
                {
                    _Result = _DAL.ModFundItemHit( _ItemID, _Ip );
                }
            }
            catch ( Exception ex )
            {
                _Result = -202;
                UtilityFile.AddLogErrMsg( "ModFundItemHit Ex: " + ex.Message );
            }
            return _Result;

        }
        #endregion
        #region 公益项目阅读量16204
        /// <summary>
        /// 公益项目阅读量16204
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public static int ModFundItemRead( params object[] para )
        {
            int _Result = -200;
            try
            {
                int _ItemID = (int)para[0];
                using ( IDALGongYi _DAL = new DALGongYi() )
                {
                    _Result = _DAL.ModFundItemRead( _ItemID );
                }
            }
            catch ( Exception ex )
            {
                _Result = -202;
                UtilityFile.AddLogErrMsg( "ModFundItemRead Ex: " + ex.Message );
            }
            return _Result;
        }
        #endregion
        #region 获取公益项目推荐详情16205
        /// <summary>
        /// 获取公益项目推荐详情16205
        /// </summary>
        /// <param name="type"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <returns></returns>
        public static DataSet GetFundItemRecomand( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int _Type = (int)para[0];
                int _Fidx = (int)para[1];
                int _Eidx = (int)para[2];
                using ( IDALGongYi _DAL = new DALGongYi() )
                {
                    _DS = _DAL.GetFundItemRecomand( _Type, _Fidx, _Eidx );
                }
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetFundItemRecomand Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 获取公益项目-前台界面16206
        /// <summary>
        /// 获取公益项目-前台界面16206
        /// </summary>
        /// <param name="fundType"></param>
        /// <param name="itemID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <returns></returns>
        public static DataSet GetFundItemForWeb( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int _FundType = (int)para[0];
                int _ItemID = (int)para[1];
                int _Fidx = (int)para[2];
                int _Eidx = (int)para[3];
                using ( IDALGongYi _DAL = new DALGongYi() )
                {
                    _DS = _DAL.GetFundItemForWeb( _FundType, _ItemID, _Fidx, _Eidx );
                }
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetFundItemForWeb Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 获取某个公益项目明细16207
        /// <summary>
        /// 获取某个公益项目明细16207
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public static DataSet GetFundItemDetailById( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int _ItemID = (int)para[0];
                using ( IDALGongYi _DAL = new DALGongYi() )
                {
                    _DS = _DAL.GetFundItemDetailById( _ItemID );
                }
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetFundItemDetailById Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
        #region 获取公益广告信息16208
        /// <summary>
        /// 获取公益广告信息16208
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public static DataSet GetFundAdByAdType( params object[] para )
        {
            DataSet _DS = null;
            try
            {
                int _AdID = (int)para[0];
                int _AdType = (int)para[1];
                int _FIdx = (int)para[2];
                int _EIdx = (int)para[3];

                using ( IDALGongYi _DAL = new DALGongYi() )
                {
                    _DS = _DAL.GetFundAdByAdType( _AdID, _AdType, _FIdx, _EIdx );
                }
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "GetFundAdByAdType Ex: " + ex.Message );
            }
            return _DS;
        }
        #endregion
    }
}
