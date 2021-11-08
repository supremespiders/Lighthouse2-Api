using System.Collections.Generic;

namespace Lighthouse2_Api.Models
{
    public class EbmOutput
    {
        public string Tin { get; set; }
        public string ClientsTin { get; set; }
        public string Mrc{ get; set; }
        public string RunNumber{ get; set; }
        public string CisDateAndTime{ get; set; }
        public List<Tax> Tax{ get; set; }
        public string SdcId{ get; set; }
        public string SdcDateAndTime{ get; set; }
        public string ReceiptLabel{ get; set; }
        public string InternalData{ get; set; }
        public string ReceiptSignature{ get; set; }
    }

    public class Tax
    {
        public string TaxRate { get; set; }
        public string TaxableAmount { get; set; }
        public string TaxAmount { get; set; }
    }

}