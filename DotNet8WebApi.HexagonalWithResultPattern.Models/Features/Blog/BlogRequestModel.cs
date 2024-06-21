using DotNet8WebApi.HexagonalWithResultPattern.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8WebApi.HexagonalWithResultPattern.Models.Features.Blog
{
    public class BlogRequestModel
    {
        public string BlogTitle { get; set; } = null!;

        public string BlogAuthor { get; set; } = null!;

        public string BlogContent { get; set; } = null!;

        public Result<BlogResponseModel> IsValid()
        {
            Result<BlogResponseModel> responseModel;

            if (BlogTitle.IsNullOrEmpty())
            {
                responseModel = Result<BlogResponseModel>.FailureResult("Blog Title cannot be empty.");
                goto result;
            }

            if (BlogAuthor.IsNullOrEmpty())
            {
                responseModel = Result<BlogResponseModel>.FailureResult("Blog Author cannot be empty.");
                goto result;
            }

            if (BlogContent.IsNullOrEmpty())
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
