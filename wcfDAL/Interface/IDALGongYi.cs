using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALGongYi : IDisposable
    {
        #region 获取类型项目数量和机构项目数量16201
        /// <summary>
        /// 获取类型项目数量和机构项目数量16201
        /// </summary>
        /// <param name="fundType"></param>
        /// <param name="fundInst"></param>
        /// <returns></returns>
        int GetFundItemCount( int fundType, int fundInst );
        #endregion
        #region 获取公益项目累计拨出善款16202
        /// <summary>
        /// 获取公益项目累计拨出善款16202
        /// </summary>
        /// <param name="fundType"></param>
        /// <returns></returns>
        decimal GetFundItemMoney( int fundType );
        #endregion
        #region 公益项目点赞16203
        /// <summary>
        /// 公益项目点赞16203
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="Ip"></param>
        /// <returns></returns>
        int ModFundItemHit( int itemID, string Ip );
        #endregion
        #region 公益项目阅读量16204
        /// <summary>
        /// 公益项目阅读量16204
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        int ModFundItemRead( int itemID );
        #endregion
        #region 获取公益项目推荐详情16205
        /// <summary>
        /// 获取公益项目推荐详情16205
        /// </summary>
        /// <param name="type"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <returns></returns>
        DataSet GetFundItemRecomand( int type, int FIdx, int EIdx );
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
        DataSet GetFundItemForWeb( int fundType, int itemID, int FIdx, int EIdx );
        #endregion
        #region 获取某个公益项目明细16207
        /// <summary>
        /// 获取某个公益项目明细16207
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        DataSet GetFundItemDetailById( int itemID );
        #endregion
        #region 获取公益广告信息16208
        /// <summary>
        /// 获取公益广告信息16208
        /// </summary>
        /// <param name="adID"></param>
        /// <param name="adType"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <returns></returns>
        DataSet GetFundAdByAdType( int adID, int adType, int FIdx, int EIdx );
        #endregion


    }
}
