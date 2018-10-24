# Monapay.Net
##### The MonaPay.Net API allows developers to integrate monapay wallet system into their .Net applications capable of displaying a webpage for user interactivity. 
##### This wallet can easily be funded via User airtime balance or with any credit or debit cards. International cards can also be used.

Visit [monapay](https://www.monapay.com) for Setup.

### Prerequisites

This Library require .Net framework 4.6 or higher


### Installing
Install this library from [Nuget](https://www.nuget.org/packages/Monapay.Net/)



## Author

* **Olorunfemi Ajibulu** -  [Booksrite](https://www.booksrite.com/)

## License

This project is licensed under the MIT License

## Upcoming: 
* More precise intellisense
* More Documentation in this README file


## SDK Usage
Add namespaces: 
##### using Monapay.Net;
##### using Monapay.Net.Models;
##### using Monapay.Net.Helpers;
##### using Monapay.Net.Methods;


#### We suggest you go through the detailed documentation:
* **Read Documentation Here** -  [monapay API Documentation](https://www.monapay.com/api-doc)


### Transactions

#### Transaction Initialization

        /// <summary>
        /// Implements simple InitializePayment with full parameters
        /// </summary>
        private static void InitializePayment()
        {
            var connectionInstance = new MonapayPayment();
            //var PaymentUrl = connectionInstance.GetInitializePaymentUrl(new InitializePaymentRequestModel() { amount = 30000, description = "some text", merchant_id = "merchant_id", product_key = "product_key", redirect_url = "redirect_url", uuid = "uiid", reference_id = "ref_id" });
            var PaymentUrl = connectionInstance.GetInitializePaymentUrl(new InitializePaymentRequestModel() { amount = 30000, description = "some text", merchant_id = "merchant_id", product_key = "product_key", redirect_url = "redirect_url"});
            Console.WriteLine(PaymentUrl);
            System.Diagnostics.Process.Start(PaymentUrl);

            //For Web
            //Response.AddHeader("Access-Control-Allow-Origin", "*");
            // Response.AppendHeader("Access-Control-Allow-Origin", "*");
            //Response.Redirect(PaymentUrl); //Redirects your browser to the secure URL
        }


#### Transaction Verification
    /// <summary>
        /// Payment Verification
        /// </summary>
        private static async void VerifyPayment()
        {
            var connectionInstance = new MonapayPayment("key");
            var response =await connectionInstance.VerifyPayment("ref");
            Console.WriteLine(JsonConvert.SerializeObject(response));
        }

