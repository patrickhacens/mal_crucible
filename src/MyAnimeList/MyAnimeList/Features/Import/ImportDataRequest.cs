using MediatR;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;

namespace MyAnimeList.Features.Import;

public class ImportDataRequest : IRequest<Result>
{
    public string PathToRawFolder { get; set; }
}
