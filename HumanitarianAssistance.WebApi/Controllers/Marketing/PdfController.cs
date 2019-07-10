using System;
using System.Threading.Tasks;
using HumanitarianAssistance.DataAccess.DbEntities;
using HumanitarianAssistance.Service.APIResponses;
using HumanitarianAssistance.Service.interfaces.Marketing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HumanitarianAssistance.WebApi.Controllers.Marketing
{
  [Produces("application/json")]
  [Route("api/Pdf/[Action]")]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class PdfController : Controller
  {
    IUnitOfWork _uow;
    private IHostingEnvironment _hostingEnvironment;
    private IJobDetailsService _iJobDetailService;
    
    public PdfController(IJobDetailsService iJobDetailService, IUnitOfWork uow, UserManager<AppUser> userManager, IJobDetailsService iJobDetailsService, IHostingEnvironment environment)
    {
      this._uow = uow;
      _iJobDetailService = iJobDetailService;
      _hostingEnvironment = environment;
      
    } 

   

    [HttpPost]
    //[Route("CreatePDF")]
    public async Task<APIResponse> CreatePDF([FromBody]int JobId)
    {
      APIResponse apiRespone = null;
      apiRespone = await _iJobDetailService.CreatePDF(JobId);
      return apiRespone;

    }
  }
}
