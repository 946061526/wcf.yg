using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
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
        public DataSet mapGetAreaStatByLevel( int level, decimal longitude1, decimal latitude1, decimal longitude2, decimal latitude2 )
        {
            DataSet _DS = null;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetAreaStatByLevel( level, longitude1, latitude1, longitude2, latitude2 );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Map.mapGetAreaStatByLevel Exception:" + ex.Message );
            }
            return _DS;
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
        public DataSet mapGetDetailPointByAreaId( int areaID, decimal longitude1, decimal latitude1, decimal longitude2, decimal latitude2 )
        {
            DataSet _DS = null;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetDetailPointByAreaId( areaID, longitude1, latitude1, longitude2, latitude2 );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Map.mapGetDetailPointByAreaId Exception:" + ex.Message );
            }
            return _DS;
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
        public DataSet mapGetOrderDetailByPoint( decimal longitude, decimal latitude, int goodsID, int userID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetOrderDetailByPoint( longitude, latitude,goodsID,  userID,  FIdx,  EIdx,  isCount, out  totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Map.mapGetOrderDetailByPoint Exception:" + ex.Message );
            }
            return _DS;
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
        public DataSet mapGetGoodsByKeyWord( string keywords, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetGoodsByKeyWord( keywords, FIdx, EIdx, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Map.mapGetGoodsByKeyWord Exception:" + ex.Message );
            }
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
        public DataSet mapGetAreaGoodsByGoodsID( int level, int goodsID, decimal longitude1, decimal latitude1, decimal longitude2, decimal latitude2 )
        {
            DataSet _DS = null;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetAreaGoodsByGoodsID( level, goodsID, longitude1, latitude1, longitude2, latitude2 );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Map.mapGetAreaGoodsByGoodsID Exception:" + ex.Message );
            }
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
        public DataSet mapGetUserByKeywords( string keyword, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetUserByKeywords( keyword, FIdx, EIdx, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Map.mapGetUserByKeywords Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region 根据userID获取订单信息
        /// <summary>
        /// 根据userID获取订单信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet mapGetOrdersByUserId( int userID )
        {
            DataSet _DS = null;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetOrdersByUserId( userID );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Map.mapGetOrdersByUserId Exception:" + ex.Message );
            }
            return _DS;
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
        public DataSet mapGetGoodsInfoBySortID( int sortID, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount=0;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetGoodsInfoBySortID( sortID, FIdx, EIdx, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Map.mapGetGoodsInfoBySortID Exception:" + ex.Message );
            }
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
        public DataSet mapGetUserInfoByLonLat( decimal longitude1, decimal latitude1, decimal longitude2, decimal latitude2, int FIdx, int EIdx, int isCount, out int totalCount )
        {
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetUserInfoByLonLat( longitude1, latitude1, longitude2, latitude2, FIdx, EIdx, isCount, out totalCount );
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Map.GetUserInfoByLonLat Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion

        #region   获取订单总数
        /// <summary>
        /// 获取订单总数
        /// </summary>
        /// <returns></returns>
        public DataSet mapGetOrderTotal()
        {
            DataSet _DS = null;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetOrderTotal();
                _DAL = null;
            }
            catch ( Exception ex )
            {
                UtilityFile.AddLogErrMsg( "Map.GetOrderTotal Exception:" + ex.Message );
            }
            return _DS;
        }
        #endregion
    }
}
