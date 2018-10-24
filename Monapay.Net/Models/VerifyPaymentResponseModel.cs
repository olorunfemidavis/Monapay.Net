using System;
using System.Collections.Generic;
using System.Text;

namespace Monapay.Net.Models
{
    public class VerifyPaymentResponseModel
    {
        public string status { get; set; }
        public Data data { get; set; }
    }
    public class VerifyPaymentResponseErrorModel
    {
        public string status { get; set; }
        public string message { get; set; }
        public string code { get; set; }
    }
    public class Data
    {
        public string id { get; set; }
        public string reference_id { get; set; }
        public string user_id { get; set; }
        public string temp_uuid { get; set; }
        public string type { get; set; }
        public string is_credit { get; set; }
        public string product_key { get; set; }
        public string amount { get; set; }
        public string description { get; set; }
        public string confirmed { get; set; }
        public string confirmed_time { get; set; }
        public string successful { get; set; }
        public string condition { get; set; }
        public string created { get; set; }
        public string status { get; set; }
        public string full_condition { get; set; }
        public int current_balance { get; set; }
        public string temp_phone { get; set; }
        public string product_id { get; set; }
        public string balance_before { get; set; }
        public string balance_after { get; set; }
        public string return_url { get; set; }
        public string live { get; set; }
        public string allow_sms { get; set; }
        public object initiated_reference_id { get; set; }
        public string merchant_id { get; set; }
        public string merchant_name { get; set; }


    }
}
