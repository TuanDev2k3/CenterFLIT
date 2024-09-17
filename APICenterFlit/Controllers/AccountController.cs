using APICenterFlit.Helper;
using APICenterFlit.Models;
using APICenterFlit.Repositories.Portal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICenterFlit.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountService _service;
		Response res = new Response();
		public AccountController(IAccountService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<Response> GetList()
		{
			try
			{
				res = await _service.GetListAsync();
			}
			catch (Exception ex)
			{
				res.Status = 0;
				res.Message = ex.Message;
			}
			return res;
		}

		[HttpGet]
		public async Task<Response> GetById(int id)
		{
			try
			{
				res = await _service.GetById(id);
			}
			catch (Exception ex)
			{
				res.Status = 0;
				res.Message = ex.Message;
			}
			return res;
		}

		[HttpPost]
		public async Task<Response> Create(AccountDTO model, int userId)
		{
			try
			{
				res = await _service.Create(model, userId);
			}
			catch (Exception ex)
			{
				res.Status = 0;
				res.Message = ex.Message;
			}
			return res;
		}

		[HttpPut]
		public async Task<Response> Update(AccountDTO model, int id, int userId)
		{
			try
			{
				res = await _service.Update(model, id, userId);
			}
			catch (Exception ex)
			{
				res.Status = 0;
				res.Message = ex.Message;
			}
			return res;
		}

		[HttpDelete]
		public async Task<Response> Delete(int id, int userId)
		{
			try
			{
				res = await _service.Delete(id, userId);
			}
			catch (Exception ex)
			{
				res.Status = 0;
				res.Message = ex.Message;
			}
			return res;
		}

		[HttpPut]
		public async Task<Response> ChangePassword(string password, string newPassword, int id, int userId)
		{
			try
			{
				res = await _service.ChangePassword(password, newPassword, id, userId);
			}
			catch (Exception ex)
			{
				res.Status = 0;
				res.Message = ex.Message;
			}
			return res;
		}
	}
}
