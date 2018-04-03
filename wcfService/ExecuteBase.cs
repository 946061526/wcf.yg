using System;
using System.Data;
using System.ServiceModel;
namespace wcfNSYGShop
{
    /// <summary>
    /// 对外公开方法实现
    /// </summary>
    [ServiceBehavior( ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall )]
    public partial class WCFServiceFun : IWCFContract
    {
        #region 空方法，供客户端检测状态使用
        /// <summary>
        /// 空方法，供客户端检测状态使用
        /// </summary>
        public int CheckConnState()
        {
            int _RetVal = 1;
            try
            {
                _RetVal = UtilityFile.ReadSystemSwitchFile();
            }
            catch
            {
            }
            return _RetVal;
        }
        #endregion

        #region ExecuteForDataSet( out DataSet result, int module, params object[] para )
        /// <summary>
        /// 执行查询过程输出数据集
        /// </summary>
        /// <param name="result">返回数据集</param>
        /// <param name="module">数据库过程编号</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        public int ExecuteForDataSet( out DataSet result, int module, params object[] para )
        {
            int _RetVal = -203;
            result = null;
            try
            {
                switch ( module )
                {
                    #region 模块102
                    case 10204:
                        result = ExecuteFun.GetADListForPage( para );
                        break;
                    #endregion
                    #region 模块103
                    case 1030201:
                        result = ExecuteFun.GetGoodsPeriodList( para );
                        break;
                    case 10304:
                        result = ExecuteFun.mGetBarcodeLotteryInfo( para );
                        break;
                    case 10305:
                        result = ExecuteFun.appGetHomePage();
                        break;
                    case 10306:
                        result = ExecuteFun.appGetNewGoodsRecommand( para );
                        break;
                    case 10307:
                        result = ExecuteFun.appGetUserLikeGoods( para );
                        break;
                    case 10308:
                        result = ExecuteFun.appGetNewLottery( para );
                        break;
                    case 10309:
                        result = ExecuteFun.appGetPopGoodsRec( para );
                        break;
                    case 10311:
                        result = ExecuteFun.getBuyNumByUidCid( para );
                        break;
                    case 10318:
                        result = ExecuteFun.GetUserFirstTime( para );
                        break;
                    case 10319:
                        result = ExecuteFun.GetUserBuyMonthByUserID( para );
                        break;
                    #endregion
                    #region 模块104
                    case 10402:
                        result = ExecuteFun.GetBarcodeInfoByID( para );
                        break;
                    case 10403:
                        result = ExecuteFun.GetWaitLotteryList( para );
                        break;
                    case 10404:
                        result = ExecuteFun.GetBarcodeRNOInfo( para );
                        break;
                    case 10410:
                        result = ExecuteFun.GetRNOLastGoodsList( para );
                        break;
                    #endregion
                    #region 模块105
                    case 10507:
                        result = ExecuteFun.GetChildAreaByID( para );
                        break;
                    #endregion
                    #region 模块107
                    case 10703:
                        result = ExecuteFun.GetCartInfo( para );
                        break;
                    case 10704:
                        result = ExecuteFun.GetCartListByUserID( para );
                        break;
                    case 10709:
                        result = ExecuteFun.GetUserCartGoodsList( para );
                        break;
                    case 10711:
                        result = ExecuteFun.GetUnuseGoodsNextPeriod( para );
                        break;
                    #endregion
                    #region 模块108
                    case 10802:
                        result = ExecuteFun.GetRaffleDataByTime( para );
                        break;
                    case 10803:
                        result = ExecuteFun.GetUserBuyRecentlyList( para );
                        break;
                    case 10804:
                        result = ExecuteFun.GetUserBuyRecordsEndView( para );
                        break;
                    #endregion
                    #region 模块113
                    case 11301:
                        result = ExecuteFun.GetGoodsBarcodeInfo( para );
                        break;
                    case 11303:
                        result = ExecuteFun.GetGoodsInfoByID( para );
                        break;
                    case 11318:
                        result = ExecuteFun.GetGoodsForHomeRecommend( para );
                        break;
                    case 11321:
                        result = ExecuteFun.GetSalingBarcodeInfoByGoodsID( para );
                        break;
                    case 11325:
                        result = ExecuteFun.GetActSpecByLabel( para );
                        break;
                    #endregion
                    #region 模块114
                    case 11402:
                        result = ExecuteFun.GetGroupLastMsgNewest( para );
                        break;
                    case 11403:
                        result = ExecuteFun.GetGroupsLastMsg( para );
                        break;
                    case 11409:
                        result = ExecuteFun.GetGroupInfo( para );
                        break;
                    case 11410:
                        result = ExecuteFun.GetGroupsListByUser( para );
                        break;
                    case 11412:
                        result = ExecuteFun.GetGroupsPageForAdminUserInfo( para );
                        break;
                    case 11413:
                        result = ExecuteFun.GetGroupsPageForTopic( para );
                        break;
                    case 11414:
                        result = ExecuteFun.GetGroupsPageForHotUser( para );
                        break;
                    case 11415:
                        result = ExecuteFun.GetGroupsPageForLastJoinUser( para );
                        break;
                    case 11416:
                        result = ExecuteFun.GetGroupsPageForUserTotalInfo( para );
                        break;
                    case 11419:
                        result = ExecuteFun.GetGroupTopicGlobalList( para );
                        break;
                    case 11421:
                        result = ExecuteFun.GetGroupTopicInfo( para );
                        break;
                    case 11422:
                        result = ExecuteFun.GetGroupTopicNoticeList();
                        break;
                    case 11434:
                        result = ExecuteFun.GetGroupsListByGroupType( para );
                        break;
                    case 11435:
                        result = ExecuteFun.GetGroupsTopicForHome();
                        break;
                    #endregion
                    #region 模块116
                    case 11603:
                        result = ExecuteFun.GetLinksInfoByType( para );
                        break;
                    #endregion
                    #region 模块117
                    case 11701:
                        result = ExecuteFun.GetMemberCenterHome( para );
                        break;
                    case 11705:
                        result = ExecuteFun.GetUserMsgCount( para );
                        break;
                    case 11706:
                        result = ExecuteFun.GetInterestedPeople( para );
                        break;
                    case 11709:
                        result = ExecuteFun.GetMemberCenterForSearchFriendsDefault( para );
                        break;
                    case 11716:
                        result = ExecuteFun.GetMemberCenterUserBuyDetail( para );
                        break;
                    case 11719:
                        result = ExecuteFun.GetMemberCenterUserBuyRno( para );
                        break;
                    case 11720:
                        result = ExecuteFun.GetMemberCenterUserBuyStateTotal( para );
                        break;
                    case 11722:
                        result = ExecuteFun.GetMemberCenterUserConsumptionDetail( para );
                        break;
                    case 11725:
                        result = ExecuteFun.GetMemberCenterForUserFriendMsg( para );
                        break;
                    case 11727:
                        result = ExecuteFun.GetMemberCenterUserInfo( para );
                        break;
                    case 11728:
                        result = ExecuteFun.GetUserInfoByID( para );
                        break;
                    case 11735:
                        result = ExecuteFun.GetMemberCenterUserPostSingleDetail( para );
                        break;
                    case 11744:
                        result = ExecuteFun.GetUserMoneyByUserID( para );
                        break;
                    case 11759:
                        result = ExecuteFun.GetChangeOrderListByUserID( para );
                        break;
                    case 11761:
                        result = ExecuteFun.GetOrderInfoByOrderNO( para );
                        break;
                    case 11767:
                        result = ExecuteFun.GetUserIDByShortUrl( para );
                        break;
                    case 11768:
                        result = ExecuteFun.GetShortUrlByUserID( para );
                        break;
                    case 11771:
                        result = ExecuteFun.GetExChangeInfoByExID( para );
                        break;
                    case 11772:
                        result = ExecuteFun.GetExChangeOneByExID( para );
                        break;
                    case 11775:
                        result = ExecuteFun.GetWasteRegTimeByUserID( para );
                        break;
                    #endregion
                    #region 模块118
                    case 11801:
                        result = ExecuteFun.mGetAutoLotteryList();
                        break;
                    case 11805:
                        result = ExecuteFun.mGetHomePage();
                        break;
                    case 11809:
                        result = ExecuteFun.GetBarcodeDescByCodeID( para );
                        break;
                    case 11810:
                        result = ExecuteFun.GetHotSortGoodsIDByGID( para );
                        break;
                    case 11811:
                        result = ExecuteFun.GetPopularGoods( para );
                        break;
                    #endregion
                    #region 模块119
                    case 11904:
                        result = ExecuteFun.GetNewsInfoByID( para );
                        break;
                    #endregion
                    #region 模块120
                    case 12003:
                        result = ExecuteFun.GetOrderDeliveryListByNO( para );
                        break;
                    case 12006:
                        result = ExecuteFun.GetOrderDoStepListByNO( para );
                        break;
                    case 12010:
                        result = ExecuteFun.GetOrderInfoByNO( para );
                        break;
                    case 12020:
                        result = ExecuteFun.GetOrderDischInfoByOrderNO( para );
                        break;
                    case 12023:
                        result = ExecuteFun.GetIdentificationByOrderNO( para );
                        break;
                    case 12025:
                        result = ExecuteFun.GetAddressIdentification( para );
                        break;

                    case 12027:
                        result = ExecuteFun.GetSpecListByOrderNO( para );
                        break;
                    case 12031:
                        result = ExecuteFun.GetSkuAttrByOrderNo( para );
                        break;
                    #endregion
                    #region 模块122
                    case 12202:
                        result = ExecuteFun.GetAutoLotteryList();
                        break;
                    case 12203:
                        result = ExecuteFun.GetBrandBySortID( para );
                        break;
                    case 12206:
                        result = ExecuteFun.GetGoodsHistoryPeriod( para );
                        break;
                    case 12209:
                        result = ExecuteFun.GetPageForGoodsPostSingle( para );
                        break;
                    case 1220901:
                        result = ExecuteFun.mGetPageForGoodsPostSingle( para );
                        break;
                    case 12211:
                        result = ExecuteFun.GetGroupLastMsgForHome( para );
                        break;
                    case 12212:
                        result = ExecuteFun.GetHomePageData();
                        break;
                    case 12213:
                        result = ExecuteFun.GetHomeGoodsByLabel( para );
                        break;
                    case 12215:
                        result = ExecuteFun.GetUserBuyNewList( para );
                        break;
                    case 12217:
                        result = ExecuteFun.GetRecentlyRaffleList();
                        break;
                    case 12218:
                        result = ExecuteFun.GetStartRaffleGoodsList( para );
                        break;
                    case 12221:
                        result = ExecuteFun.GetGoodsBarcodeInfoByPeriod( para );
                        break;
                    case 12225:
                        result = ExecuteFun.GetBrandListByNvgtID( para );
                        break;
                    case 12227:
                        result = ExecuteFun.GetPreviewBrandList( para );
                        break;
                    case 12228:
                        result = ExecuteFun.GetGuessYouLikeGoods( para );
                        break;
                    case 12229:
                        result = ExecuteFun.GetNvgNameByID( para );
                        break;
                    case 12230:
                        result = ExecuteFun.GetPreNvgNameByID( para );
                        break;
                    case 12231:
                        result = ExecuteFun.GetWeChatNvgtion();
                        break;
                    #endregion
                    #region 模块123
                    case 12301:
                        result = ExecuteFun.GetPaymentRecordCheckList( para );
                        break;
                    case 12309:
                        result = ExecuteFun.GetTransferByTransID( para );
                        break;
                    case 12316:
                        result = ExecuteFun.GetCardInfoByAccount( para );
                        break;
                    case 12328:
                        result = ExecuteFun.GetBankNameByCardNO( para );
                        break;
                    #endregion
                    #region 模块124
                    case 12406:
                        result = ExecuteFun.GetPostReplyInfo( para );
                        break;
                    case 12410:
                        result = ExecuteFun.GetPostSingleDetail( para );
                        break;
                    case 12414:
                        result = ExecuteFun.GetPostSingleBaseInfo( para );
                        break;
                    case 12417:
                        result = ExecuteFun.GetListNewPostSingleTopList( para );
                        break;
                    case 12422:
                        result = ExecuteFun.GetPostSingleShow();
                        break;
                    case 12423:
                        result = ExecuteFun.GetPostReplyLastest( para );
                        break;
                    case 12424:
                        result = ExecuteFun.GetPostSingleForHomeRecommend();
                        break;
                    case 12430:
                        result = ExecuteFun.GetPostSingleByCodeID( para );
                        break;
                    #endregion
                    #region 模块125
                    case 12504:
                        result = ExecuteFun.GetQQAccountTopList();
                        break;
                    #endregion
                    #region 模块126
                    case 12603:
                        result = ExecuteFun.GetUserBuyRnoList( para );
                        break;
                    case 12604:
                        result = ExecuteFun.GetUserBuyLast();
                        break;
                    case 12605:
                        result = ExecuteFun.GetStartRaffleResultNew( para );
                        break;
                    case 12606:
                        result = ExecuteFun.GetLimitBuyNewLotteryNote( para );
                        break;
                    case 12607:
                        result = ExecuteFun.GetBarcodeLotteryList();
                        break;
                    #endregion
                    #region 模块127
                    case 12702:
                        result = ExecuteFun.GetSiteCacheByID( para );
                        break;
                    #endregion
                    #region 模块128
                    case 12802:
                        result = ExecuteFun.GetChildSort( para );
                        break;
                    case 12803:
                        result = ExecuteFun.GetSortInfoByID( para );
                        break;
                    case 12805:
                        result = ExecuteFun.GetSortLevel2NaviList();
                        break;
                    case 12809:
                        result = ExecuteFun.GetSortSupPosition( para );
                        break;
                    #endregion
                    #region 模块129
                    case 12902:
                        result = ExecuteFun.GetUserBaseInfoForUserVerify( para );
                        break;
                    case 12904:
                        result = ExecuteFun.GetUserBrokerageApplyLastest( para );
                        break;
                    case 12909:
                        result = ExecuteFun.GetUserBrokerageSummary( para );
                        break;
                    case 12910:
                        result = ExecuteFun.GetUserBuyListByCodeID( para );
                        break;
                    case 12911:
                        result = ExecuteFun.CheckLimitBuyForUser( para );
                        break;
                    case 12915:
                        result = ExecuteFun.GetUserBuyCodeByBuyid( para );
                        break;
                    case 12920:
                        result = ExecuteFun.GetUserContactInfoByID( para );
                        break;
                    case 12921:
                        result = ExecuteFun.GetUserContactListByID( para );
                        break;
                    case 1292701:
                        result = ExecuteFun.CheckAllUserFriendApply( para );
                        break;
                    case 12934:
                        result = ExecuteFun.GetUserCachedInfo( para );
                        break;
                    case 12956:
                        result = ExecuteFun.GetUserPrivSetByID( para );
                        break;
                    case 12966:
                        result = ExecuteFun.GetUserBuyForWeekRanking( para );
                        break;
                    #endregion
                    #region 模块130
                    case 13001:
                        result = ExecuteFun.GetLatestVisitors( para );
                        break;
                    case 13003:
                        result = ExecuteFun.GetUserBaseInfo( para );
                        break;
                    case 13004:
                        result = ExecuteFun.GetUserLatestMessage( para );
                        break;
                    case 13007:
                        result = ExecuteFun.GetUserWebPageForUserGroup( para );
                        break;
                    case 13010:
                        result = ExecuteFun.GetUserWebPageForUserTopic( para );
                        break;
                    case 13011:
                        result = ExecuteFun.GetUserWebPageForUserTopicReply( para );
                        break;
                    #endregion
                    #region 模块131
                    case 13104:
                        result = ExecuteFun.GetSendShipList();
                        break;
                    case 13110:
                        result = ExecuteFun.GetWxSendMsgList();
                        break;
                    case 13113:
                        result = ExecuteFun.GetNewOrderByUserID( para );
                        break;
                    case 13114:
                        result = ExecuteFun.GetBrokerInfoByApplyID( para );
                        break;
                    case 13116:
                        result = ExecuteFun.GetUserIDByWXSmallID( para );
                        break;

                    #endregion
                    #region 模块132
                    case 13207:
                        result = ExecuteFun.GetPaymentRecordList( para );
                        break;
                    #endregion
                    #region 模块134
                    case 13422:
                        result = ExecuteFun.GetHouseInfoByCodeID( para );
                        break;
                    #endregion

                    #region 模块136
                    case 13603:
                        result = ExecuteFun.GetOrdersInfoForPrint( para );
                        break;
                    case 13609:
                        result = ExecuteFun.GetActOrdersInfoByOrderNO( para );
                        break;
                    #endregion
                    #region 模块141
                    case 14101:
                        result = ExecuteFun.mapGetAreaStatByLevel( para );
                        break;
                    case 14102:
                        result = ExecuteFun.mapGetDetailPointByAreaId( para );
                        break;
                    case 14104:
                        result = ExecuteFun.mapGetAreaGoodsByGoodsID( para );
                        break;
                    case 14107:
                        result = ExecuteFun.mapGetOrdersByUserId( para );
                        break;
                    case 14112:
                        result = ExecuteFun.mapGetOrderTotal();
                        break;
                    #endregion
                    #region 模块143
                    case 14304:
                        result = ExecuteFun.GetJdTokenByUser( para );
                        break;
                    case 14314:
                        result = ExecuteFun.GetJdOrderDetailByONO( para );
                        break;
                    #endregion
                    #region 模块144
                    case 14403:
                        result = ExecuteFun.FilterGetAllKeyWords();
                        break;
                    case 14407:
                        result = ExecuteFun.FilterGetKeyWordsModTime();
                        break;
                    #endregion
                    #region 模块145
                    case 14570:
                        result = ExecuteFun.GetIMServerIPTable();
                        break;
                    #endregion
                    #region 模块162
                    case 16205:
                        result = ExecuteFun.GetFundItemRecomand( para );
                        break;
                    case 16206:
                        result = ExecuteFun.GetFundItemForWeb( para );
                        break;
                    case 16207:
                        result = ExecuteFun.GetFundItemDetailById( para );
                        break;
                    case 16208:
                        result = ExecuteFun.GetFundAdByAdType( para );
                        break;
                    #endregion
                    #region 模块1001
                    case 100101:
                        result = ExecuteFun.GetMonitorMsg();
                        break;
                    #endregion
                    #region 模块404
                    case 40405:
                        result = ExecuteFun.AddLiveVideo( para );
                        break;
                    case 40406:
                        result = ExecuteFun.GetLiveReportList();
                        break;
                    case 40407:
                        result = ExecuteFun.EndLiveVideo( para );
                        break;
                    case 40408:
                        result = ExecuteFun.GetLiveIDByUserID( para );
                        break;
                    case 40410:
                        result = ExecuteFun.GetLiveViewUserList( para );
                        break;
                    case 40411:
                        result = ExecuteFun.GetLivePersonCard( para );
                        break;
                    case 40413:
                        result = ExecuteFun.GetlivevideoByID( para );
                        break;
                    case 40415:
                        result = ExecuteFun.GetLiveWishGoodsList( para );
                        break;
                    case 40416:
                        result = ExecuteFun.GetLiveVideoList( para );
                        break;
                    case 40417:
                        result = ExecuteFun.GetLiveWishBarcodeDoing( para );
                        break;
                    case 40421:
                        result = ExecuteFun.GetLiveWishBarcodeList( para );
                        break;
                    case 40422:
                        result = ExecuteFun.GetLiveWishSupportDetail( para );
                        break;
                    case 40424:
                        result = ExecuteFun.GetLiveAnchorDetail( para );
                        break;
                    case 40425:
                        result = ExecuteFun.LiveReturnPortal();
                        break;
                    case 40426:
                        result = ExecuteFun.LiveOvertimeDeal();
                        break;
                    case 40429:
                        result = ExecuteFun.GetLiveAuthByUserID( para );
                        break;
                    case 40430:
                        result = ExecuteFun.GetLiveWishBarCodeDetail( para );
                        break;
                    #endregion
                }
                if ( result == null || result.Tables.Count == 0 || result.Tables[0].Rows.Count == 0 )
                {
                    _RetVal = -201;
                }
                else
                {
                    _RetVal = -200;
                }
            }
            catch ( Exception ex )
            {
                _RetVal = -202;
                UtilityFile.AddLogErrMsg( string.Format( "ExecuteBase.ExecuteForDataSet module:{0} Ex：{1}", module, ex.Message ) );
            }
            return _RetVal;
        }
        #endregion

