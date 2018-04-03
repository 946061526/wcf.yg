using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALCharFilter : DALBase, IDALCharFilter
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
        public int InsertKeywords(int keyType, string keywords, int filterType, string keywordsDesc, string keywordsAlt)
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter("retVal", 1);
            Para.AddOrcNewModuleParameter("14401");
            Para.AddOrcNewInParameter("i_KeyType", keyType);
            Para.AddOrcNewInParameter("i_keyWords", keywords);
            Para.AddOrcNewInParameter("i_FilterType", filterType);
            Para.AddOrcNewInParameter("i_KeyWordsDesc", keywordsDesc);
            Para.AddOrcNewInParameter("i_KeyWordsCue", keywordsAlt);
            Dal.ExecuteNonQuery("yun_KeyWord.f_addKeyWords");
            int _RetVal = ToInt32(Para.GetOrcParameter("retVal"));
            if (_RetVal < 1)
            {
                AddFailLog(_RetVal);
            }
            return _RetVal;
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
        public int EditKeywords(int keywordsID, int keyType, string keywords, int filterType, string keywordsDesc, string keywordsAlt)
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter("retVal", 1);
            Para.AddOrcNewModuleParameter("14406");
            Para.AddOrcNewInParameter("i_keyWordsID", keywordsID);
            Para.AddOrcNewInParameter("i_KeyType", keyType);
            Para.AddOrcNewInParameter("i_keyWords", keywords);
            Para.AddOrcNewInParameter("i_FilterType", filterType);
            Para.AddOrcNewInParameter("i_KeyWordsDesc", keywordsDesc);
            Para.AddOrcNewInParameter("i_KeyWordsCue", keywordsAlt);
            Dal.ExecuteNonQuery("yun_KeyWord.f_modKeyWordsByID");
            int _RetVal = ToInt32(Para.GetOrcParameter("retVal"));
            if (_RetVal < 1)
            {
                AddFailLog(_RetVal);
            }
            return _RetVal;
        }

        /// <summary>
        /// 删除关键词
        /// </summary>
        /// <param name="keywordsID">关键词标识ID</param>
        /// <returns></returns>
        public bool DeleteKeywords(int keywordsID)
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter("retVal", 1);
            Para.AddOrcNewModuleParameter("14402");
            Para.AddOrcNewInParameter("i_keyWordsID", keywordsID);
            Dal.ExecuteNonQuery("yun_KeyWord.f_delKeyWordsByWordsID");
            int _RetVal = ToInt32(Para.GetOrcParameter("retVal"));
            if (_RetVal < 1)
            {
                AddFailLog(_RetVal);
            }
            return _RetVal > 0;
        }

        /// <summary>
        /// 查询所有的关键词
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllKeyWords()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter("14403");
            Para.AddOrcNewCursorParameter("o_result");
            return Dal.ExecuteFillDataSet("yun_KeyWord.sp_getAllKeyWords");
        }
        /// <summary>
        /// 查询所有的关键词分类
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllCategory()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter("14409");
            Para.AddOrcNewCursorParameter("o_result");
            return Dal.ExecuteFillDataSet("yun_KeyWord.sp_getAllKeyWordsType");
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
        public DataSet GetAllKeyWordsPage(int keywordsID, int keyType, string keywords, int filterType, int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int isCount, out int count)
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter("14404");
            Para.AddOrcNewInParameter("i_keyWordsID", keywordsID);
            Para.AddOrcNewInParameter("i_KeyType", keyType);
            Para.AddOrcNewInParameter("i_keyWords", keywords);
            Para.AddOrcNewInParameter("i_FilterType", filterType);
            Para.AddOrcNewInParameter("i_beginTime", beginTime);
            Para.AddOrcNewInParameter("i_endTime", endTime);
            Para.AddOrcNewInParameter("i_FIdx", FIdx);
            Para.AddOrcNewInParameter("i_EIdx", EIdx);
            Para.AddOrcNewInParameter("i_IsCount", isCount);
            Para.AddOrcNewCursorParameter("o_result");
            DataSet _DS = Dal.ExecuteFillDataSet("yun_KeyWord.sp_getKeyWordsPage");
            count = GetOrcTotalCount(isCount, _DS);
            return _DS;
        }

        /// <summary>
        /// 添加关键词被拦截的日志
        /// </summary>
        /// <param name="keywordsID">关键词标识ID</param>
        /// <param name="keywords">被拦截的词</param>
        /// <param name="orgContent">原提交内容</param>
        /// <returns></returns>
        public int addFilterLog(int keywordsID, string keywords, string orgContent)
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter("retVal", 1);
            Para.AddOrcNewModuleParameter("14405");
            Para.AddOrcNewInParameter("i_wordsContent", orgContent);
            Para.AddOrcNewInParameter("i_keyWords", keywords);
            Para.AddOrcNewInParameter("i_logKeyWordsID", keywordsID);
            Dal.ExecuteNonQuery("yun_KeyWord.f_addKeyWordsLog");
            int _RetVal = ToInt32(Para.GetOrcParameter("retVal"));
            if (_RetVal < 1)
            {
                AddFailLog(_RetVal);
            }
            return _RetVal;
        }

        /// <summary>
        /// 获取时间标识，看看词库是否有更新
        /// </summary>
        /// <returns></returns>
        public DataSet GetKeyWordsModTime()
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter("14407");
            Para.AddOrcNewCursorParameter("o_result");
            return Dal.ExecuteFillDataSet("yun_KeyWord.sp_getKeyWordsModTime");
        }
    }
}
