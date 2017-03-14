using System.Web.Mvc;
using MvcModels.Infrastructure;

namespace MvcModels.Models
{
    //[Bind(Include = "City")]
    [ModelBinder(typeof(AddressSummaryBinder))]
    public class AddressSummary
    {
        public string City { get; set; }
        public string Country { get; set; }
    }
}