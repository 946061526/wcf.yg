using System;
using System.ServiceProcess;
using System.ServiceModel;

namespace wcfNSYGShop
{
    partial class WinService : ServiceBase
    {
        private WCFServiceHost _Host;

        public WinService()
        {
            InitializeComponent();
        }

        protected override void OnStart( string[] args )
        {
            // TODO: 在此处添加代码以启动服务。
            try
            {
                _Host = new WCFServiceHost();
                _Host.Start();
            }
            catch
            {
            }
        }

        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
            try
            {
                _Host.Stop();
            }
            catch
            {
            }
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
                UtilityFile.AddLogErrMsg( "webhost", "WCF Service A is start." );
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
                    UtilityFile.AddLogErrMsg( "webhost", "WCF Service A is stop." );
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