        #region ExecuteForDataSet2( out DataSet result, out int count, int module, params object[] para )
        /// <summary>
        /// 执行查询过程输出数据集
        /// </summary>
        /// <param name="result">返回数据集</param>
        /// <param name="count">返回统计数</param>
        /// <param name="module">数据库过程编号</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        public int ExecuteForDataSet2( out DataSet result, out int count, int module, params object[] para )
        {
            int _RetVal = -203;
            result = null;
            count = 0;
            try
            {
                switch ( module )
                {
                    #region 模块103
                    case 10301:
                        result = ExecuteFun.appGetGoodsDetailPageData( out count, para );
                        break;
                    case 10302:
                        result = ExecuteFun.GetGoodsPeriodPageList( out count, para );
                        break;
                    case 10303:
                        result = ExecuteFun.appGetRaffleBaseInfo( out count, para );
                        break;
                    case 10310:
                        result = ExecuteFun.appGetGoodsHistoryWinner( out count, para );
                        break;
                    case 10312:
                        result = ExecuteFun.appGetLimitBuyGoods( out count, para );
                        break;
                    case 10313:
                        result = ExecuteFun.appGetGoodsHistoryWinner2( out count, para );
                        break;
                    case 10315:
                        result = ExecuteFun.appGetMemberCenterBuyList( out count, para );
                        break;
                    case 10316:
                        result = ExecuteFun.appGetMemberCenterUserRaffleList( out count, para );
                        break;
                    case 10317:
                        result = ExecuteFun.appGetMemberCenterPostListByUserID( out count, para );
                        break;
                    #endregion
                    #region 模块104
                    case 10415:
                        result = ExecuteFun.GetGoodsBarcodePageList( out count, para );
                        break;
                    #endregion
                    #region 模块108
                    case 10801:
                        result = ExecuteFun.GetUsersHistoryBuyRecords( out count, para );
                        break;
                    #endregion
                    #region 模块114
                    case 11407:
                        result = ExecuteFun.GetGroupReplyPageList( out count, para );
                        break;
                    case 11411:
                        result = ExecuteFun.GetGroupsPageList( out count, para );
                        break;
                    case 11420:
                        result = ExecuteFun.GetGroupTopicGoodPageList( out count, para );
                        break;
                    case 11423:
                        result = ExecuteFun.GetGroupTopicPageList( out count, para );
                        break;
                    #endregion
                    #region 模块117

                    case 11702:
                        result = ExecuteFun.GetMemberCenterForFriendsApplyPageList( out count, para );
                        break;
                    case 11704:
                        result = ExecuteFun.GetMemberCenterForFriendsPageList( out count, para );
                        break;
                    case 11708:
                        result = ExecuteFun.GetMemberCenterForSearchFriends( out count, para );
                        break;
                    case 11710:
                        result = ExecuteFun.GetMemberCenterForSearchFriendsHot( out count, para );
                        break;
                    case 11711:
                        result = ExecuteFun.GetMemberCenterForSearchFriendsLastRegister( out count, para );
                        break;
                    case 11712:
                        result = ExecuteFun.GetMemberCenterForSearchFriendsRaffle( out count, para );
                        break;
                    case 11714:
                        result = ExecuteFun.GetMemberCenterForTopicReplyPageList( out count, para );
                        break;
                    case 11717:
                        result = ExecuteFun.GetMemberCenterBuyList( out count, para );
                        break;
                    case 11718:
                        result = ExecuteFun.GetMemberCenterBuyRefund( out count, para );
                        break;
                    case 11721:
                        result = ExecuteFun.GetMemberCenterUserConsumptionEx( out count, para );
                        break;
                    case 11726:
                        result = ExecuteFun.GetMemberCenterForUserGroupList( out count, para );
                        break;
                    case 11730:
                        result = ExecuteFun.GetMemberCenterUserRecharge( out count, para );
                        break;
                    case 11733:
                        result = ExecuteFun.GetInvitedMemberInfoList( out count, para );
                        break;
                    case 11736:
                        result = ExecuteFun.GetUserPrivMsgDetailList( out count, para );
                        break;
                    case 11737:
                        result = ExecuteFun.GetUserPrivMsgList( out count, para );
                        break;
                    case 11738:
                        result = ExecuteFun.GetMemberCenterUserRaffleList( out count, para );
                        break;
                    case 11741:
                        result = ExecuteFun.GetMemberCenterForUserUnPostSingle( out count, para );
                        break;
                    case 11742:
                        result = ExecuteFun.GetMemberCenterUserConsumption( out count, para );
                        break;
                    case 11743:
                        result = ExecuteFun.GetActOrderByUserID( out count, para );
                        break;
                    case 11756:
                        result = ExecuteFun.GetCollectGoodsByUserID( out count, para );
                        break;
                    case 11758:
                        result = ExecuteFun.GetMemberCenterUserOrderList( out count, para );
                        break;
                    case 11760:
                        result = ExecuteFun.GetMemberCenterPostListByUserID( out count, para );
                        break;
                    case 11762:
                        result = ExecuteFun.GetMemberCenterAllBalanceRecord( out count, para );
                        break;
                    case 11763:
                        result = ExecuteFun.GetMemberCenterBrokerPageByUserID( out count, para );
                        break;
                    case 11764:
                        result = ExecuteFun.GetReplyMsgPageByUserID( out count, para );
                        break;
                    case 11770:
                        result = ExecuteFun.GetExChangeListByUserID( out count, para );
                        break;
                    #endregion
                    #region 模块118
                    case 11802:
                        result = ExecuteFun.mGetGoodsDetailPageData( out count, para );
                        break;
                    case 11803:
                        result = ExecuteFun.GetUserBuyListByBarcode( out count, para );
                        break;
                    case 11806:
                        result = ExecuteFun.mGetPostSinglePageList( out count, para );
                        break;
                    case 11807:
                        result = ExecuteFun.mGetRaffleBaseInfo( out count, para );
                        break;
                    case 11808:
                        result = ExecuteFun.mGetUserWebPagePostList( out count, para );
                        break;
                    case 11812:
                        result = ExecuteFun.mGetLimitBuyGoods( out count, para );
                        break;
                    #endregion
                    #region 模块120
                    case 12028:
                        result = ExecuteFun.GetOrderListByTime( out count, para );
                        break;
                    #endregion
                    #region 模块122
                    case 12201:
                        result = ExecuteFun.GetBarcodeRaffleList( out count, para );
                        break;
                    case 1220101:
                        result = ExecuteFun.GetBarcodeRaffleListEx( out count, para );
                        break;
                    case 12204:
                        result = ExecuteFun.GetGoodsDetailPageData( out count, para );
                        break;
                    case 12207:
                        result = ExecuteFun.GetGoodsPageList( out count, para );
                        break;
                    case 12208:
                        result = ExecuteFun.GetGoodsSearchList( out count, para );
                        break;
                    case 12219:
                        result = ExecuteFun.GetLimitBuyGoodsPage( out count, para );
                        break;
                    case 12220:
                        result = ExecuteFun.GetPcGoodsPerioPagedList( out count, para );
                        break;
                    case 12224:
                        result = ExecuteFun.GetGoodsListByNvgtID( out count, para );
                        break;
                    case 12226:
                        result = ExecuteFun.GetPreviewGoodsList( out count, para );
                        break;
                    #endregion
                    #region 模块123

                    case 12308:
                        result = ExecuteFun.GetTransferAccountList( out count, para );
                        break;
                    #endregion
                    #region 模块124
                    case 12411:
                        result = ExecuteFun.GetPostSingleOldPeriodList( out count, para );
                        break;
                    case 12419:
                        result = ExecuteFun.GetPostSinglePageList( out count, para );
                        break;
                    case 1241901:
                        result = ExecuteFun.GetPostSinglePageListEx( out count, para );
                        break;
                    #endregion
                    #region 模块125
                    case 12503:
                        result = ExecuteFun.GetQQAccountPageList( out count, para );
                        break;
                    #endregion
                    #region 模块126
                    case 12602:
                        result = ExecuteFun.GetRaffleBaseInfo( out count, para );
                        break;
                    #endregion
                    #region 模块129
                    case 12905:
                        result = ExecuteFun.GetMemberCenterMentionList( out count, para );
                        break;
                    case 12908:
                        result = ExecuteFun.GetMemberCenterCommissionList( out count, para );
                        break;
                    case 12945:
                        result = ExecuteFun.GetUserPointsLogPageList( out count, para );
                        break;
                    #endregion
                    #region 模块130
                    case 13005:
                        result = ExecuteFun.GetUserWebPageBuyList( out count, para );
                        break;
                    case 13006:
                        result = ExecuteFun.GetUserFriendsList( out count, para );
                        break;
                    case 13008:
                        result = ExecuteFun.GetUserWebPagePostList( out count, para );
                        break;
                    case 13009:
                        result = ExecuteFun.GetUserWebPageRaffleList( out count, para );
                        break;
                    case 13012:
                        result = ExecuteFun.GetUserFriends( out count, para );
                        break;
                    #endregion
                    #region 模块131
                    case 13112:
                        result = ExecuteFun.GetBarcodeRaffListByGoodsID( out count, para );
                        break;
                    #endregion
                    #region 模块133
                    case 13304:
                        result = ExecuteFun.GetUserShopInfo( out count, para );
                        break;
                    #endregion
                    #region 模块134
                    case 13410:
                        result = ExecuteFun.GetThirdGoodsList( out count, para );
                        break;
                    #endregion

                    #region 模块141
                    case 14103:
                        result = ExecuteFun.mapGetGoodsByKeyWord( out count, para );
                        break;
                    case 14105:
                        result = ExecuteFun.mapGetOrderDetailByPoint( out count, para );
                        break;
                    case 14106:
                        result = ExecuteFun.mapGetUserByKeywords( out count, para );
                        break;
                    case 14110:
                        result = ExecuteFun.mapGetGoodsInfoBySortID( out count, para );
                        break;
                    case 14111:
                        result = ExecuteFun.mapGetUserInfoByLonLat( out count, para );
                        break;
                    #endregion
                    #region 模块144
                    case 14404:
                        result = ExecuteFun.FilterGetAllKeyWordsPage( out count, para );
                        break;
                    #endregion
                    #region 模块402
                    case 40201:
                        result = ExecuteFun.GetUserBuyInfoByUserID( out count, para );
                        break;
                    #endregion
                }
                if ( result == null || result.Tables.Count == 0 || result.Tables[0].Rows.Count == 0 )
                {
                    _RetVal = -201;
                }
                else
                {
                    _RetVal = -200;
                }
            }
            catch ( Exception ex )
            {
                _RetVal = -202;
                UtilityFile.AddLogErrMsg( string.Format( "ExecuteBase.ExecuteForDataSet2 module:{0} Ex：{1}", module, ex.Message ) );
            }
            return _RetVal;
        }
        #endregion

