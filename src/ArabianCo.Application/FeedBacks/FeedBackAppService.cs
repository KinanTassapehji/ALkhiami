using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ArabianCo.CrudAppServiceBase;
using ArabianCo.Domain.FeedBacks;
using ArabianCo.Domain.Questions;
using ArabianCo.FeedBacks.Dto;
using ArabianCo.Questions;
using ArabianCo.Questions.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.FeedBacks
{
	public class FeedBackAppService : ArabianCoAsyncCrudAppService<FeedBack, FeedBackDto, int, FeedBackDto, PagedFeedBackResultRequest, CreateFeedBackDto, UpdateFeedBackDto>, IFeedBackAppService
	{
		public FeedBackAppService(IRepository<FeedBack, int> repository) : base(repository)
		{
		}

		protected override IQueryable<FeedBack> CreateFilteredQuery(PagedFeedBackResultRequest input)
		{
			var data = base.CreateFilteredQuery(input);
			if (input.IsApproved.HasValue)
				data = data.Where(x => x.IsApproved == input.IsApproved.Value);
			return data;
		}
		protected override IQueryable<FeedBack> ApplySorting(IQueryable<FeedBack> query, PagedFeedBackResultRequest input)
		{
			var data = base.ApplySorting(query, input);
			data = data.OrderByDescending(x => x.CreationTime);
			return data;
		}
		public Task ChangeApprovalStatus(int id)
		{
			var entity = Repository.Get(id);
			entity.IsApproved = !entity.IsApproved;
			entity.LastModificationTime = DateTime.UtcNow;
			return Repository.UpdateAsync(entity);
		}

		public override Task<FeedBackDto> UpdateAsync(UpdateFeedBackDto input)
		{
			return base.UpdateAsync(input);
		}
		public override Task DeleteAsync(EntityDto<int> input)
		{
			return base.DeleteAsync(input);
		}
	}
}
