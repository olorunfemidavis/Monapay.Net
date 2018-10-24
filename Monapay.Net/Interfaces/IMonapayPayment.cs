using Monapay.Net.Models;
using System.Threading.Tasks;

namespace Monapay.Net.Interfaces
{
    public interface IMonapayPayment
    {
        string GetInitializePaymentUrl(InitializePaymentRequestModel requestModel);

        Task<VerifyPaymentResponseModel> VerifyPayment(string reference_id);
    }
}
