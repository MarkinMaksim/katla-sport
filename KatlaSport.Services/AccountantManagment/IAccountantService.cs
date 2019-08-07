using KatlaSport.DataAccess.AccountantCatalogue;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace KatlaSport.Services.AccountantManagment
{
    /// <summary>
    /// Represents a product category service.
    /// </summary>
    public interface IAccountantService
    {
        Task<List<AccountantRequest>> GetAccountantsAsync();

        Task<AccountantRequest> GetAccountantAsync(int accountantid);

        Task<Accountant> CreateAccountantAsync(AccountantRequest accountant, CloudBlobContainer blobContainer, HttpPostedFile file);

        Task<Accountant> UpdateAccountantAsync(int accountantId, AccountantRequest updateAccountant, CloudBlobContainer blobContainer, HttpPostedFile file);

        Task DeleteAccaountantAsync(int accountantId, CloudBlobContainer blobContainer);
    }
}
