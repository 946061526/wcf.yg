using System;
using System.Data;

namespace wcfNSYGShop
{
    public interface IDALBrand
    {
        #region 获取某分类下的品牌列表
        /// <summary>
        /// 获取某分类下的品牌列表
        /// </summary>
        /// <param name="sortID"></param>
        /// <returns></returns>
        DataSet GetBrandBySortID( int sortID );
        #endregion
    }
}
