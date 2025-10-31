using ArkBlog.Application.Abstracts.Repositories.PostRepo;
using ArkBlog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Features.Commands.PostCommands.RemoveByIdCommand
{
    public class RemoveByIdCommandHandler : IRequestHandler<RemoveByIdCommandRequest, RemoveByIdCommandResponse>
    {
        IPostReadRepository _readRepository;
        IPostWriteRepository _writeRepository;

        public RemoveByIdCommandHandler(IPostReadRepository readRepository, IPostWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<RemoveByIdCommandResponse> Handle(RemoveByIdCommandRequest request, CancellationToken cancellationToken)
        {
            bool success = await _writeRepository.RemoveAsync(request.Id);
            if (success) await _writeRepository.SaveChangesAsync();
            return new RemoveByIdCommandResponse() { Succeeded = success};
            
        }
    }
}
