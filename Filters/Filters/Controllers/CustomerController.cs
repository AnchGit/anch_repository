using System.Web.Mvc;
using Filters.Infrastructure;

namespace Filters.Controllers
{
    [SimpleMessage(Message = "A")]
    public class CustomerController : Controller
    {
        // GET: Customer
        //[SimpleMessage(Message = "A", Order = 2)]
        //[SimpleMessage(Message = "B", Order = 1)]
        public string Index()
        {
            return "This is the Customer controller";
        }

        [CustomOverrideActionFilters]
        [SimpleMessage(Message = "B")]
        public string OtherAction()
        {
            return "This is the Other Action in the Customer controller";
        }
    }
}