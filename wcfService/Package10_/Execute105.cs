using System;
using System.Data;

namespace wcfNSYGShop
{

    public partial class ExecuteFun
    {
        #region 获取某区域ID下的子区域列表10507
        /// <summary>
        /// 获取某区域ID下的子区域列表10507
        /// </summary>
        /// <param name="sortID">区域ID</param>
        /// <returns></returns>
        public static DataSet GetChildAreaByID(params object[] para)
        {
            DataSet _DS = null;
            int _AreaID = (int)para[0];
            if (_AreaID > 0)
            {
                IDALBaseArea _DAL = new DALBaseArea();
                _DS = _DAL.GetChildAreaByID(_AreaID);
                _DAL = null;
            }
            return _DS;
        }
        #endregion
    }
}