        #region ExecuteForDataSet3( out DataSet result, out int count1, out int count2, int module, params object[] para )
        /// <summary>
        /// 执行查询过程输出数据集
        /// </summary>
        /// <param name="result">返回数据集</param>
        /// <param name="count">返回统计数1</param>
        /// <param name="count">返回统计数2</param>
        /// <param name="module">数据库过程编号</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        public int ExecuteForDataSet3( out DataSet result, out int count1, out int count2, int module, params object[] para )
        {
            int _RetVal = -203;
            result = null;
            count1 = 0;
            count2 = 0;
            try
            {
                switch ( module )
                {
                    case 1031601:
                        result = ExecuteFun.appGetMemberCenterUserRaffleListEx( out count1, out count2, para );
                        break;
                    case 11713:
                        result = ExecuteFun.GetMemberCenterForTopicPageList( out count1, out count2, para );
                        break;
                    case 11729:
                        result = ExecuteFun.GetMemberCenterForUserMessageList( out count1, out count2, para );
                        break;
                    case 11734:
                        result = ExecuteFun.GetMemberCenterForUserPostSingle( out count1, out count2, para );
                        break;
                    case 1173801:
                        result = ExecuteFun.GetMemberCenterUserRaffleListEx( out count1, out count2, para );
                        break;
                    case 12404:
                        result = ExecuteFun.GetPostReplyListByID( out count1, out count2, para );
                        break;
                    case 15004:
                        result = ExecuteFun.GetBarInfoPageList( out count1, out count2, para );
                        break;
                }
                if ( result == null || result.Tables.Count == 0 || result.Tables[0].Rows.Count == 0 )
                {
                    _RetVal = -201;
                }
                else
                {
                    _RetVal = -200;
                }
            }
            catch ( Exception ex )
            {
                _RetVal = -202;
                UtilityFile.AddLogErrMsg( string.Format( "ExecuteBase.ExecuteForDataSet3 module:{0} Ex：{1}", module, ex.Message ) );
            }
            return _RetVal;
        }
        #endregion

