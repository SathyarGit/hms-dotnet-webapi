using FSH.WebApi.Application.Common.Exporters;

namespace FSH.WebApi.Application.HMS.Travelagents;

public class ExportTravelagentsRequest : BaseFilter, IRequest<Stream>
{
}

public class ExportTravelagentsRequestHandler : IRequestHandler<ExportTravelagentsRequest, Stream>
{
    private readonly IReadRepository<Travelagent> _repository;
    private readonly IExcelWriter _excelWriter;

    public ExportTravelagentsRequestHandler(IReadRepository<Travelagent> repository, IExcelWriter excelWriter)
    {
        _repository = repository;
        _excelWriter = excelWriter;
    }

    public async Task<Stream> Handle(ExportTravelagentsRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExportTravelagentsWithBrandsSpecification(request);

        var list = await _repository.ListAsync(spec, cancellationToken);

        return _excelWriter.WriteToStream(list);
    }
}

public class ExportTravelagentsWithBrandsSpecification : EntitiesByBaseFilterSpec<Travelagent, TravelagentExportDto>
{
    public ExportTravelagentsWithBrandsSpecification(ExportTravelagentsRequest request)
        : base(request)
    {
    }
}