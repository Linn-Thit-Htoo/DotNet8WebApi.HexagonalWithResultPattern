using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8WebApi.HexagonalWithResultPattern.Models.Features.Blog
{
    public class BlogRequestModel
    {
        public string? BlogTitle { get; set; }

        public string? BlogAuthor { get; set; }

        public string? BlogContent { get; set; }

        public Result<BlogResponseModel> IsValid()
        {
            Result<BlogResponseModel> responseModel;

            if (string.IsNullOrEmpty(BlogTitle))
            {
                responseModel = Result<BlogResponseModel>.FailureResult("Blog Title cannot be empty.");
                goto result;
            }

            if (string.IsNullOrEmpty(BlogAuthor))
            {
                responseModel = Result<BlogResponseModel>.FailureResult("Blog Author cannot be empty.");
                goto result;
            }

            if (string.IsNullOrEmpty(BlogContent))
            {
                responseModel = Result<BlogResponseModel>.FailureResult("Blog Content cannot be empty.");
                goto result;
            }

            responseModel = Result<BlogResponseModel>.SuccessResult();

        result:
            return responseModel;
        }
    }
}