        #region ExecuteForInt( out int result, int module, params object[] para )
        /// <summary>
        /// 执行查询过程输出整数
        /// </summary>
        /// <param name="result">输出整数</param>
        /// <param name="module">数据库过程编号</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        public int ExecuteForInt( out int result, int module, params object[] para )
        {
            int _RetVal = -203;
            result = 0;
            try
            {
                switch ( module )
                {
                    #region 模块104
                    case 10409:
                        result = ExecuteFun.UpdateBarcodeStateForAutoRTime();
                        break;
                    case 10413:
                        result = ExecuteFun.InsertBarcodeByGoodsID( para );
                        break;
                    case 10414:
                        result = ExecuteFun.DeleteBarcodeByGoodsID( para );
                        break;
                    case 10416:
                        result = ExecuteFun.GetRemainPeriodCountByGoodsID( para );
                        break;
                    case 10417:
                        result = ExecuteFun.UpdateBarGoodsDescByCodeID( para );
                        break;
                    case 10419:
                        result = ExecuteFun.UpdateBarcodePriceByGoodsID( para );
                        break;
                    #endregion
                    #region 模块107
                    case 10701:
                        result = ExecuteFun.DeleteCartByIdStr( para );
                        break;
                    case 10702:
                        result = ExecuteFun.DeleteCartByUserID( para );
                        break;
                    case 10705:
                        result = ExecuteFun.InsertCart( para );
                        break;
                    case 1070501:
                        result = ExecuteFun.InsertCartEx( para );
                        break;
                    case 10706:
                        result = ExecuteFun.UpdataCartInfoByID( para );
                        break;
                    case 10708:
                        result = ExecuteFun.UpdateCartStateBatch( para );
                        break;
                    case 10710:
                        result = ExecuteFun.InsertToCart( para );
                        break;
                    case 10712:
                        result = ExecuteFun.DeleteCartByCodeIDStr( para );
                        break;
                    case 10713:
                        result = ExecuteFun.CheckUserPaypwdForPay( para );
                        break;
                    #endregion
                    #region 模块111
                    case 11124:
                        result = ExecuteFun.AddOrderShipLog( para );
                        break;
                    #endregion
                    #region 模块112
                    case 11284:
                        result = ExecuteFun.UpdateShipStateByShipNO( para );
                        break;
                    #endregion
                    #region 模块114
                    case 11401:
                        result = ExecuteFun.InsertGroupAdminApply( para );
                        break;
                    case 11404:
                        result = ExecuteFun.InsertGroupLastMsg( para );
                        break;
                    case 11406:
                        result = ExecuteFun.DeleteGroupReply( para );
                        break;
                    case 11408:
                        result = ExecuteFun.InsertGroupReply( para );
                        break;
                    case 11417:
                        result = ExecuteFun.UpdateGroupInfo( para );
                        break;
                    case 11418:
                        result = ExecuteFun.DeleteGroupTopic( para );
                        break;
                    case 11425:
                        result = ExecuteFun.UpdateGroupTopic( para );
                        break;
                    case 11426:
                        result = ExecuteFun.UpdateGroupTopicGood( para );
                        break;
                    case 11427:
                        result = ExecuteFun.UpdateGroupTopicLookCount( para );
                        break;
                    case 11429:
                        result = ExecuteFun.DeleteGroupUser( para );
                        break;
                    case 1142901:
                        result = ExecuteFun.DeleteUserGroup( para );
                        break;
                    case 11430:
                        result = ExecuteFun.CheckGroupUserExists( para );
                        break;
                    case 11431:
                        result = ExecuteFun.GetGroupUserPower( para );
                        break;
                    case 11432:
                        result = ExecuteFun.InsertGroupUser( para );
                        break;
                    #endregion
                    #region 模块117
                    case 11715:
                        result = ExecuteFun.UpdateMemberCenterForUserBase( para );
                        break;
                    case 11723:
                        result = ExecuteFun.GetUserConsumptionSum( para );
                        break;
                    case 11724:
                        result = ExecuteFun.UpdateMemberCenterForUserDetail( para );
                        break;
                    case 11731:
                        result = ExecuteFun.GetUserPaySum( para );
                        break;
                    case 11739:
                        result = ExecuteFun.GetMemberCenterForUserRaffleNewCount( para );
                        break;
                    case 11740:
                        result = ExecuteFun.CheckUserFriendLink( para );
                        break;
                    case 11745:
                        result = ExecuteFun.SetUserPayPwdByUserID( para );
                        break;
                    case 11746:
                        result = ExecuteFun.UpdateUserPayPwdByUserID( para );
                        break;
                    case 11747:
                        result = ExecuteFun.CloseUserPayPwdByUserID( para );
                        break;
                    case 11748:
                        result = ExecuteFun.UpdateSmallPayMoneyByUserID( para );
                        break;
                    case 11749:
                        result = ExecuteFun.CheckPayPwdByUserID( para );
                        break;
                    case 11750:
                        result = ExecuteFun.SetWxKeepLoginByUserID( para );
                        break;
                    case 11751:
                        result = ExecuteFun.SetWxMailNoticeByUserID( para );
                        break;
                    case 11752:
                        result = ExecuteFun.SetSysMsgNoticeByUserID( para );
                        break;
                    case 11753:
                        result = ExecuteFun.InsertCollectGoodsByUserID( para );
                        break;
                    case 11754:
                        result = ExecuteFun.DeleteCollectGoodsByUserID( para );
                        break;
                    case 11755:
                        result = ExecuteFun.DeleteAllFailCollectGoodsByUserID( para );
                        break;
                    case 11757:
                        result = ExecuteFun.CheckUserCollectGoods( para );
                        break;
                    case 11765:
                        result = ExecuteFun.DeleteReplyMsgByUserID( para );
                        break;
                    case 11766:
                        result = ExecuteFun.InsertUserShortUrl( para );
                        break;
                    case 11773:
                        result = ExecuteFun.UpdateMemberCenterForUserBaseByType( para );
                        break;
                    #endregion
                    #region 模块120
                    case 12011:
                        result = ExecuteFun.UpdateOrders( para );
                        break;
                    case 12012:
                        result = ExecuteFun.UpdateOrderShipInfo( para );
                        break;
                    case 12013:
                        result = ExecuteFun.UpdateOrderForEndTran( para );
                        break;
                    case 12014:
                        result = ExecuteFun.UpdateOrderShipInfoTran( para );
                        break;
                    case 120142:
                        result = ExecuteFun.UpdateOrderShipInfoTranEx( para );
                        break;
                    case 12022:
                        result = ExecuteFun.UpdateOrderIdentification( para );
                        break;
                    case 12029:
                        result = ExecuteFun.UpdateKJDSorderFinish( para );
                        break;
                    #endregion
                    #region 模块123
                    case 12305:
                        result = ExecuteFun.InsertTransferAccount( para );
                        break;
                    case 12306:
                        result = ExecuteFun.ExecuteTransferAccount( para );
                        break;
                    case 12307:
                        result = ExecuteFun.DeleteTransferAccount( para );
                        break;
                    case 12312:
                        result = ExecuteFun.UpdateCardStateByAccount( para );
                        break;
                    case 12313:
                        result = ExecuteFun.UpdateCardWasteByUserID( para );
                        break;
                    case 12321:
                        result = ExecuteFun.UpdateMinusPriceByUserID( para );
                        break;
                    case 12323:
                        result = ExecuteFun.FillUserBalance( para );
                        break;
                    case 12345:
                        result = ExecuteFun.ChkTransferTimes( para );
                        break;
                    #endregion
                    #region 模块124
                    case 12401:
                        result = ExecuteFun.InsertPostHits( para );
                        break;
                    case 12402:
                        result = ExecuteFun.GetPostReplyConfigCheck( para );
                        break;
                    case 12407:
                        result = ExecuteFun.InsertPostReply( para );
                        break;
                    case 12408:
                        result = ExecuteFun.SetPostReplyHide( para );
                        break;
                    case 12409:
                        result = ExecuteFun.CheckPostSingleByID( para );
                        break;
                    case 12416:
                        result = ExecuteFun.InsertPostSingle( para );
                        break;
                    case 12420:
                        result = ExecuteFun.UpdatePostSingle( para );
                        break;
                    case 12425:
                        result = ExecuteFun.InsertPostsingleReadCount( para );
                        break;
                    #endregion
                    #region 模块125
                    case 12507:
                        result = ExecuteFun.GetUserIDFromQQAuth( para );
                        break;
                    case 12508:
                        result = ExecuteFun.InsertQQAuth( para );
                        break;
                    case 12509:
                        result = ExecuteFun.SkipQQAuthRegister( para );
                        break;
                    #endregion
                    #region 模块129
                    case 12901:
                        result = ExecuteFun.InsertSuggestMessage( para );
                        break;
                    case 12906:
                        result = ExecuteFun.ApplyUserBrokerageToAccount( para );
                        break;
                    case 12907:
                        result = ExecuteFun.ApplyUserBrokerageToBank( para );
                        break;
                    case 12913:
                        result = ExecuteFun.RefundUserBuyAfter90( para );
                        break;
                    case 12914:
                        result = ExecuteFun.GetNearestRno( para );
                        break;
                    case 12916:
                        result = ExecuteFun.InsertUserCartPaymentRecord( para );
                        break;
                    case 12918:
                        result = ExecuteFun.DeleteUserContact( para );
                        break;
                    case 12919:
                        result = ExecuteFun.GetUserContactCount( para );
                        break;
                    case 12922:
                        result = ExecuteFun.AddNewUserContact( para );
                        break;
                    case 12923:
                        result = ExecuteFun.UpdateUserContact( para );
                        break;
                    case 12924:
                        result = ExecuteFun.UpdateUserContactDefault( para );
                        break;
                    case 12925:
                        result = ExecuteFun.DeleteUserFriendApply( para );
                        break;
                    case 12926:
                        result = ExecuteFun.GetUserFriendApplyTotalByUser( para );
                        break;
                    case 12927:
                        result = ExecuteFun.CheckUserFriendApply( para );
                        break;
                    case 12928:
                        result = ExecuteFun.DeleteUserFriendLink( para );
                        break;
                    case 12930:
                        result = ExecuteFun.GetUserFriendLinkTotalByUser( para );
                        break;
                    case 12935:
                        result = ExecuteFun.GetUserIDByStr( para );
                        break;
                    case 12936:
                        result = ExecuteFun.GetUserIDByUserWeb( para );
                        break;
                    case 12938:
                        result = ExecuteFun.LoginUser( para );
                        break;
                    case 1293801:
                        result = ExecuteFun.CheckUserAccount( para );
                        break;
                    case 12939:
                        result = ExecuteFun.InsertUserLoginLog( para );
                        break;
                    case 12940:
                        result = ExecuteFun.DeleteUserMessage( para );
                        break;
                    case 12941:
                        result = ExecuteFun.DeleteUserMessageAll( para );
                        break;
                    case 12942:
                        result = ExecuteFun.InsertUserMessage( para );
                        break;
                    case 12943:
                        result = ExecuteFun.CheckNickName( para );
                        break;
                    case 12947:
                        result = ExecuteFun.UpdateUserPoints( para );
                        break;
                    case 12948:
                        result = ExecuteFun.DeleteUserPrivMsg( para );
                        break;
                    case 12949:
                        result = ExecuteFun.DeleteUserPrivMsgHead( para );
                        break;
                    case 12950:
                        result = ExecuteFun.DeleteUserPrivMsgHeadAll( para );
                        break;
                    case 12951:
                        result = ExecuteFun.InsertUserPrivMsg( para );
                        break;
                    case 12952:
                        result = ExecuteFun.CheckUserPrivMsgSend( para );
                        break;
                    case 12953:
                        result = ExecuteFun.InsertUserRechargePaymentRecord( para );
                        break;
                    case 12954:
                        result = ExecuteFun.InsertUser( para );
                        break;
                    case 12955:
                        result = ExecuteFun.GetUserBindTypeByID( para );
                        break;
                    case 12957:
                        result = ExecuteFun.GetUserForbid( para );
                        break;
                    case 12958:
                        result = ExecuteFun.CheckUserSign( para );
                        break;
                    case 12959:
                        result = ExecuteFun.InsertUserSignLog( para );
                        break;
                    case 12960:
                        result = ExecuteFun.UpdateYmbUserByID( para );
                        break;
                    case 12961:
                        result = ExecuteFun.UpdateUserForbid( para );
                        break;
                    case 12962:
                        result = ExecuteFun.UpdateUserPrivSet( para );
                        break;
                    case 12963:
                        result = ExecuteFun.UpdateUserKey( para );
                        break;
                    case 12964:
                        result = ExecuteFun.UpdateUserPassword( para );
                        break;
                    case 12965:
                        result = ExecuteFun.UpdateMemberCenterForUserPhoto( para );
                        break;
                    case 12967:
                        result = ExecuteFun.InsertUserFriendApply( para );
                        break;
                    case 12969:
                        result = ExecuteFun.ClearUserAllMessage( para );
                        break;
                    #endregion
                    #region 模块130
                    case 13002:
                        result = ExecuteFun.InsertUserWebBrowser( para );
                        break;
                    #endregion
                    #region 模块131
                    case 13101:
                        result = ExecuteFun.DeleteWxAuth( para );
                        break;
                    case 13102:
                        result = ExecuteFun.GetUserIDByWxID( para );
                        break;
                    case 13103:
                        result = ExecuteFun.InsertWxAuth( para );
                        break;
                    case 13105:
                        result = ExecuteFun.UpdateWxPaymentState( para );
                        break;
                    case 13108:
                        result = ExecuteFun.AddWxSendMessage( para );
                        break;
                    case 13109:
                        result = ExecuteFun.UpdateWXMsgSendState( para );
                        break;
                    case 13115:
                        result = ExecuteFun.AddWXSmallAuth( para );
                        break;
                    #endregion
                    #region 模块134
                    case 13408:
                        result = ExecuteFun.UpdateThirdGoodsPriceByID( para );
                        break;
                    case 13435:
                        result = ExecuteFun.UpdateGoodsNameByGoodsID( para );
                        break;
                    case 13436:
                        result = ExecuteFun.UpdateGoodsAltNameByGoodsID( para );
                        break;
                    case 13437:
                        result = ExecuteFun.UpdateGoodsDescriptionByGoodsID( para );
                        break;
                    case 13438:
                        result = ExecuteFun.UpdateGoodsStateByGoodsID( para );
                        break;
                    case 13439:
                        result = ExecuteFun.UpdateGoodsInfoByGoodsID( para );
                        break;
                    case 13440:
                        result = ExecuteFun.UpdateGoodsOtherInfoByGoodsID( para );
                        break;
                    case 13441:
                        result = ExecuteFun.InsertGoodsInfo( para );
                        break;
                    case 13442:
                        result = ExecuteFun.UpdateGoodsBrandLabelByGoodsID( para );
                        break;
                    case 13443:
                        result = ExecuteFun.AddGoodspic( para );
                        break;
                    case 13444:
                        result = ExecuteFun.ModGoodspicByPicID( para );
                        break;
                    case 13445:
                        result = ExecuteFun.DelGoodsPicByPicID( para );
                        break;
                    case 134350:
                        result = ExecuteFun.UpdateAllGoodsInfoByGoodsID( para );
                        break;
                    #endregion
                    #region 模块144
                    case 14401:
                        result = ExecuteFun.FilterInsertKeywords( para );
                        break;
                    case 14402:
                        result = ExecuteFun.FilterDeleteKeywords( para );
                        break;
                    case 14405:
                        result = ExecuteFun.FilteraddFilterLog( para );
                        break;
                    case 14406:
                        result = ExecuteFun.FilterEditKeywords( para );
                        break;
                    #endregion
                    #region 模块146
                    case 14601:
                        result = ExecuteFun.InsertReportUser( para );
                        break;
                    #endregion
                    #region 模块162
                    case 16201:
                        result = ExecuteFun.GetFundItemCount( para );
                        break;
                    case 16203:
                        result = ExecuteFun.ModFundItemHit( para );
                        break;
                    case 16204:
                        result = ExecuteFun.ModFundItemRead( para );
                        break;
                    #endregion
                    #region 模块1001
                    case 100102:
                        result = ExecuteFun.UpdateMonitorIsSend();
                        break;
                    #endregion
                    #region 模块150
                    case 15001:
                        result = ExecuteFun.InsertBarInfo( para );
                        break;
                    case 15002:
                        result = ExecuteFun.UpdateBarInfo( para );
                        break;
                    case 15005:
                        result = ExecuteFun.InsertBarInviteUser( para );
                        break;
                    #endregion
                    #region 模块401
                    case 40103:
                        result = ExecuteFun.appUsingTheApp( para );
                        break;
                    case 40105:
                        result = ExecuteFun.ChkAppUserComment( para );
                        break;
                    case 40106:
                        result = ExecuteFun.AddAppComments( para );
                        break;
                    #endregion
                    #region 模块404
                    case 40402:
                        result = ExecuteFun.AddRealNameAuth( para );
                        break;
                    case 40403:
                        result = ExecuteFun.AddAuthLog( para );
                        break;
                    case 40404:
                        result = ExecuteFun.CheckAuthApi( para );
                        break;
                    case 40409:
                        result = ExecuteFun.UpdateLiveVideoTitle( para );
                        break;
                    case 40412:
                        result = ExecuteFun.UpdateLiveReplayURL( para );
                        break;
                    case 40414:
                        result = ExecuteFun.UpdateLiveReplayCnt( para );
                        break;
                    case 40418:
                        result = ExecuteFun.AddLiveWishBarcode( para );
                        break;
                    case 40419:
                        result = ExecuteFun.UpdateWishBarcodeStatus( para );
                        break;
                    case 40420:
                        result = ExecuteFun.CheckWishBarcodeStatusCnt( para );
                        break;
                    case 40423:
                        result = ExecuteFun.AddLiveReport( para );
                        break;
                    case 40428:
                        result = ExecuteFun.UpdateLivesendWord( para );
                        break;
                    case 40431:
                        result = ExecuteFun.UpdateLiveViewerNum( para );
                        break;
                    #endregion
                }
                _RetVal = result > 0 ? -200 : -201;
            }
            catch ( Exception ex )
            {
                _RetVal = -202;
                UtilityFile.AddLogErrMsg( string.Format( "ExecuteBase.ExecuteForInt module:{0} Ex：{1}", module, ex.Message ) );
            }
            return _RetVal;
        }
        #endregion

