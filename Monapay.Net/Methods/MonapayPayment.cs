using Monapay.Net.Helpers;
using Monapay.Net.Interfaces;
using Monapay.Net.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Monapay.Net.Methods
{
    public class MonapayPayment : IMonapayPayment
    {
        private readonly string _secretKey;
        public MonapayPayment(string secretKey)
        {
            this._secretKey = secretKey;
        }
        public MonapayPayment()
        {

        }

        private static string GetContent(Dictionary<string, string> values)
        {
            return JsonConvert.SerializeObject(values);
        }

        private static string GetUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return "merchant";
            }

            return $"merchant/{url}";
        }

        private static string GetUrl()
        {
            return "merchant";
        }
        /// <summary>
        /// Payment Initialization
        /// The process is to construct a payment url with the product detail and other params, the essential params are ref_id, merchant_id, key, uuid, amount and description of the transaction. The developer will have to load the generated url in the browser, or redirect the page to the url (in case of webapp) for user to interact with.
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public string GetInitializePaymentUrl(InitializePaymentRequestModel requestModel)
        {
            string url = Constants.MonapayBaseURL + GetUrl("pay?");
            IEnumerable<string> properties = from p in requestModel.GetType().GetProperties()
                                             where p.GetValue(requestModel, null) != null
                                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(requestModel, null).ToString());
            string queryString = url + string.Join("&", properties.ToArray());
            return queryString;
        }
        /// <summary>
        /// Payment Verification
        /// Immediately after closing the popup browser(web) or in-app browser (native), the developer will make an HTTP GET request with the transaction reference id to fetch the status of the transaction.
        /// </summary>
        /// <param name="reference_id"></param>
        /// <returns></returns>
        public async Task<VerifyPaymentResponseModel> VerifyPayment(string reference_id)
        {
            string url = GetUrl($"verifytransaction/{reference_id}");
            string getResult = await BaseClient.GetEntities(url, this._secretKey);
            return JsonConvert.DeserializeObject<VerifyPaymentResponseModel>(getResult);
        }
    }
}
