using FluentValidation;

namespace MyAnimeList.Features.Import;

public class ImportDataValidator : AbstractValidator<ImportDataRequest>
{
    public ImportDataValidator()
    {
        RuleFor(p => p.PathToRawFolder).NotEmpty();
    }
}
