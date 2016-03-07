using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using LendingLibrary.Data.Infrastructure;
using LendingLibrary.Data.Repositories;
using LendingLibrary.Entities;
using LendingLibrary.Web.Infrastructure.Core;
using LendingLibrary.Web.Models;

namespace LendingLibrary.Web.Controllers
{
    [RoutePrefix("api/media")]
    public class MediaController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Medium> _mediaRepository;

        public MediaController(
            IEntityBaseRepository<Medium> mediaRepository,
            IEntityBaseRepository<Error> errorsRepository,
            IUnitOfWork unitOfWork)
            : base(errorsRepository, unitOfWork)
        {
            _mediaRepository = mediaRepository;
        }

        [AllowAnonymous]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var media = _mediaRepository.GetAll().ToList();

                IEnumerable<MediumViewModel> mediaVM = Mapper.Map<IEnumerable<Medium>, IEnumerable<MediumViewModel>>(media);

                response = request.CreateResponse<IEnumerable<MediumViewModel>>(HttpStatusCode.OK, mediaVM);

                return response;
            });
        }
    }
}