        #region ExecuteForInt2( out int result, out int count, int module, params object[] para )
        /// <summary>
        /// 执行查询过程输出整数
        /// </summary>
        /// <param name="result">输出整数</param>
        /// <param name="count">返回统计数</param>
        /// <param name="module">数据库过程编号</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        public int ExecuteForInt2( out int result, out int count, int module, params object[] para )
        {
            int _RetVal = -203;
            result = 0;
            count = 0;
            try
            {
                switch ( module )
                {
                    case 11424:
                        result = ExecuteFun.InsertGroupTopic( out count, para );
                        break;
                    case 11774:
                        result = ExecuteFun.CheckPayPwdByUserID( out count, para );
                        break;
                    case 12507:
                        result = ExecuteFun.GetUserIDFromQQAuth( out count, para );
                        break;
                    case 13102:
                        result = ExecuteFun.GetUserIDByWxID( out count, para );
                        break;
                }
                _RetVal = result > 0 ? -200 : -201;
            }
            catch ( Exception ex )
            {
                _RetVal = -202;
                UtilityFile.AddLogErrMsg( string.Format( "ExecuteBase.ExecuteForInt module:{0} Ex：{1}", module, ex.Message ) );
            }
            return _RetVal;
        }
        #endregion

        #region ExecuteForString( out string result, int module, params object[] para )
        /// <summary>
        /// 执行查询过程输出字符串
        /// </summary>
        /// <param name="result">输出字符串</param>
        /// <param name="module">数据库过程编号</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        public int ExecuteForString( out string result, int module, params object[] para )
        {
            int _RetVal = -203;
            result = "";
            try
            {
                switch ( module )
                {
                    case 10405:
                        result = ExecuteFun.GetCodeRTime( para );
                        break;
                    case 11732:
                        result = ExecuteFun.GetMemberCenterForUserPhoto( para );
                        break;
                    case 12903:
                        result = ExecuteFun.GetUserBindTypeList( para );
                        break;
                    case 12937:
                        result = ExecuteFun.GetUserKey( para );
                        break;
                    case 13107:
                        result = ExecuteFun.GetWxIDByUserID( para );
                        break;
                }
                _RetVal = -200;
            }
            catch ( Exception ex )
            {
                _RetVal = -202;
                UtilityFile.AddLogErrMsg( string.Format( "ExecuteBase.ExecuteForString module:{0} Ex：{1}", module, ex.Message ) );
            }
            return _RetVal;
        }
        #endregion

