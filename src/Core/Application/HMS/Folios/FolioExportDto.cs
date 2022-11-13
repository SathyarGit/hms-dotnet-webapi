namespace FSH.WebApi.Application.HMS.Folios;

public class FolioExportDto : IDto
{
    public string? Description { get; set; } = default!;
    public string FoliotypeName { get; set; } = default!;
}