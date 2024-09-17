using APICenterFlit.Entities;
using APICenterFlit.Models;
using AutoMapper;

namespace APICenterFlit.Helper
{
	public class MyAutoMapper : Profile
	{
		public MyAutoMapper()
		{
			CreateMap<Content, ContentDTO>().ReverseMap();
			CreateMap<ContentType, ContentTypeDTO>().ReverseMap();
			CreateMap<News, NewsDTO>().ReverseMap();
			CreateMap<NewsType, NewsTypeDTO>().ReverseMap();
			CreateMap<Account, AccountDTO>().ReverseMap();
			CreateMap<AccountType, AccountTypeDTO>().ReverseMap();
		}
	}
}
