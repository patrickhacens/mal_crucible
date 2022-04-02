using FluentValidation;

namespace MyAnimeList.Features.QtdStudioPeriod;

public class QtdStudioPeriodValidator : AbstractValidator<QtdStudioPeriodRequest>
{
    public QtdStudioPeriodValidator()
    {
        RuleFor(p => p).Must(p => (!p.Mes.HasValue) || p.Ano.HasValue);
    }﻿

}
