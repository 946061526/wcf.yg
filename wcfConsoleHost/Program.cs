using System;
using System.ServiceModel;

namespace wcfNSYGShop
{
    class Program
    {
        static void Main( string[] args )
        {
            using ( WCFServiceHost _Host = new WCFServiceHost() )
            {
                _Host.Start();

                Console.ReadLine();

                _Host.Stop();

                Console.ReadLine();
            }


            /*  客户端调用，添加服务引用：net.tcp://localhost:1234/userbuy
             * 
                UserbuyServiceRef.IUserBuy _Client = new UserbuyServiceRef.UserBuyClient();
                int _UserID = 163;
                int _Integral = 0;
                long _CartID = UtilityFun.ToInt64( DateTime.Now.ToString( "yyMMddHHmmssffffff" ) );
                this.hidShopID.Value = _CartID.ToString();
                _Client.UserBuyMainService( _UserID, _Integral, (byte)0, _CartID, "1.1.1.90" );
                _Client = null;
             * 
             */
        }
    }

    class WCFServiceHost : IDisposable
    {
        private ServiceHost _ServiceHost = null;

        private readonly Type _ServiceType = typeof( WCFServiceFun );

        /// <summary>
        /// 开启服务
        /// </summary>
        public void Start()
        {
            //配置文件中配置终结点
            _ServiceHost = new ServiceHost( _ServiceType );

            _ServiceHost.Opened += delegate
            {
                UtilityFile.WriteSystemSwitchFile( 1 );
                Console.WriteLine( "wcfWebService Service is start..." );
            };
            _ServiceHost.Open();
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        public void Stop()
        {
            if ( _ServiceHost != null )
            {
                _ServiceHost.Closed += delegate
                {
                    Console.WriteLine( "wcfWebService is stop..." );
                };
                _ServiceHost.Close();
                _ServiceHost = null;
            }
        }

        #region IDisposable 成员

        public void Dispose()
        {
            if ( _ServiceHost != null )
            {
                ( _ServiceHost as IDisposable ).Dispose();
            }
        }

        #endregion
    }
}
