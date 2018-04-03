using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 获取地区统计信息[不含搜索]14101
        /// <summary>
        /// 获取地区统计信息[不含搜索]14101
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
        public static DataSet mapGetAreaStatByLevel(params object[] para)
        {
            int level = (int)para[0];
            decimal longitude1 = (decimal)para[1];
            decimal latitude1 = (decimal)para[2];
            decimal longitude2 = (decimal)para[3];
            decimal latitude2 = (decimal)para[4];
            DataSet _DS = null;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetAreaStatByLevel(level, longitude1, latitude1, longitude2, latitude2);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Map.mapGetAreaStatByLevel Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
        #region 获取地区详细点信息14102
        /// <summary>
        /// 获取地区详细点信息14102
        /// </summary>
        /// <param name="areaID"></param>
        /// <param name="longitude1"></param>
        /// <param name="latitude1"></param>
        /// <param name="longitude2"></param>
        /// <param name="latitude2"></param>
        /// <returns></returns>
        public static DataSet mapGetDetailPointByAreaId(params object[] para)
        {
            int areaID = (int)para[0];
            decimal longitude1 = (decimal)para[1];
            decimal latitude1 = (decimal)para[2];
            decimal longitude2 = (decimal)para[3];
            decimal latitude2 = (decimal)para[4];
            DataSet _DS = null;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetDetailPointByAreaId(areaID, longitude1, latitude1, longitude2, latitude2);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Map.mapGetDetailPointByAreaId Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
        #region 根据关键字返回商品列表页面数据14103
        /// <summary>
        /// 根据关键字返回商品列表页面数据14103
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public static DataSet mapGetGoodsByKeyWord(out int totalCount, params object[] para)
        {
            string keywords = (string)para[0];
            int FIdx = (int)para[1];
            int EIdx = (int)para[2];
            int isCount = (int)para[3];
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetGoodsByKeyWord(keywords, FIdx, EIdx, isCount, out totalCount);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Map.mapGetGoodsByKeyWord Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
        #region 根据商品ID获取所有的收货地址和坐标点14104
        /// <summary>
        /// 根据商品ID获取所有的收货地址和坐标点14104
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
        public static DataSet mapGetAreaGoodsByGoodsID(params object[] para)
        {
            int level = (int)para[0];
            int goodsID = (int)para[1];
            decimal longitude1 = (decimal)para[2];
            decimal latitude1 = (decimal)para[3];
            decimal longitude2 = (decimal)para[4];
            decimal latitude2 = (decimal)para[5];
            DataSet _DS = null;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetAreaGoodsByGoodsID(level, goodsID, longitude1, latitude1, longitude2, latitude2);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Map.mapGetAreaGoodsByGoodsID Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
        #region 根据坐标查出订单14105
        /// <summary>
        /// 根据坐标查出订单14105
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
        public static DataSet mapGetOrderDetailByPoint(out int totalCount, params object[] para)
        {
            decimal longitude = (decimal)para[0];
            decimal latitude = (decimal)para[1];
            int goodsID = (int)para[2];
            int userID = (int)para[3];
            int FIdx = (int)para[4];
            int EIdx = (int)para[5];
            int isCount = (int)para[6];
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetOrderDetailByPoint(longitude, latitude, goodsID, userID, FIdx, EIdx, isCount, out  totalCount);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Map.mapGetOrderDetailByPoint Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
        #region 按用户昵称搜索14106
        /// <summary>
        /// 按用户昵称搜索14106
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public static DataSet mapGetUserByKeywords(out int totalCount, params object[] para)
        {
            string keyword = (string)para[0];
            int FIdx = (int)para[1];
            int EIdx = (int)para[2];
            int isCount = (int)para[3];
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetUserByKeywords(keyword, FIdx, EIdx, isCount, out totalCount);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Map.mapGetUserByKeywords Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
        #region 根据userID获取订单信息14107
        /// <summary>
        /// 根据userID获取订单信息14107
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataSet mapGetOrdersByUserId(params object[] para)
        {
            int userID = (int)para[0];
            DataSet _DS = null;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetOrdersByUserId(userID);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Map.mapGetOrdersByUserId Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
        #region 分页获取商品分类信息列表14110
        /// <summary>
        /// 分页获取商品分类信息列表14110
        /// </summary>
        /// <param name="sortID"></param>
        /// <param name="FIdx"></param>
        /// <param name="EIdx"></param>
        /// <param name="isCount"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public static DataSet mapGetGoodsInfoBySortID(out int totalCount, params object[] para)
        {
            int sortID = (int)para[0];
            int FIdx = (int)para[1];
            int EIdx = (int)para[2];
            int isCount = (int)para[3];
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetGoodsInfoBySortID(sortID, FIdx, EIdx, isCount, out totalCount);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Map.mapGetGoodsInfoBySortID Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
        #region   根据可视范围获取用户列表14111
        /// <summary>
        /// 根据可视范围获取用户列表14111
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
        public static DataSet mapGetUserInfoByLonLat(out int totalCount, params object[] para)
        {
            decimal longitude1 = (decimal)para[0];
            decimal latitude1 = (decimal)para[1];
            decimal longitude2 = (decimal)para[2];
            decimal latitude2 = (decimal)para[3];
            int FIdx = (int)para[4];
            int EIdx = (int)para[5];
            int isCount = (int)para[6];
            DataSet _DS = null;
            totalCount = 0;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetUserInfoByLonLat(longitude1, latitude1, longitude2, latitude2, FIdx, EIdx, isCount, out totalCount);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Map.GetUserInfoByLonLat Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
        #region 获取订单总数14112
        /// <summary>
        /// 获取订单总数14112
        /// </summary>
        /// <returns></returns>
        public static DataSet mapGetOrderTotal()
        {
            DataSet _DS = null;
            try
            {
                IDALMap _DAL = new DALMap();
                _DS = _DAL.GetOrderTotal();
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("Map.GetOrderTotal Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
    }
}
