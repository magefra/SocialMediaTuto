using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Responses;
using SocialMedia.Core.src.DTOs;
using SocialMedia.Core.src.Entities;
using SocialMedia.Core.src.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IPostService _postService;


        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;




        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var post = await _postService.Get();
            var postDtos = _mapper.Map<IEnumerable<PostDto>>(post);
            var response = new ApiResponse<IEnumerable<PostDto>>(postDtos);

            return Ok(response);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _postService.getId(id);
            var postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);


            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {

            var post = _mapper.Map<Post>(postDto);
            await _postService.add(post);
            postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);

            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Put(int id, PostDto postDto)
        {

            var post = _mapper.Map<Post>(postDto);
            post.Id = id;
            var result = await _postService.Update(post);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postService.Delete(id);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }



    }
}
