using System;
using System.Data;

namespace wcfNSYGShop
{
    public partial class WCFServiceFun
    {
        #region 获取某会员收货地址列表信息
        /// <summary>
        /// 获取某会员收货地址列表信息
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public DataSet GetUserContactListByID( int userID )
        {
            DataSet _DS = null;
            if ( userID > 0 )
            {
                try
                {
                    IDALUserContact _DAL = new DALUserContact();
                    _DS = _DAL.GetUserContactListByID( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserContact.GetUserContactListByID抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 添加收货地址信息
        /// <summary>
        /// 添加收货地址信息
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <param name="userName">收货人姓名</param>
        /// <param name="areaID">所在区ID</param>
        /// <param name="streetID">所在街道ID</param>
        /// <param name="address">收货地址</param>
        /// <param name="zip">邮编</param>
        /// <param name="mobile">手机号</param>
        /// <param name="tel">联系电话</param>
        /// <param name="isDefault">是否默认地址</param>
        /// <returns></returns>
        public int AddNewUserContact( int userID, string userName, int areaID, int streetID, string address, string zip, string mobile, string tel, bool isDefault )
        {
            int _ID = 0;
            if ( userID > 0 && userName != "" && areaID > 0 && address != "" && ( mobile != "" || tel != "" ) )
            {
                try
                {
                    IDALUserContact _DAL = new DALUserContact();
                    _ID = _DAL.AddNewUserContact( userID, userName, areaID, streetID, address, zip, mobile, tel, isDefault );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserContact.AddNewUserContact抛出异常：" + ex.Message );
                }
            }
            return _ID;
        }
        #endregion

        #region 修改收货地址信息
        /// <summary>
        /// 修改收货地址信息
        /// </summary>
        /// <param name="contactID">ID</param>
        /// <param name="userID">会员ID</param>
        /// <param name="userName">收货人姓名</param>
        /// <param name="areaID">所在区ID</param>
        /// <param name="streetID">所在街道ID</param>
        /// <param name="address">收货地址</param>
        /// <param name="zip">邮编</param>
        /// <param name="mobile">手机号</param>
        /// <param name="tel">联系电话</param>
        /// <param name="isDefault">是否默认地址</param>
        /// <returns></returns>
        public bool UpdateUserContact( int contactID, int userID, string userName, int areaID, int streetID, string address, string zip, string mobile, string tel, bool isDefault )
        {
            bool _Result = false;
            if ( contactID > 0 && userID > 0 && userName != "" && areaID > 0 && address != "" && ( mobile != "" || tel != "" ) )
            {
                try
                {
                    IDALUserContact _DAL = new DALUserContact();
                    _Result = _DAL.UpdateUserContact( contactID, userID, userName, areaID, streetID, address, zip, mobile, tel, isDefault ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserContact.AddNewUserContact抛出异常：" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 获取收货地址信息
        /// <summary>
        /// 获取收货地址信息
        /// </summary>
        /// <param name="contactID">地址ID</param>
        /// <returns></returns>
        public DataSet GetUserContactInfoByID( int contactID )
        {
            DataSet _DS = null;
            if ( contactID > 0 )
            {
                try
                {
                    IDALUserContact _DAL = new DALUserContact();
                    _DS = _DAL.GetUserContactInfoByID( contactID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserContact.GetUserContactInfoByID抛出异常：" + ex.Message );
                }
            }
            return _DS;
        }
        #endregion

        #region 删除收货地址信息，默认地址不可删除
        /// <summary>
        /// 删除收货地址信息，默认地址不可删除
        /// </summary>
        /// <param name="contactID">地址ID号</param>
        /// <param name="userID">会员ID号</param>
        /// <returns></returns>
        public bool DeleteUserContact( int contactID, int userID )
        {
            bool _Result = false;
            if ( contactID > 0 && userID > 0 )
            {
                try
                {
                    IDALUserContact _DAL = new DALUserContact();
                    _Result = _DAL.DeleteUserContact( contactID, userID ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserContact.DeleteUserContact Exception:" + ex.Message );
                }
            }
            return _Result;
        }
        #endregion

        #region 获取某会员的收货地址数量
        /// <summary>
        /// 获取某会员的收货地址数量
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public int GetUserContactCount( int userID )
        {
            int _Count = 0;
            if ( userID > 0 )
            {
                try
                {
                    IDALUserContact _DAL = new DALUserContact();
                    _Count = _DAL.GetUserContactCount( userID );
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserContact.GetUserContactCount Exception:" + ex.Message );
                }
            }
            return _Count;
        }
        #endregion

        #region 修改收货地址是否为默认地址
        /// <summary>
        /// 修改收货地址是否为默认地址
        /// </summary>
        /// <param name="contactID">地址ID号</param>
        /// <param name="userID">会员ID号</param>
        /// <returns></returns>
        public bool UpdateUserContactDefault( int contactID, int userID )
        {
            bool _Flag = false;
            if ( contactID > 0 && userID > 0 )
            {
                try
                {
                    IDALUserContact _DAL = new DALUserContact();
                    _Flag = _DAL.UpdateUserContactDefault( contactID, userID ) > 0;
                    _DAL = null;
                }
                catch ( Exception ex )
                {
                    UtilityFile.AddLogErrMsg( "UserContact.UpdateUserContactDefault Exception:" + ex.Message );
                }
            }
            return _Flag;
        }
        #endregion
    }
}
