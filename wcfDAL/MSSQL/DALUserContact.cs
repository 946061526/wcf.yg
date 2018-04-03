using System;
using System.Data;

namespace wcfNSYGShop
{
    public class DALUserContact : DALBase, IDALUserContact
    {

        #region 获取某会员收货地址列表信息
        /// <summary>
        /// 获取某会员收货地址列表信息
        /// </summary>
        /// <param name="userID">会员ID</param>
        /// <returns></returns>
        public DataSet GetUserContactListByID( int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12921" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_UserBehaver.sp_getAddressInfoByUserID" );//pro_UserContactGetListByID
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
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12922" );
            Para.AddOrcNewInParameter( "i_contactUserID", userID );
            Para.AddOrcNewInParameter( "i_contactName", userName );
            Para.AddOrcNewInParameter( "i_contactAreaID", areaID );
            Para.AddOrcNewInParameter( "i_contactStreetID", streetID );
            Para.AddOrcNewInParameter( "i_contactAddress", address );
            Para.AddOrcNewInParameter( "i_contactZip", zip );
            Para.AddOrcNewInParameter( "i_contactMobile", mobile );
            Para.AddOrcNewInParameter( "i_contactTel", tel );
            Para.AddOrcNewInParameter( "i_contactDefault", isDefault ? 1 : 0 );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_addUserAddress" );//pro_UserContactInsert
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
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
        public int UpdateUserContact( int contactID, int userID, string userName, int areaID, int streetID, string address, string zip, string mobile, string tel, bool isDefault )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12923" );
            Para.AddOrcNewInParameter( "i_contactID", contactID );
            Para.AddOrcNewInParameter( "i_contactUserID", userID );
            Para.AddOrcNewInParameter( "i_contactName", userName );
            Para.AddOrcNewInParameter( "i_contactAreaID", areaID );
            Para.AddOrcNewInParameter( "i_contactStreetID", streetID );
            Para.AddOrcNewInParameter( "i_contactAddress", address );
            Para.AddOrcNewInParameter( "i_contactZip", zip );
            Para.AddOrcNewInParameter( "i_contactMobile", mobile );
            Para.AddOrcNewInParameter( "i_contactTel", tel );
            Para.AddOrcNewInParameter( "i_contactDefault", isDefault ? 1 : 0 );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_modAddressByTackID" );//pro_UserContactUpdate
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12920" );
            Para.AddOrcNewInParameter( "i_contactID", contactID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return Dal.ExecuteFillDataSet( "yun_UserBehaver.sp_getAddressInfoByTactID" );//pro_UserContactGetInfoByID
        }
        #endregion

        #region 删除收货地址信息，默认地址不可删除
        /// <summary>
        /// 删除收货地址信息，默认地址不可删除
        /// </summary>
        /// <param name="contactID">地址ID号</param>
        /// <param name="userID">会员ID号</param>
        /// <returns></returns>
        public int DeleteUserContact( int contactID, int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12918" );
            Para.AddOrcNewInParameter( "i_contactID", contactID );
            Para.AddOrcNewInParameter( "i_contactUserID", userID );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_delUserAddressByTactID" );//pro_UserContactDelete
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;//>0 影响行数
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
            Para.ClearOrcParameter();
            Para.AddOrcNewModuleParameter( "12919" );
            Para.AddOrcNewInParameter( "i_UserID", userID );
            Para.AddOrcNewCursorParameter( "o_result" );
            return ToInt32( Dal.ExecuteString( "yun_UserBehaver.sp_getTotalAddressByUserID" ) );//pro_UserContactGetCount
        }
        #endregion

        #region 修改收货地址是否为默认地址
        /// <summary>
        /// 修改收货地址是否为默认地址
        /// </summary>
        /// <param name="contactID">地址ID号</param>
        /// <param name="userID">会员ID号</param>
        /// <returns></returns>
        public int UpdateUserContactDefault( int contactID, int userID )
        {
            Para.ClearOrcParameter();
            Para.AddOrcNewReturnParameter( "retVal", 1 );
            Para.AddOrcNewModuleParameter( "12924" );
            Para.AddOrcNewInParameter( "i_contactID", contactID );
            Para.AddOrcNewInParameter( "i_contactUserID", userID );
            Dal.ExecuteNonQuery( "yun_UserBehaver.f_modDefaultAddressByTackID" );//pro_UserContactUpdateDefault
            int _RetVal = ToInt32( Para.GetOrcParameter( "retVal" ) );
            if ( _RetVal < 1 )
            {
                AddFailLog( _RetVal );
            }
            return _RetVal;
        }
        #endregion
    }
}
