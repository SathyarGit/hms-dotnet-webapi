using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Foliotypes;

public class CreateFoliotypeRequest : IRequest<DefaultIdType>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class CreateFoliotypeRequestHandler : IRequestHandler<CreateFoliotypeRequest, DefaultIdType>
{
    private readonly IRepository<Foliotype> _repository;

    public CreateFoliotypeRequestHandler(IRepository<Foliotype> repository) =>
        _repository = repository;

    public async Task<DefaultIdType> Handle(CreateFoliotypeRequest request, CancellationToken cancellationToken)
    {
        var foliotype = new Foliotype(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        foliotype.DomainEvents.Add(EntityCreatedEvent.WithEntity(foliotype));

        await _repository.AddAsync(foliotype, cancellationToken);

        return foliotype.Id;
    }
}