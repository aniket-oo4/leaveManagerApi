using LM.Core;
using LM.Core.DTO;
using LM.Core.OrgManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
namespace LeaveManagement.Controllers.OrgApi
{
     [Authorize(Roles = "admin,manager,user")]
    public class OrganisationController : ApiController
    {
        private readonly OrgManager _orgManager;

        public OrganisationController()
        {
            _orgManager = new OrgManager();
        }

      


        // GET 
        [Route("api/organisation/GetPublicHolidays/{orgId}")]
        public ActionResult<List<PublicHolidays>> GetHolidays(int orgId)
        {
            var result = _orgManager.GetAllPublicHolidays(orgId);
            return result;
        }

        // GET 
        [Route("api/organisation/GetDepartments/{orgId}")]
        public ActionResult<List<Departments>> GetDepartments(int orgId)
        {
            var result = _orgManager.GetAllDepartments(orgId);
            return result;
        }
        // GET 
        [Route("api/organisation/GetCostCenters/{orgId}")]
        public ActionResult<List<CostCenters>> GetCostCenters(int orgId)
        {
            var result = _orgManager.GetAllCostCenters(orgId);
            return result;
        }

    }
}
