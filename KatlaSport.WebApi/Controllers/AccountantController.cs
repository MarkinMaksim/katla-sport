using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using KatlaSport.Services.AccountantManagment;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using Swashbuckle.Swagger.Annotations;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/accountant")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class AccountantController : ApiController
    {
        private readonly IAccountantService _accountantService;

        public AccountantController(IAccountantService accountantService)
        {
            _accountantService = accountantService ?? throw new ArgumentNullException(nameof(accountantService));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of accountant.", Type = typeof(AccountantRequest[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetAccountants()
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;

            config.Formatters.JsonFormatter
                        .SerializerSettings
                        .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            var accountants = await _accountantService.GetAccountantsAsync();
            return Ok(accountants);
        }

        [HttpGet]
        [Route("{accountantsId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a accounmtant.", Type = typeof(AccountantRequest))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetAccountant(int accountantsId)
        {
            var accountant = await _accountantService.GetAccountantAsync(accountantsId);
            return Ok(accountant);
        }

        [HttpPost]
        [Route()]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new accountant.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddAccountant()
        {
            var httprequest = HttpContext.Current.Request;
            var file = httprequest.Files["Image"];
            var data = httprequest.Form["data"];
            var createRequest = JsonConvert.DeserializeObject<AccountantRequest>(data);
           
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"].ToString());

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("webappstoragedotnet-imagecontainer");
            await blobContainer.CreateIfNotExistsAsync();
            await blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            
            var accountant = await _accountantService.CreateAccountantAsync(createRequest,blobContainer, file);
            var location = string.Format("/api/hives/{0}", accountant.Id);
            return Created(location, accountant);
        }
        
        [HttpPut]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed product.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateHive([FromUri] int id)
        {
            var httprequest = HttpContext.Current.Request;
            var file = httprequest.Files["Image"];
            var data = httprequest.Form["data"];
            var createRequest = JsonConvert.DeserializeObject<AccountantRequest>(data);

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"].ToString());

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("webappstoragedotnet-imagecontainer");
            await blobContainer.CreateIfNotExistsAsync();
            await blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            await _accountantService.UpdateAccountantAsync(id, createRequest, blobContainer, file);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpDelete]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed hive.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteHive([FromUri] int id)
        {

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"].ToString());

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("webappstoragedotnet-imagecontainer");
            await blobContainer.CreateIfNotExistsAsync();
            await blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            await _accountantService.DeleteAccaountantAsync(id, blobContainer);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}