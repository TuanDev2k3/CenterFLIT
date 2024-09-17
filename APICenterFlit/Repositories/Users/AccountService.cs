using APICenterFlit.Data;
using APICenterFlit.Entities;
using APICenterFlit.Helper;
using APICenterFlit.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APICenterFlit.Repositories.Portal
{
	public interface IAccountService
	{
		Task<Response> GetListAsync();
		Task<Response> GetById(int id);
		Task<Response> Create(AccountDTO model, int userId);
		Task<Response> Update(AccountDTO model, int id, int userId);
		Task<Response> Delete(int id, int userId);
		Task<Response> ChangePassword(string password, string newPassword, int id, int userId);
	}
	public class AccountService : IAccountService
	{
		private readonly CenterFlitContext _db;
		private readonly IMapper _mapper;
		public AccountService(CenterFlitContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		public async Task<Response> ChangePassword(string password, string newPassword, int id, int userId)
		{
			Response res = new Response();
			try
			{
				var data = await _db.Accounts.Where(a => a.Status == 1 && a.Id == id).FirstOrDefaultAsync();
				if (data != null && PasswordHelper.VerifyPassword(password, data.Password))
				{
					data.Password = PasswordHelper.HashPassword(newPassword);
					data.UpdatedAt = DateTime.Now;
					data.UpdatedBy = userId;
					await _db.SaveChangesAsync();
					res.Status = 204;
					res.Message = "Thay đổi mật khẩu thành công !!";
				}
				else
				{
					res.Status = 401;
					res.Message = "Không tìm thấy tài khoản hoặc mật khẩu cũ không chính xác !!";
				}
			}
			catch (Exception ex)
			{
				res.Status = 400;
				res.Message = ex.InnerException?.Message ?? ex.Message;
			}
			return res;
		}

		public async Task<Response> Create(AccountDTO model, int userId)
		{
			Response res = new Response();
			try
			{
				Account data = _mapper.Map<AccountDTO, Account>(model);
				int maxId = await _db.Accounts.MaxAsync(m => (int?)m.Id) ?? 0;
				data.Id = maxId + 1;
				data.Password = PasswordHelper.HashPassword(data.Password);
				data.AccountType = data.AccountType ?? "USR";
				data.Status = 1;
				data.CreatedAt = DateTime.Now;
				data.CreatedBy = userId;
				await _db.Accounts.AddAsync(data);
				await _db.SaveChangesAsync();

				res.Status = 201;
				res.Message = "Thêm dữ liệu thành công !!";
			}
			catch (Exception ex)
			{
				res.Status = 400;
				res.Message = ex.InnerException?.Message ?? ex.Message;
			}
			return res;
		}

		public async Task<Response> Delete(int id, int userId)
		{
			Response res = new Response();
			try
			{
				var data = await _db.Accounts.Where(a => a.Status == 1 && a.Id == id).FirstOrDefaultAsync();
				if (data != null)
				{
					data.Status = -1;
					data.UpdatedAt = DateTime.Now;
					data.UpdatedBy = userId;
					await _db.SaveChangesAsync();
					res.Status = 200;
					res.Message = "Xóa dữ liệu thành công !!";
				}
				else
				{
					res.Status = 401;
					res.Message = "Không tìm thấy dữ liệu cần xóa !!";
				}
			}
			catch (Exception ex)
			{
				res.Status = 400;
				res.Message = ex.InnerException?.Message ?? ex.Message;
			}
			return res;
		}

		public async Task<Response> GetById(int id)
		{
			Response res = new Response();
			try
			{
				var data = await _db.Accounts.Where(a => a.Status == 1 && a.Id == id).FirstOrDefaultAsync();
				if (data != null)
				{
					AccountDTO model = new AccountDTO();
					_mapper.Map(data, model);
					res.Status = 200;
					res.Message = "Lấy dữ liệu thành công !!";
					res.Data = model;
				}
				else
				{
					res.Status = 401;
					res.Message = "Không tìm thấy dữ liệu cần tìm !!";
				}
			}
			catch (Exception ex)
			{
				res.Status = 400;
				res.Message = ex.InnerException?.Message ?? ex.Message;
			}
			return res;
		}

		public async Task<Response> GetListAsync()
		{
			Response res = new Response();
			try
			{
				var data = await _db.Accounts.Where(a => a.Status == 1).ToListAsync();
				List<AccountDTO> model = new List<AccountDTO>();
				_mapper.Map(data, model);
				res.Status = 200;
				res.Message = "Lấy dữ liệu thành công";
				res.Data = model;
			}
			catch (Exception ex)
			{
				res.Status = 400;
				res.Message = ex.InnerException?.Message ?? ex.Message;
			}
			return res;
		}

		public async Task<Response> Update(AccountDTO model, int id, int userId)
		{
			Response res = new Response();
			try
			{
				var data = await _db.Accounts.Where(a => a.Status == 1 && a.Id == id).FirstOrDefaultAsync();

				if (data != null)
				{
					_mapper.Map(model, data);
					data.Id = id;
					data.Password = PasswordHelper.HashPassword(data.Password);
					data.AccountType = data.AccountType ?? "USR";
					data.UpdatedAt = DateTime.Now;
					data.UpdatedBy = userId;
					_db.Accounts.Update(data);
					await _db.SaveChangesAsync();
					res.Status = 204;
					res.Message = "Sửa dữ liệu thành công !!";
				}
				else
				{
					res.Status = 401;
					res.Message = "Không tìm thấy dữ liệu cần sửa !!";
				}
			}
			catch (Exception ex)
			{
				res.Status = 400;
				res.Message = ex.InnerException?.Message ?? ex.Message;
			}
			return res;
		}
	}
}
