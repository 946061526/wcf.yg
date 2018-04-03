using Newtonsoft.Json;

namespace wcfNSYGShop
{
    public class MDLDGBarcodeInfo
    {
        /// <summary>
        /// 本云状态，1进行中，2已满员，3已揭晓
        /// </summary>
        [JsonProperty( "state" )]
        public int State
        {
            get;
            set;
        }
    }
}
