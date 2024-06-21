namespace DotNet8WebApi.HexagonalWithResultPattern.Repositories.Blog;

public interface IBlogRepository
{
    Task<Result<BlogListResponseModel>> GetBlogs();
    Task<Result<BlogModel>> GetBlog(int id);
    Task<Result<BlogResponseModel>> CreateBlog(BlogRequestModel requestModel);
    Task<Result<BlogResponseModel>> PatchBlog(BlogRequestModel requestModel, int id);
    Task<Result<BlogResponseModel>> DeleteBlog(int id);
}