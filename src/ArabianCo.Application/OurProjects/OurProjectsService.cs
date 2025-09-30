using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ArabianCo.CrudAppServiceBase;
using ArabianCo.Domain.Attachments;
using ArabianCo.Domain.OurProjects;
using ArabianCo.OurProjects.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ArabianCo.OurProjects
{
        public class OurProjectsService : ArabianCoAsyncCrudAppService<OurProject, OurProjectsDto, int, LiteOurProjectsDto, PagedOurProjectsResultRequestDto, CreateOurProjectsDto, UpdateOurProjectsDto>, IOurprojectsService
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
                public override async Task<PagedResultDto<LiteOurProjectsDto>> GetAllAsync(PagedOurProjectsResultRequestDto input)
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

                protected override IQueryable<OurProject> CreateFilteredQuery(PagedOurProjectsResultRequestDto input)
                {
                        return base.CreateFilteredQuery(input).Include(x => x.Translations);
                }

                protected override LiteOurProjectsDto MapToLiteEntityDto(OurProject entity)
                {
                        var dto = base.MapToLiteEntityDto(entity);
                        ApplyLocalizedFields(entity, dto);
                        return dto;
                }

                protected override OurProjectsDto MapToEntityDto(OurProject entity)
                {
                        var dto = base.MapToEntityDto(entity);
                        ApplyLocalizedFields(entity, dto);
                        return dto;
                }

                private void ApplyLocalizedFields(OurProject entity, LiteOurProjectsDto dto)
                {
                        var translation = GetTranslationForCurrentLanguage(entity);
                        if (translation == null || dto == null)
                        {
                                return;
                        }

                        dto.Name = translation.Name;
                        dto.System = translation.System;
                        dto.Location = translation.location;
                }

                private void ApplyLocalizedFields(OurProject entity, OurProjectsDto dto)
                {
                        var translation = GetTranslationForCurrentLanguage(entity);
                        if (translation == null || dto == null)
                        {
                                return;
                        }

                        dto.Name = translation.Name;
                        dto.System = translation.System;
                        dto.Location = translation.location;
                }

                private OurProjectsTranslation GetTranslationForCurrentLanguage(OurProject entity)
                {
                        if (entity?.Translations == null || entity.Translations.Count == 0)
                        {
                                return null;
                        }

                        var currentCulture = CultureInfo.CurrentUICulture;
                        if (currentCulture != null)
                        {
                                var translation = FindTranslation(entity, currentCulture.Name);
                                if (translation != null)
                                {
                                        return translation;
                                }

                                translation = FindTranslation(entity, currentCulture.TwoLetterISOLanguageName);
                                if (translation != null)
                                {
                                        return translation;
                                }
                        }

                        return entity.Translations.FirstOrDefault();
                }

                private static OurProjectsTranslation FindTranslation(OurProject entity, string language)
                {
                        if (string.IsNullOrWhiteSpace(language))
                        {
                                return null;
                        }

                        return entity.Translations.FirstOrDefault(
                                t => string.Equals(t.Language, language, StringComparison.OrdinalIgnoreCase));
                }
        }
}
