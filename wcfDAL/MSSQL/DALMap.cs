using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALMap : DALBase, IDALMap
    {
        #region 获取地区统计信息[不含搜索]
        /// <summary>
        /// 获取地区统计信息[不含搜索]
        /// </summary>
        /// <param name="level">
        /// 1：全国各省的统计(以下的经纬度就无效)
        /// 2：可视区域各省下各市的统计
        /// 3：可视区域各省下各区县的统计
        /// </param>
        /// <param name="longitude1"></param>
        /// <param name="latitude1"></param>
        /// <param name="longitude2"></param>
        /// <param name="latitude2"></param>
        /// <returns></returns>
        public DataSet GetAreaStatByLevel( int level, decimal longitude1, decimal latitude1, decimal longitude2, decimal latitude2 )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "14101" );
            Para.AddOrcNewInParameter( "i_level", level );
            Para.AddOrcNewInParameter( "i_longitude1", longitude1 );
            Para.AddOrcNewInParameter( "i_latitude1", latitude1 );
            Para.AddOrcNewInParameter( "i_longitude2", longitude2 );
            Para.AddOrcNewInParameter( "i_latitude2", latitude2 );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_map.sp_getareastatbylevel" );
        }
        #endregion

        #region 获取地区详细点信息
        /// <summary>
        /// 获取地区详细点信息
        /// </summary>
        /// <param name="areaID"></param>
        /// <param name="longitude1"></param>
        /// <param name="latitude1"></param>
        /// <param name="longitude2"></param>
        /// <param name="latitude2"></param>
        /// <returns></returns>
        public DataSet GetDetailPointByAreaId( int areaID, decimal longitude1, decimal latitude1, decimal longitude2, decimal latitude2 )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "14102" );
            Para.AddOrcNewInParameter( "i_areaid", areaID );
            Para.AddOrcNewInParameter( "i_longitude1", longitude1 );
            Para.AddOrcNewInParameter( "i_latitude1", latitude1 );
            Para.AddOrcNewInParameter( "i_longitude2", longitude2 );
            Para.AddOrcNewInParameter( "i_latitude2", latitude2 );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_map.sp_getdetailpointbyareaid" );
        }
        #endregion

        #region 根据关键字返回商品列表页面数据
        /// <summary>
        /// 根据关键字返回商品列表页面数据
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataSet GetGoodsByKeyWord( string keywords, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "14103" );
            Para.AddOrcNewInParameter( "i_keywords", keywords );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_isCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_map.sp_getGoodsByKeyWord" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region 根据商品ID获取所有的收货地址和坐标点
        /// <summary>
        /// 根据商品ID获取所有的收货地址和坐标点
        /// </summary>
        /// <param name="level">
        /// 1.全国各省的统计，
        /// 2.根据经纬度来查出个市的统计，
        /// 3.根据经纬度来查出个区县的统计，
        /// 4.根据经纬度来查出个详细的点</param>
        /// <param name="goodsID"></param>
        /// <param name="longitude1"></param>
        /// <param name="latitude1"></param>
        /// <param name="longitude2"></param>
        /// <param name="latitude2"></param>
        /// <returns></returns>
        public DataSet GetAreaGoodsByGoodsID( int level, int goodsID, decimal longitude1, decimal latitude1, decimal longitude2, decimal latitude2 )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "14104" );
            Para.AddOrcNewInParameter( "i_Level", level );
            Para.AddOrcNewInParameter( "i_goodsid", goodsID );
            Para.AddOrcNewInParameter( "i_longitude1", longitude1 );
            Para.AddOrcNewInParameter( "i_latitude1", latitude1 );
            Para.AddOrcNewInParameter( "i_longitude2", longitude2 );
            Para.AddOrcNewInParameter( "i_latitude2", latitude2 );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_map.sp_getAreaGoodsByGoodsID" );
        }
        #endregion

        #region 根据坐标查出订单
        /// <summary>
        /// 根据坐标查出订单
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="goodsID"></param>
        /// <param name="userID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataSet GetOrderDetailByPoint( decimal longitude, decimal latitude, int goodsID, int userID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "14105" );
            Para.AddOrcNewInParameter( "i_longitude", longitude );
            Para.AddOrcNewInParameter( "i_latitude", latitude );
            Para.AddOrcNewInParameter( "i_goodsID", goodsID );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_isCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_map.sp_getorderdetailbypoint" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region 按用户昵称搜索
        /// <summary>
        /// 按用户昵称搜索
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataSet GetUserByKeywords( string keyword, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "14106" );
            Para.AddOrcNewInParameter( "i_keywords", keyword );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_isCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_map.sp_getUserByKeywords" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region 根据用户ID查订单经纬度
        /// <summary>
        /// 根据用户ID查订单经纬度
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetOrdersByUserId( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "14107" );
            Para.AddOrcNewInParameter( "i_userID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_map.sp_getordersbyuserid" );
        }
        #endregion

        #region 分页获取商品分类信息列表
        /// <summary>
        /// 分页获取商品分类信息列表
        /// </summary>
        /// <param name="sortID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataSet GetGoodsInfoBySortID( int sortID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "14110" );
            Para.AddOrcNewInParameter( "i_SortID", sortID );
            Para.AddOrcNewInParameter( "i_FIdx", FIdx );
            Para.AddOrcNewInParameter( "i_EIdx", EIdx );
            Para.AddOrcNewInParameter( "i_isCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_map.sp_getGoodsInfoBySortID" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region   根据可视范围获取用户列表
        /// <summary>
        /// 根据可视范围获取用户列表
        /// </summary>
        /// <param name="longitude1"></param>
        /// <param name="latitude1"></param>
        /// <param name="longitude2"></param>
        /// <param name="latitude2"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public DataSet GetUserInfoByLonLat(decimal longitude1, decimal latitude1,decimal longitude2, decimal latitude2,int FIdx, int EIdx, int isCount, out int totalCount)
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "14111" );
            Para.AddOrcNewInParameter( "i_longitude1", longitude1 );
            Para.AddOrcNewInParameter( "i_latitude1", latitude1 );
            Para.AddOrcNewInParameter( "i_longitude2", longitude2 );
            Para.AddOrcNewInParameter( "i_latitude2", latitude2 );
            Para.AddOrcNewInParameter("i_FIdx",FIdx);
            Para.AddOrcNewInParameter("i_EIdx",EIdx);
            Para.AddOrcNewInParameter( "i_isCount", isCount );
            Para.AddOrcNewCursorParameter( "o_result" );
            DataSet _DS = Dal.ExecuteFillDataSet( "yun_map.sp_getUserInfoByLonLat" );
            totalCount = GetOrcTotalCount( isCount, _DS );
            return _DS;
        }
        #endregion

        #region   获取订单总数
        /// <summary>
        /// 获取订单总数
        /// </summary>
        /// <returns></returns>
        public DataSet GetOrderTotal()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "14112" );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_map.sp_getOrderTotal" );
        }
        #endregion
    }
}
