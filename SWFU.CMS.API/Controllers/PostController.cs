using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SWFU.CMS.Core.Entities;
using SWFU.CMS.Core.interfaces;
using SWFU.CMS.Insfrastructure.Resources;

namespace SWFU.CMS.API.Controllers
{
    [Route("api/posts")]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;


        public PostController(
            IPostRepository postRepository,
            IUnitOfWork unitOfWork,
            ILoggerFactory loggerFactory,
            IMapper mapper)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger("SWFU.CMS.API.Controllers.PostController");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _postRepository.GetAllPostsAsync();
            _logger.LogError("Get All Posts......");
            var postResourse = _mapper.Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);
            return Ok(postResourse);
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var newPost = new Post
            {
                Author = "admin",
                Body = "123123123123123123123123",
                Title = "Title A",
                LastModified = DateTime.Now
            };
            _postRepository.AddPost(newPost);
            await _unitOfWork.SaveAsync();

            return Ok();
        }
    }
}