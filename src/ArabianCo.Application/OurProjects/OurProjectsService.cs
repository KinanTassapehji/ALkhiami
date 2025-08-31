using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ArabianCo.AboutUss;
using ArabianCo.AboutUss.Dto;
using ArabianCo.CrudAppServiceBase;
using ArabianCo.Domain.AboutUss;
using ArabianCo.Domain.Attachments;
using ArabianCo.Domain.OurProjects;
using ArabianCo.OurProjects.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabianCo.OurProjects
{
	public class OurProjectsService : ArabianCoAsyncCrudAppService<OurProject, OurProjectsDto, int, OurProjectsDto, PagedOurProjectsResultRequestDto, CreateOurProjectsDto, UpdateOurProjectsDto>, IOurprojectsService
	{
		private readonly IOurProjectsManager _ourProjectsManager;
		private readonly IAttachmentManager _attachmentManager;

		public OurProjectsService(IRepository<OurProject, int> repository, IOurProjectsManager ourProjectsManager, IAttachmentManager attachmentManager) : base(repository)
		{
			_ourProjectsManager = ourProjectsManager;
			_attachmentManager = attachmentManager;
		}
		[AbpAuthorize]
		public override async Task<OurProjectsDto> CreateAsync(CreateOurProjectsDto input)
		{
			var photo = await _attachmentManager.GetAndCheckAsync(input.AttachmentId, Enums.Enum.AttachmentRefType.OurProjects);
			var entity = await base.CreateAsync(input);
			await UnitOfWorkManager.Current.SaveChangesAsync();
			await _attachmentManager.UpdateRefIdAsync(photo, entity.Id);
			return entity;
		}
		public override async Task<PagedResultDto<OurProjectsDto>> GetAllAsync(PagedOurProjectsResultRequestDto input)
		{
			var result = await base.GetAllAsync(input);
			foreach (var item in result.Items)
			{
				var photo = await _attachmentManager.GetByRefAsync(item.Id, Enums.Enum.AttachmentRefType.OurProjects);
				if (photo != null)
				{
					item.Photo = new Attachments.Dto.LiteAttachmentDto
					{
						Id = photo.Id,
						RefType = photo.RefType,
						Url = _attachmentManager.GetUrl(photo)
					};
				}
			}
			return result;
		}
		public override async Task<OurProjectsDto> UpdateAsync(UpdateOurProjectsDto input)
		{
			var entity = await _ourProjectsManager.GetEntityByIdAsync(input.Id);
			entity.Translations.Clear();
			var photo = await _attachmentManager.GetByRefAsync(input.Id, Enums.Enum.AttachmentRefType.OurProjects);
			if (photo != null)
			{
				await _attachmentManager.DeleteRefIdAsync(photo);
			}
			await _attachmentManager.CheckAndUpdateRefIdAsync(input.AttachmentId, Enums.Enum.AttachmentRefType.OurProjects, input.Id);
			var entityDto = await base.UpdateAsync(input);
			return entityDto;
		}
		public override async Task<OurProjectsDto> GetAsync(EntityDto<int> input)
		{
			var entityDto = MapToEntityDto(await _ourProjectsManager.GetEntityByIdAsync(input.Id));
			var photo = await _attachmentManager.GetByRefAsync(input.Id, Enums.Enum.AttachmentRefType.OurProjects);
			if (photo != null)
			{
				entityDto.Photo = new Attachments.Dto.LiteAttachmentDto
				{
					Id = photo.Id,
					RefType = photo.RefType,
					Url = _attachmentManager.GetUrl(photo)
				};
			}
			return entityDto;
		}
	}
}
