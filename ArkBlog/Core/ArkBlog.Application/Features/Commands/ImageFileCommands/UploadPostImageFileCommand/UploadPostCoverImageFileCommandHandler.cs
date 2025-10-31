using ArkBlog.Application.Abstracts.Repositories.PostCoverImageFileRepo;
using ArkBlog.Application.Abstracts.Repositories.PostRepo;
using ArkBlog.Application.Abstracts.Storages;
using ArkBlog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ArkBlog.Application.Features.Commands.ImageFileCommands.UploadPostImageFileCommand
{
    public class UploadPostCoverImageFileCommandHandler : IRequestHandler<UploadPostCoverImageFileCommandRequest, UploadPostCoverImageFileCommandResponse>
    {
       

        IStorageService _storageService;
        IPostReadRepository _postReadRepository;
        IPostCoverImageFileReadRepository _postImageFileReadRepository;
        IPostCoverImageFileWriteRepository _postImageFileWriteRepository;


        public UploadPostCoverImageFileCommandHandler(IStorageService storageService, IPostReadRepository postReadRepository,
            IPostCoverImageFileWriteRepository postImageFileWriteRepository, IPostCoverImageFileReadRepository postImageFileReadRepository)
        {
            _storageService = storageService;
            _postReadRepository = postReadRepository;
            _postImageFileWriteRepository = postImageFileWriteRepository;
            _postImageFileReadRepository = postImageFileReadRepository;
        }

        public async Task<UploadPostCoverImageFileCommandResponse> Handle(UploadPostCoverImageFileCommandRequest request, CancellationToken cancellationToken)
        {
            (string fileName, string pathOrContainerName) result;
            Post post = await _postReadRepository.GetByIdAsync(request.Id);
            
            IQueryable<PostCoverImageFile> prevCover = _postImageFileReadRepository.GetWhere(p => p.Post == post);
            _postImageFileWriteRepository.RemoveRange(prevCover.ToList());
              
            
            
            result = await _storageService.UploadAsync("blog-cover-images", request.File);


            PostCoverImageFile postImageFile = new PostCoverImageFile
            {
                FileName = result.fileName,
                Path = result.pathOrContainerName,
                Storage = _storageService.StorageName,
                Post = post
            };



            await _postImageFileWriteRepository.AddAsync(
                postImageFile
            );
            
            await _postImageFileWriteRepository.SaveChangesAsync();

            post.CoverImage = postImageFile;

            return new UploadPostCoverImageFileCommandResponse()
            {
                PathOrContainer = result.pathOrContainerName
            };


        }
    }
}
