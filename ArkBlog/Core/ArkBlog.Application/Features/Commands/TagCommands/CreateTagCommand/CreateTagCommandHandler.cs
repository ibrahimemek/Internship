using ArkBlog.Application.Abstracts.Repositories.TagRepo;
using ArkBlog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Features.Commands.TagCommands.CreateTagCommand
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommandRequest, CreateTagCommandResponse>
    {
        ITagWriteRepository _tagWriteRepository;
        ITagReadRepository _tagReadRepository;


        public CreateTagCommandHandler(ITagWriteRepository tagWriteRepository, ITagReadRepository tagReadRepository)
        {
            _tagWriteRepository = tagWriteRepository;
            _tagReadRepository = tagReadRepository;
        }

        public async Task<CreateTagCommandResponse> Handle(CreateTagCommandRequest request, CancellationToken cancellationToken)
        {
            var result = _tagReadRepository.GetWhere(t => t.TagName == request.TagName);
            if (result.Any())
            {
                return new CreateTagCommandResponse()
                {
                    Succeeded = false,
                    Message = "There is already a tag with same name."
                };
            }
                
            _tagWriteRepository.AddAsync(new PostTag()
            {
                TagName = request.TagName

            });
            await _tagWriteRepository.SaveChangesAsync();
            return new CreateTagCommandResponse()
            {
                Succeeded = true,
                Message = "Success."
            }; ;
            
        }
    }
}
