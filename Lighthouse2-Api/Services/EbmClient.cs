using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Lighthouse2_Api.Models;

namespace Lighthouse2_Api.Services
{
    public class EbmClient
    {
        private HttpClient _client;

        readonly HttpClientHandler _httpClientHandler = new HttpClientHandler()
        {
            CookieContainer = new CookieContainer(),
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        };

        public EbmClient()
        {
            _client = new HttpClient(_httpClientHandler);
            _client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/95.0.4638.54 Safari/537.36");
        }

        public async Task<EbmOutput> Work(string signature)
        {
            var sig = signature.RemoveNonAlphaNumeric().Trim().ToUpper();
            if (sig.Length != 16) throw new MyException($"Wrong input {signature}");
            var response = await _client.GetJson<List<EbmResponse>>($"https://ebm.rra.gov.rw/backoffice//Autocomplete/ReceiptSignature?term={sig}");
            if (response.Count == 0) throw new MyException($"Can't find signature {signature}");
            var v = response[0].value;
            var embOutput = new EbmOutput()
            {
                Tin = v.TIN.Trim(),
                ClientsTin = v.ClientsTIN.Trim(),
                Mrc = v.MRC.Trim(),
                InternalData = v.SdcInternalData.Trim(),
                ReceiptLabel = $"{v.SdcReceiptTypeCounter}/{v.SdcTotalReceiptCounter} {v.SdcReceiptType}{v.SdcTransactionType}",
                SdcId = v.SdcId.Trim(),
                RunNumber = v.RunNumber.ToString(),
                ReceiptSignature = signature,
                CisDateAndTime = v.ReceiptDateTimeJson,
                SdcDateAndTime = v.SdcDateTimeJson,
                Tax =new List<Tax>()
                {
                    new Tax()
                    {
                        TaxRate = v.TaxRate1.ToString("#0.00"),
                        TaxableAmount = v.TaxableAmount1.ToString(),
                        TaxAmount = v.TaxableAmount1.ToString()
                    },
                    new Tax()
                    {
                        TaxRate = v.TaxRate2.ToString("#0.00"),
                        TaxableAmount = v.TaxableAmount2.ToString(),
                        TaxAmount = v.TaxableAmount2.ToString()
                    },
                    new Tax()
                    {
                        TaxRate = v.TaxRate3.ToString("#0.00"),
                        TaxableAmount = v.TaxableAmount3.ToString(),
                        TaxAmount = v.TaxableAmount3.ToString()
                    },
                    new Tax()
                    {
                        TaxRate = v.TaxRate4.ToString("#0.00"),
                        TaxableAmount = v.TaxableAmount4.ToString(),
                        TaxAmount = v.TaxableAmount4.ToString()
                    }
                } 
                
                //"[{\"Tax Rate\":"+v.TaxRate2.ToString("#0.00")+",\"Taxable Amount\":"+v.TaxableAmount2+",\"Tax Amount\":"+v.TaxAmount2+"}]"
            };
            return embOutput;
        }
    }
}