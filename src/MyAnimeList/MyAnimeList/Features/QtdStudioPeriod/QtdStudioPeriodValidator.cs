<<<<<<< HEAD
﻿using FluentValidation;

namespace MyAnimeList.Features.QtdStudioPeriod;

public class QtdStudioPeriodValidator : AbstractValidator<QtdStudioPeriodRequest>
{
    public QtdStudioPeriodValidator()
    {
        RuleFor(p => p).Must(p => (p.ano == 0) ||  (p.mes >= 0 && p.mes <= 12));
=======
﻿namespace MyAnimeList.Features.QtdStudioPeriod
{
    public class QtdStudioPeriodValidator
    {
>>>>>>> b8e770cf411d41109d687957dbe1cb09d8f8e8f9
    }
}
