using ArabianCo.CrudAppServiceBase;
using ArabianCo.FeedBacks.Dto;

namespace ArabianCo.FeedBacks;

	public interface IFeedBackAppService : IArabianCoAsyncCrudAppService<FeedBackDto, int, FeedBackDto, PagedFeedBackResultRequest, CreateFeedBackDto, UpdateFeedBackDto>
	{
	}

