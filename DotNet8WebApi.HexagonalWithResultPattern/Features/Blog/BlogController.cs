using Microsoft.AspNetCore.Mvc;

namespace DotNet8WebApi.HexagonalWithResultPattern.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : BaseController
    {
        private readonly BL_Blog _bL_Blog;

        public BlogController(BL_Blog bL_Blog)
        {
            _bL_Blog = bL_Blog;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            try
            {
                var result = await _bL_Blog.GetBlogs();
                return Content(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            try
            {
                var result = await _bL_Blog.GetBlog(id);
                return Content(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] BlogRequestModel requestModel)
        {
            try
            {
                var result = requestModel.IsValid();
                if (!result.Success)
                    return BadRequest(result);

                result = await _bL_Blog.CreateBlog(requestModel);
                return Content(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchBlog([FromBody] BlogRequestModel requestModel, int id)
        {
            try
            {
                var result = await _bL_Blog.PatchBlog(requestModel, id);
                return Content(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            try
            {
                var result = await _bL_Blog.DeleteBlog(id);
                return Content(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
