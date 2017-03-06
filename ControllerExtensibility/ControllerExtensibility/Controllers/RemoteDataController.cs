using System.Web.Mvc;
using ControllerExtensibility.Models;
using System.Threading.Tasks;

namespace ControllerExtensibility.Controllers
{
    public class RemoteDataController : Controller
    {
        // GET: RemoteData
        public async Task<ActionResult> Data()
        {
            //RemoteService service = new RemoteService();
            //string data = service.GetRemoteData();
            string data = await Task<string>.Factory.StartNew(() => { return new RemoteService().GetRemoteData(); });
            return View((object)data);
        }

        public async Task<ActionResult> ConsumeAsyncMethod()
        {
            string data = await new RemoteService().GetRemoteDataAsync();
            return View("Data", (object)data);
        }
    }
}