        #region ExecuteForDecimal( out decimal result, int module, params object[] para )
        /// <summary>
        /// 执行查询过程输出小数
        /// </summary>
        /// <param name="result">输出字符串</param>
        /// <param name="module">数据库过程编号</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        public int ExecuteForDecimal( out decimal result, int module, params object[] para )
        {
            int _RetVal = -203;
            result = 0m;
            try
            {
                switch ( module )
                {
                    case 12933:
                        result = ExecuteFun.GetUserBalance( para );
                        break;
                    case 16202:
                        result = ExecuteFun.GetFundItemMoney( para );
                        break;
                }
                _RetVal = -200;
            }
            catch ( Exception ex )
            {
                _RetVal = -202;
                UtilityFile.AddLogErrMsg( string.Format( "ExecuteBase.ExecuteForDecimal module:{0} Ex：{1}", module, ex.Message ) );
            }
            return _RetVal;
        }
        #endregion

        #region ExecuteForLong( out long result, int module, params object[] para )
        /// <summary>
        /// 执行查询过程输出长整型
        /// </summary>
        /// <param name="result">输出长整型</param>
        /// <param name="module">数据库过程编号</param>
        /// <param name="para">参数集</param>
        /// <returns></returns>
        public int ExecuteForLong( out long result, int module, params object[] para )
        {
            int _RetVal = -203;
            result = 0L;
            try
            {
                switch ( module )
                {
                    case 12322:
                        result = ExecuteFun.GetPayShopID( para );
                        break;
                    case 12912:
                        result = ExecuteFun.GetBarcodeSalesTotal();
                        break;
                    case 12944:
                        result = ExecuteFun.GetUserPointsByUserID( para );
                        break;
                }
                _RetVal = -200;
            }
            catch ( Exception ex )
            {
                _RetVal = -202;
                UtilityFile.AddLogErrMsg( string.Format( "ExecuteBase.ExecuteForLong module:{0} Ex：{1}", module, ex.Message ) );
            }
            return _RetVal;
        }
        #endregion
    }
}
