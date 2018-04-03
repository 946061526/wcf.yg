using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALGongYi : DALBase, IDALGongYi
    {
        #region 获取类型项目数量和机构项目数量
        /// <summary>
        /// 获取类型项目数量和机构项目数量
        /// </summary>
        /// <param name="fundType"></param>
        /// <param name="fundInst"></param>
        /// <returns></returns>
        public int GetFundItemCount( int fundType, int fundInst )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "16201" );
            Para.AddOrcNewInParameter( "i_fundtype", fundType );
            Para.AddOrcNewInParameter( "i_fundinst", fundInst );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_fund.f_getFundItemCount" );
            return ToInt32( Para.GetOrcParameter( "retVal" ) );

        }
        #endregion
        #region 获取公益项目累计拨出善款
        /// <summary>
        /// 获取公益项目累计拨出善款
        /// </summary>
        /// <param name="fundType"></param>
        /// <returns></returns>
        public decimal GetFundItemMoney( int fundType )
        {
            decimal _Result = 0m;
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "16202" );
            Para.AddOrcNewInParameter( "i_fundtype", fundType );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_fund.sp_getFundItemMoney" );
            if ( _DS != null && _DS.Tables.Count > 0 && _DS.Tables[0].Rows.Count > 0 )
            {
                _Result = ToDecimal( _DS.Tables[0].Rows[0]["itemmoney"] );
            }
            return _Result;
        }
        #endregion
        #region 公益项目点赞
        /// <summary>
        /// 公益项目点赞
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="Ip"></param>
        /// <returns></returns>
        public int ModFundItemHit( int itemID, string Ip )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "16203" );
            Para.AddOrcNewInParameter( "i_itemid", itemID );
            Para.AddOrcNewInParameter( "i_ip", Ip );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_fund.f_modFundItemHit" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion
        #region 公益项目阅读量
        /// <summary>
        /// 公益项目阅读量
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public int ModFundItemRead( int itemID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "16204" );
            Para.AddOrcNewInParameter( "i_itemid", itemID );
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Dal.ExecuteNonQuery( "yun_fund.f_modFundItemRead" );
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion
        #region 获取公益项目推荐详情
        /// <summary>
        /// 获取公益项目推荐详情
        /// </summary>
        /// <param name="type"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <returns></returns>
        public DataSet GetFundItemRecomand( int type, int FIdx, int EIdx )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "16205" );
            Para.AddOrcNewInParameter( "i_type", type );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_fund.sp_getFundItemRecomand" );
        }
        #endregion
        #region 获取公益项目-前台界面
        /// <summary>
        /// 获取公益项目-前台界面
        /// </summary>
        /// <param name="fundType"></param>
        /// <param name="itemID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <returns></returns>
        public DataSet GetFundItemForWeb( int fundType, int itemID, int FIdx, int EIdx )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "16206" );
            Para.AddOrcNewInParameter( "i_fundtype", fundType );
            Para.AddOrcNewInParameter( "i_itemid", itemID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_fund.sp_getFundItemForWeb" );
        }
        #endregion
        #region 获取某个公益项目明细
        /// <summary>
        /// 获取某个公益项目明细
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public DataSet GetFundItemDetailById( int itemID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "16207" );
            Para.AddOrcNewInParameter( "i_itemid", itemID );
            Para.AddOrcNewCursorParameter( "o_result_desc" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_fund.sp_getFundItemDetailById" );
        }
        #endregion

        #region 获取公益广告信息
        /// <summary>
        /// 获取公益广告信息16208
        /// </summary>
        /// <param name="adID"></param>
        /// <param name="adType"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <returns></returns>
        public DataSet GetFundAdByAdType( int adID, int adType, int FIdx, int EIdx )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "16208" );
            Para.AddOrcNewInParameter( "i_adid", adID );
            Para.AddOrcNewInParameter( "i_adtype", adType );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_fund.sp_getFundAdByAdType" );
        }
        #endregion


        #region IDisposable 成员

        public void Dispose()
        {

        }

        #endregion
    }
}
