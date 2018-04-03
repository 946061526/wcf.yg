using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALCharFilter
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
        int InsertKeywords( int keyType, string keywords, int filterType, string keywordsDesc, string keywordsAlt );

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
        int EditKeywords( int keywordsID, int keyType, string keywords, int filterType, string keywordsDesc, string keywordsAlt );

        /// <summary>
        /// 删除关键词
        /// </summary>
        /// <param name="keywordsID">关键词标识ID</param>
        /// <returns></returns>
        bool DeleteKeywords( int keywordsID );
        /// <summary>
        /// 查询所有的关键词
        /// </summary>
        /// <returns></returns>
        DataSet GetAllKeyWords();
        /// <summary>
        /// 查询所有的关键词分类
        /// </summary>
        /// <returns></returns>
        DataSet GetAllCategory();
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
        DataSet GetAllKeyWordsPage( int keywordsID, int keyType, string keywords, int filterType, int FIdx, int EIdx, DateTime beginTime, DateTime endTime, int isCount, out int count );

        /// <summary>
        /// 添加关键词被拦截的日志
        /// </summary>
        /// <param name="keywordsID">关键词标识ID</param>
        /// <param name="keywords">被拦截的词</param>
        /// <param name="orgContent">原提交内容</param>
        /// <returns></returns>
        int addFilterLog( int keywordsID, string keywords, string orgContent );

        /// <summary>
        /// 获取时间标识，看看词库是否有更新
        /// </summary>
        /// <returns></returns>
        DataSet GetKeyWordsModTime();

    }
}
