using APICenterFlit.Repositories.Portal;

namespace APICenterFlit
{
	public class DI
	{
		public static void DI_Portal(IServiceCollection services)
		{
			services.AddScoped<IContentService, ContentService>();
			services.AddScoped<IContentTypeService, ContentTypeService>();
			services.AddScoped<INewsService, NewsService>();
			services.AddScoped<INewsTypeService, NewsTypeService>();
		}

		public static void DI_Users(IServiceCollection services)
		{
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IAccountTypeService, AccountTypeService>();
		}
	}
}
