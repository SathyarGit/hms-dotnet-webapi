using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.HMS.Foliotypes;

public class UpdateFoliotypeRequest : IRequest<DefaultIdType>
{
    public DefaultIdType Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class UpdateFoliotypeRequestHandler : IRequestHandler<UpdateFoliotypeRequest, DefaultIdType>
{
    private readonly IRepository<Foliotype> _repository;
    private readonly IStringLocalizer _t;

    public UpdateFoliotypeRequestHandler(IRepository<Foliotype> repository, IStringLocalizer<UpdateFoliotypeRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<DefaultIdType> Handle(UpdateFoliotypeRequest request, CancellationToken cancellationToken)
    {
        var foliotype = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = foliotype ?? throw new NotFoundException(_t["Foliotype {0} Not Found.", request.Id]);

        var updatedFoliotype = foliotype.Update(request.Name, request.Description);

        // Add Domain Events to be raised after the commit
        foliotype.DomainEvents.Add(EntityUpdatedEvent.WithEntity(foliotype));

        await _repository.UpdateAsync(updatedFoliotype, cancellationToken);

        return request.Id;
    }
}