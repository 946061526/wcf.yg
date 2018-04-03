using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 添加关键词14401
        /// <summary>
        /// 添加关键词14401
        /// </summary>
        /// <param name="keyType">分类:1.广告骚扰 2.欺诈骗钱 3.诅咒谩骂 4.淫秽色情 5.政治 6.其它</param>
        /// <param name="keywords">关键词内容</param>
        /// <param name="filterType">过虑方式，1.普通关键词过虑，2.正则表达式匹配</param>
        /// <param name="keywordsDesc">描述</param>
        /// <param name="keywordsAlt">提示</param>
        /// <returns></returns>
        public static int FilterInsertKeywords(params object[] para)
        {
            int keyType = (int)para[0];
            string keywords = (string)para[1];
            int filterType = (int)para[2];
            string keywordsDesc = (string)para[3];
            string keywordsAlt = (string)para[4];
            int _Result = 0;
            if (filterType > 0 && keywords != "")
            {
                try
                {
                    IDALCharFilter _DAL = new DALCharFilter();
                    _Result = _DAL.InsertKeywords(keyType, keywords, filterType, keywordsDesc, keywordsAlt);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("CharFilter.FilterInsertKeywords Exception:" + ex.Message);
                }
            }
            return _Result;
        }
        #endregion
        #region 删除关键词14402
        /// <summary>
        /// 删除关键词14402
        /// </summary>
        /// <param name="keywordsID">关键词标识ID</param>
        /// <returns></returns>
        public static int FilterDeleteKeywords(params object[] para)
        {
            int keywordsID = (int)para[0];
            int _IsSuccess = 0;
            if (keywordsID > 0)
            {
                try
                {
                    IDALCharFilter _DAL = new DALCharFilter();
                    _IsSuccess = _DAL.DeleteKeywords(keywordsID)?1:0;
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("CharFilter.FilterDeleteKeywords Exception:" + ex.Message);
                }
            }
            return _IsSuccess;
        }
        #endregion
        #region 查询所有的关键词14403
        /// <summary>
        /// 查询所有的关键词14403
        /// </summary>
        /// <returns></returns>
        public static DataSet FilterGetAllKeyWords()
        {
            DataSet _DS = null;
            try
            {
                IDALCharFilter _DAL = new DALCharFilter();
                _DS = _DAL.GetAllKeyWords();
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("CharFilter.FilterGetAllKeyWords Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
        #region 分页查询关键词14404
        /// <summary>
        /// 分页查询关键词14404
        /// </summary>
        /// <param name="keywordsID">关键词标识ID</param>
        /// <param name="keyType">分类</param>
        /// <param name="keywords">关键词内容</param>
        /// <param name="filterType">过虑方式</param>
        /// <param name="FIdx">起始序号</param>
        /// <param name="EIdx">结束序号</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="isCount">是否返回总记录数</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        public static DataSet FilterGetAllKeyWordsPage(out int count, params object[] para)
        {
            int keywordsID = (int)para[0];
            int keyType = (int)para[1];
            string keywords = (string)para[2];
            int filterType = (int)para[3];
            int FIdx = (int)para[4];
            int EIdx = (int)para[5];
            DateTime beginTime = (DateTime)para[6];
            DateTime endTime = (DateTime)para[7];
            int isCount = (int)para[8];
            DataSet _DS = null;
            count = 0;
            try
            {
                IDALCharFilter _DAL = new DALCharFilter();
                _DS = _DAL.GetAllKeyWordsPage(keywordsID, keyType, keywords, filterType, FIdx, EIdx, beginTime, endTime, isCount, out  count);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("CharFilter.FilterGetAllKeyWordsPage Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
        #region 添加关键词被拦截的日志14405
        /// <summary>
        /// 添加关键词被拦截的日志14405
        /// </summary>
        /// <param name="keywordsID">关键词标识ID</param>
        /// <param name="keywords">被拦截的词</param>
        /// <param name="orgContent">原提交内容</param>
        /// <returns></returns>
        public static int FilteraddFilterLog(params object[] para)
        {
            int keywordsID = (int)para[0];
            string keywords = (string)para[1];
            string orgContent = (string)para[2];
            int _Result = 0;
            if (keywordsID > 0 && keywords != "")
            {
                try
                {
                    IDALCharFilter _DAL = new DALCharFilter();
                    _Result = _DAL.addFilterLog(keywordsID, keywords, orgContent);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("CharFilter.FilteraddFilterLog Exception:" + ex.Message);
                }
            }
            return _Result;
        }
        #endregion
        #region 根据ID修改关键词14406
        /// <summary>
        /// 根据ID修改关键词14406
        /// </summary>
        /// <param name="keywordsID">关键词标识ID</param>
        /// <param name="keyType">分类:1.广告骚扰 2.欺诈骗钱 3.诅咒谩骂 4.淫秽色情 5.政治 6.其它</param>
        /// <param name="keywords">关键词内容</param>
        /// <param name="filterType">过虑方式，1.普通关键词过虑，2.正则表达式匹配</param>
        /// <param name="keywordsDesc">描述</param>
        /// <param name="keywordsAlt">提示</param>
        /// <returns></returns>
        public static int FilterEditKeywords(params object[] para)
        {
            int keywordsID = (int)para[0];
            int keyType = (int)para[1];
            string keywords = (string)para[2];
            int filterType = (int)para[3];
            string keywordsDesc = (string)para[4];
            string keywordsAlt = (string)para[5];
            int _Result = 0;
            if (keywordsID > 0 && filterType > 0 && keywords != "")
            {
                try
                {
                    IDALCharFilter _DAL = new DALCharFilter();
                    _Result = _DAL.EditKeywords(keywordsID, keyType, keywords, filterType, keywordsDesc, keywordsAlt);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("CharFilter.FilterEditKeywords Exception:" + ex.Message);
                }
            }
            return _Result;
        }
        #endregion
        #region 查询所有的关键词14407
        /// <summary>
        /// 查询所有的关键词14407
        /// </summary>
        /// <returns></returns>
        public static DataSet FilterGetKeyWordsModTime()
        {
            DataSet _DS = null;
            try
            {
                IDALCharFilter _DAL = new DALCharFilter();
                _DS = _DAL.GetKeyWordsModTime();
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("CharFilter.FilterGetKeyWordsModTime Exception:" + ex.Message);
            }
            return _DS;
        }
        #endregion
    }
}
