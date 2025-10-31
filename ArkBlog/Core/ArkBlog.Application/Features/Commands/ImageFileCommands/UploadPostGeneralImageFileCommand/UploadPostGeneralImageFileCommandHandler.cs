using ArkBlog.Application.Abstracts.Repositories.PostGeneralImageFileRepo;
using ArkBlog.Application.Abstracts.Repositories.PostRepo;
using ArkBlog.Application.Abstracts.Storages;
using ArkBlog.Application.Features.Commands.ImageFileCommands.UploadPostImageFileCommand;
using ArkBlog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ArkBlog.Application.Features.Commands.ImageFileCommands.UploadPostGeneralImageFileCommand
{
    public class UploadPostGeneralImageFileCommandHandler : IRequestHandler<UploadPostGeneralImageFileCommandRequest, UploadPostGeneralImageFileCommandResponse>
    {
       

        IStorageService _storageService;
        IPostReadRepository _postReadRepository;
        IPostGeneralImageFileReadRepository _postImageFileReadRepository;
        IPostGeneralImageFileWriteRepository _postImageFileWriteRepository;


        public UploadPostGeneralImageFileCommandHandler(IStorageService storageService, IPostReadRepository postReadRepository,
            IPostGeneralImageFileWriteRepository postImageFileWriteRepository, IPostGeneralImageFileReadRepository postImageFileReadRepository)
        {
            _storageService = storageService;
            _postReadRepository = postReadRepository;
            _postImageFileWriteRepository = postImageFileWriteRepository;
            _postImageFileReadRepository = postImageFileReadRepository;
        }

        public async Task<UploadPostGeneralImageFileCommandResponse> Handle(UploadPostGeneralImageFileCommandRequest request, CancellationToken cancellationToken)
        {
            (string fileName, string pathOrContainerName) result;
            Post post = await _postReadRepository.GetByIdAsync(request.Id);
            
            
            
            result = await _storageService.UploadAsync("blog-images", request.File);
            



            await _postImageFileWriteRepository.AddAsync(
                new PostGeneralImageFile
                {
                    FileName = result.fileName,
                    Path = result.pathOrContainerName,
                    Storage = _storageService.StorageName,
                    Post = post,
                }
            );
            
            await _postImageFileWriteRepository.SaveChangesAsync();


            return new UploadPostGeneralImageFileCommandResponse()
            {
                PathOrContainer = result.pathOrContainerName
            };


        }
    }
}
