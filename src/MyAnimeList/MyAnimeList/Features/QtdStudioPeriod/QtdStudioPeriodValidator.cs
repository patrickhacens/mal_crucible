using FluentValidation;

namespace MyAnimeList.Features.QtdStudioPeriod;

public class QtdStudioPeriodValidator : AbstractValidator<QtdStudioPeriodRequest>
{
    public QtdStudioPeriodValidator()
    {
        //RuleFor(p => p).Must(p => (p.ano == 0) || (p.mes >= 0 && p.mes <= 12));

    }﻿
}
