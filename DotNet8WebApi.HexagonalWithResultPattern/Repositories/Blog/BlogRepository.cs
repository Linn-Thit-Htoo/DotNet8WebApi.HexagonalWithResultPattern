using DotNet8WebApi.HexagonalWithResultPattern.DbService.AppDbContexts;
using DotNet8WebApi.HexagonalWithResultPattern.Mapper;
using DotNet8WebApi.HexagonalWithResultPattern.Models.Features;
using DotNet8WebApi.HexagonalWithResultPattern.Models.Features.Blog;
using DotNet8WebApi.HexagonalWithResultPattern.Models.Resources;
using DotNet8WebApi.HexagonalWithResultPattern.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotNet8WebApi.HexagonalWithResultPattern.Repositories.Blog
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _appDbContext;

        public BlogRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Result<BlogResponseModel>> CreateBlog(BlogRequestModel requestModel)
        {
            Result<BlogResponseModel> responseModel;
            try
            {
                await _appDbContext.TblBlogs.AddAsync(requestModel.Change());
                int result = await _appDbContext.SaveChangesAsync();

                responseModel = Result<BlogResponseModel>.ExecuteResult(result);
            }
            catch (Exception ex)
            {
                responseModel = Result<BlogResponseModel>.FailureResult(ex);
            }

            return responseModel;
        }

        public async Task<Result<BlogResponseModel>> DeleteBlog(int id)
        {
            Result<BlogResponseModel> responseModel;
            try
            {
                var item = await _appDbContext.TblBlogs
                    .FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null)
                {
                    responseModel = Result<BlogResponseModel>.FailureResult(MessageResource.NotFound);
                    goto result;
                }

                _appDbContext.TblBlogs.Remove(item);
                int result = await _appDbContext.SaveChangesAsync();

                responseModel = Result<BlogResponseModel>.ExecuteResult(result);
            }
            catch (Exception ex)
            {
                responseModel = Result<BlogResponseModel>.FailureResult(ex);
            }

        result:
            return responseModel;
        }

        public async Task<Result<BlogModel>> GetBlog(int id)
        {
            Result<BlogModel> responseModel;
            try
            {
                var item = await _appDbContext.TblBlogs
                    .FindAsync(id);
                if (item is null)
                {
                    responseModel = Result<BlogModel>.FailureResult(MessageResource.NotFound);
                    goto result;
                }

                BlogModel model = item.Change();
                responseModel = Result<BlogModel>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                responseModel = Result<BlogModel>.FailureResult(ex);
            }

        result:
            return responseModel;
        }

        public async Task<Result<BlogListResponseModel>> GetBlogs()
        {
            Result<BlogListResponseModel> responseModel;
            try
            {
                var dataLst = await _appDbContext.TblBlogs
                    .OrderByDescending(x => x.BlogId)
                    .ToListAsync();
                var lst = dataLst.Select(x => x.Change()).ToList();

                var model = new BlogListResponseModel
                {
                    DataLst = lst
                };

                responseModel = Result<BlogListResponseModel>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                responseModel = Result<BlogListResponseModel>.FailureResult(ex);
            }

            return responseModel;
        }

        public async Task<Result<BlogResponseModel>> PatchBlog(BlogRequestModel requestModel, int id)
        {
            Result<BlogResponseModel> responseModel;
            try
            {
                var item = await _appDbContext.TblBlogs
                    .FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null)
                {
                    responseModel = Result<BlogResponseModel>.FailureResult(MessageResource.NotFound);
                    goto result;
                }

                if (!requestModel.BlogTitle.IsNullOrEmpty())
                    item.BlogTitle = requestModel.BlogTitle;

                if (!requestModel.BlogAuthor.IsNullOrEmpty())
                    item.BlogAuthor = requestModel.BlogAuthor;

                if (!requestModel.BlogContent.IsNullOrEmpty())
                    item.BlogContent = requestModel.BlogContent;

                _appDbContext.TblBlogs.Update(item);
                int result = await _appDbContext.SaveChangesAsync();

                responseModel = Result<BlogResponseModel>.ExecuteResult(result);
            }
            catch (Exception ex)
            {
                responseModel = Result<BlogResponseModel>.FailureResult(ex);
            }

        result:
            return responseModel;
        }
    }
}
