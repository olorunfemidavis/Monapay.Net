using Monapay.Net.Methods;
using Monapay.Net.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Tester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            InitializePayment();
            // VerifyPayment();
            Console.ReadKey();
        }
        /// <summary>
        /// Implements simple InitializePayment with full parameters
        /// </summary>
        private static void InitializePayment()
        {
            MonapayPayment connectionInstance = new MonapayPayment();
            string PaymentUrl = connectionInstance.GetInitializePaymentUrl(new InitializePaymentRequestModel() { amount = 30000, description = "some text", merchant_id = "merchant_id", product_key = "product_key", redirect_url = "redirect_url", uuid = "uiid", reference_id = "ref_id" });
            Console.WriteLine(PaymentUrl);
            System.Diagnostics.Process.Start(PaymentUrl);

            //For Web
            //Response.AddHeader("Access-Control-Allow-Origin", "*");
            // Response.AppendHeader("Access-Control-Allow-Origin", "*");
            //Response.Redirect(PaymentUrl); //Redirects your browser to the secure URL
        }

        /// <summary>
        /// Payment Verification
        /// </summary>
        private static void VerifyPayment()
        {
            MonapayPayment connectionInstance = new MonapayPayment("product_key");
            Task<VerifyPaymentResponseModel> response = connectionInstance.VerifyPayment("payment_ref");
            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
    }
}
