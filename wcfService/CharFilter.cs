using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
    {

        /// <summary>
        /// 添加关键词
        /// </summary>
        /// <param name="keyType">分类:1.广告骚扰 2.欺诈骗钱 3.诅咒谩骂 4.淫秽色情 5.政治 6.其它</param>
        /// <param name="keywords">关键词内容</param>
        /// <param name="filterType">过虑方式，1.普通关键词过虑，2.正则表达式匹配</param>
        /// <param name="keywordsDesc">描述</param>
        /// <param name="keywordsAlt">提示</param>
        /// <returns></returns>
        public int FilterInsertKeywords(int keyType, string keywords, int filterType, string keywordsDesc, string keywordsAlt)
        {
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

        /// <summary>
        /// 根据ID修改关键词
        /// </summary>
        /// <param name="keywordsID">关键词标识ID</param>
        /// <param name="keyType">分类:1.广告骚扰 2.欺诈骗钱 3.诅咒谩骂 4.淫秽色情 5.政治 6.其它</param>
        /// <param name="keywords">关键词内容</param>
        /// <param name="filterType">过虑方式，1.普通关键词过虑，2.正则表达式匹配</param>
        /// <param name="keywordsDesc">描述</param>
        /// <param name="keywordsAlt">提示</param>
        /// <returns></returns>
        public int FilterEditKeywords(int keywordsID, int keyType, string keywords, int filterType, string keywordsDesc, string keywordsAlt)
        {
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

        /// <summary>
        /// 删除关键词
        /// </summary>
        /// <param name="keywordsID">关键词标识ID</param>
        /// <returns></returns>
        public bool FilterDeleteKeywords(int keywordsID)
        {
            bool _IsSuccess = false;
            if (keywordsID > 0)
            {
                try
                {
                    IDALCharFilter _DAL = new DALCharFilter();
                    _IsSuccess = _DAL.DeleteKeywords(keywordsID);
                    _DAL = null;
                }
                catch (Exception ex)
                {
                    UtilityFile.AddLogErrMsg("CharFilter.FilterDeleteKeywords Exception:" + ex.Message);
                }
            }
            return _IsSuccess;
        }

        /// <summary>
        /// 根据分类ID查询分类下所有关键词
        /// </summary>
        /// <param name="categoryID">分类ID</param>
        /// <returns></returns>
        public DataSet FilterGetKeyWordsByCateID(int categoryID)
        {
            DataSet _DS = null;
            try
            {
                int _TotalCount=0;
                IDALCharFilter _DAL = new DALCharFilter();
                _DS = _DAL.GetAllKeyWordsPage(0, categoryID, "", -1, 1, int.MaxValue, DateTime.MinValue, DateTime.Now, 0, out _TotalCount);
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("CharFilter.FilterGetKeyWordsByCateID Exception:" + ex.Message);
            }
            return _DS;
        }
        /// <summary>
        /// 查询所有的关键词
        /// </summary>
        /// <returns></returns>
        public DataSet FilterGetAllKeyWords()
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
        /// <summary>
        /// 查询所有的关键词
        /// </summary>
        /// <returns></returns>
        public DataSet FilterGetAllCategory()
        {
            DataSet _DS = null;
            try
            {
                IDALCharFilter _DAL = new DALCharFilter();
                _DS = _DAL.GetAllCategory();
                _DAL = null;
            }
            catch (Exception ex)
            {
                UtilityFile.AddLogErrMsg("CharFilter.FilterGetAllCategory Exception:" + ex.Message);
            }
            return _DS;
        }
        /// <summary>
        /// 分页查询关键词
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
        public DataSet FilterGetAllKeyWordsPage(int keywordsID, int keyType, string keywords, int filterType, int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int isCount, out int count)
        {
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

        /// <summary>
        /// 添加关键词被拦截的日志
        /// </summary>
        /// <param name="keywordsID">关键词标识ID</param>
        /// <param name="keywords">被拦截的词</param>
        /// <param name="orgContent">原提交内容</param>
        /// <returns></returns>
        public int FilteraddFilterLog(int keywordsID, string keywords, string orgContent)
        {
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

        /// <summary>
        /// 查询所有的关键词
        /// </summary>
        /// <returns></returns>
        public DataSet FilterGetKeyWordsModTime()
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

    }
}
