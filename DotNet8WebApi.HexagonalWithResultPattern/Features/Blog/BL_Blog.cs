using DotNet8WebApi.HexagonalWithResultPattern.Models.Features;
using DotNet8WebApi.HexagonalWithResultPattern.Models.Features.Blog;
using DotNet8WebApi.HexagonalWithResultPattern.Repositories.Blog;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DotNet8WebApi.HexagonalWithResultPattern.Features.Blog
{
    public class BL_Blog
    {
        private readonly IBlogRepository _blogRepository;

        public BL_Blog(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Result<BlogListResponseModel>> GetBlogs()
        {
            return await _blogRepository.GetBlogs();
        }

        public async Task<Result<BlogModel>> GetBlog(int id)
        {
            Result<BlogModel> responseModel;
            if (id <= 0)
            {
                responseModel = Result<BlogModel>.FailureResult("Id is invalid.");
                goto result;
            }

            responseModel = await _blogRepository.GetBlog(id);

        result:
            return responseModel;
        }

        public async Task<Result<BlogResponseModel>> CreateBlog(BlogRequestModel requestModel)
        {
            return await _blogRepository.CreateBlog(requestModel);
        }

        public async Task<Result<BlogResponseModel>> PatchBlog(BlogRequestModel requestModel, int id)
        {
            Result<BlogResponseModel> responseModel;

            if (id <= 0)
            {
                responseModel = Result<BlogResponseModel>.FailureResult("Id is invalid.");
                goto result;
            }

            responseModel = await _blogRepository.PatchBlog(requestModel, id);

        result:
            return responseModel;
        }

        public async Task<Result<BlogResponseModel>> DeleteBlog(int id)
        {
            Result<BlogResponseModel> responseModel;

            if (id <= 0)
            {
                responseModel = Result<BlogResponseModel>.FailureResult("Id is invalid.");
                goto result;
            }

            responseModel = await _blogRepository.DeleteBlog(id);

        result:
            return responseModel;
        }
    }
}
