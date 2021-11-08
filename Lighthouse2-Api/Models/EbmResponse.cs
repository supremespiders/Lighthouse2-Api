namespace Lighthouse2_Api.Models
{
    public class EbmResponse
    {
        public class Value
        {
            public string ReceiptDateTimeJson { get; set; }
            public string SdcDateTimeJson { get; set; }
            public int Id { get; set; }
            public object DbDateTime { get; set; }
            public object AuditDateTime { get; set; }
            public object Timestamp { get; set; }
            public string ReceiptDateTime { get; set; }
            public string TIN { get; set; }
            public string ClientsTIN { get; set; }
            public string MRC { get; set; }
            public int RunNumber { get; set; }
            public string ReceiptType { get; set; }
            public string TransactionType { get; set; }
            public double TotalAmount { get; set; }
            public double TaxRate1 { get; set; }
            public double TaxableAmount1 { get; set; }
            public double TaxAmount1 { get; set; }
            public double TaxRate2 { get; set; }
            public double TaxableAmount2 { get; set; }
            public double TaxAmount2 { get; set; }
            public double TaxRate3 { get; set; }
            public double TaxableAmount3 { get; set; }
            public double TaxAmount3 { get; set; }
            public double TaxRate4 { get; set; }
            public double TaxableAmount4 { get; set; }
            public double TaxAmount4 { get; set; }
            public string SdcId { get; set; }
            public string SdcDateTime { get; set; }
            public string SdcReceiptType { get; set; }
            public string SdcTransactionType { get; set; }
            public int SdcReceiptTypeCounter { get; set; }
            public int SdcTotalReceiptCounter { get; set; }
            public string SdcInternalData { get; set; }
            public string SdcReceiptSignature { get; set; }
            public object Journal { get; set; }
        }

        public string label { get; set; }
        public Value value { get; set; }
    }
}