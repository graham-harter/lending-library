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
    [RoutePrefix("api/titles")]
    public class TitlesController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Title> _titlesRepository;
        private readonly IEntityBaseRepository<Medium> _mediaRepository;

        public TitlesController(
            IEntityBaseRepository<Title> titlesRepository,
            IEntityBaseRepository<Medium> mediaRepository,
            IEntityBaseRepository<Error> errorsRepository,
            IUnitOfWork unitOfWork)
            : base(errorsRepository, unitOfWork)
        {
            _titlesRepository = titlesRepository;
            _mediaRepository = mediaRepository;
        }

        [AllowAnonymous]
        [Route("latest")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var titles = _titlesRepository.GetAll().OrderBy(m => m.ID).Take(8).ToList();

                IEnumerable<TitleViewModel> titlesVM = Mapper.Map<IEnumerable<Title>, IEnumerable<TitleViewModel>>(titles);

                response = request.CreateResponse<IEnumerable<TitleViewModel>>(HttpStatusCode.OK, titlesVM);

                return response;
            });
        }
    }
}