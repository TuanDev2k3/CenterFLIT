using APICenterFlit.Data;
using APICenterFlit.Entities;
using APICenterFlit.Helper;
using APICenterFlit.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APICenterFlit.Repositories.Portal
{
	public interface INewsTypeService
	{
		Task<Response> GetListAsync();
		Task<Response> GetById(int id);
		Task<Response> Create(NewsTypeDTO model, int userId);        
		Task<Response> Update(NewsTypeDTO model, int id, int userId);
		Task<Response> Delete(int id, int userId);
	}
	public class NewsTypeService : INewsTypeService
	{
		private readonly CenterFlitContext _db;
		private readonly IMapper _mapper;
		public NewsTypeService(CenterFlitContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		public async Task<Response> Create(NewsTypeDTO model, int userId)
		{
			Response res = new Response();
			try
			{
				NewsType data = _mapper.Map<NewsTypeDTO, NewsType>(model);
				int maxId = await _db.NewsTypes.MaxAsync(m => (int?)m.Id) ?? 0;
				data.Id = maxId + 1;
				data.Status = 1;
				data.CreatedAt = DateTime.Now;
				data.CreatedBy = userId;
				await _db.NewsTypes.AddAsync(data);
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
				var data = await _db.NewsTypes.Where(a => a.Status == 1 && a.Id == id).FirstOrDefaultAsync();
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
				var data = await _db.NewsTypes.Where(a => a.Status == 1 && a.Id == id).FirstOrDefaultAsync();
				if (data != null)
				{
					NewsTypeDTO model = new NewsTypeDTO();
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
				var data = await _db.NewsTypes.Where(a => a.Status == 1).ToListAsync();
				List<NewsTypeDTO> model = new List<NewsTypeDTO>();
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

		public async Task<Response> Update(NewsTypeDTO model, int id, int userId)
		{
			Response res = new Response();
			try
			{
				var data = await _db.NewsTypes.Where(a => a.Status == 1 && a.Id == id).FirstOrDefaultAsync();
				if (data != null)
				{
					_mapper.Map(model, data);
					data.Id = id;
					data.UpdatedAt = DateTime.Now;
					data.UpdatedBy = userId;
					_db.NewsTypes.Update(data);
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
