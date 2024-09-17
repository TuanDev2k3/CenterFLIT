using APICenterFlit.Data;
using APICenterFlit.Entities;
using APICenterFlit.Helper;
using APICenterFlit.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APICenterFlit.Repositories.Portal
{
	public interface IContentService
	{
		Task<Response> GetListAsync();
		Task<Response> GetById(int id);
		Task<Response> Create(ContentDTO model, int userId);
		Task<Response> Update(ContentDTO model, int id, int userId);
		Task<Response> Delete(int id, int userId);
	}
	public class ContentService : IContentService
	{
		private readonly CenterFlitContext _db;
		private readonly IMapper _mapper;
		public ContentService(CenterFlitContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		public async Task<Response> Create(ContentDTO model, int userId)
		{
			Response res = new Response();
			try
			{
				Content data = _mapper.Map<ContentDTO, Content>(model);
				int maxId = await _db.Contents.MaxAsync(m => (int?)m.Id) ?? 0;
				data.Id = maxId + 1;
				data.Status = 1;
				data.CreatedAt = DateTime.Now;
				data.CreatedBy = userId;
				await _db.Contents.AddAsync(data);
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
				var data = await _db.Contents.Where(a => a.Status == 1 && a.Id == id).FirstOrDefaultAsync();
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
				var data = await _db.Contents.Where(a => a.Status == 1 && a.Id == id).FirstOrDefaultAsync();
				if (data != null)
				{
					ContentDTO model = new ContentDTO();
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
				var data = await _db.Contents.Where(a => a.Status == 1).ToListAsync();
				List<ContentDTO> model = new List<ContentDTO>();
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

		public async Task<Response> Update(ContentDTO model, int id, int userId)
		{
			Response res = new Response();
			try
			{
				var data = await _db.Contents.Where(a => a.Status == 1 && a.Id == id).FirstOrDefaultAsync();
				if (data != null)
				{
					_mapper.Map(model, data);
					data.Id = id;
					data.UpdatedAt = DateTime.Now;
					data.UpdatedBy = userId;
					_db.Contents.Update(data);
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
