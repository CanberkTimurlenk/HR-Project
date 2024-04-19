﻿using FluentValidation;
using HR.Application.Features.Advances.Queries.GetById;
using HR.Application.Features.Advances.Queries.Manager.GetById;

namespace HR.Application.Features.Advances.Queries.Manager.GetByEmployeeId;
public class GetAdvanceByIdQueryValidator : AbstractValidator<GetAdvanceByIdQuery>
{
    public GetAdvanceByIdQueryValidator()
    {
        RuleFor(x => x.AdvanceId).NotEmpty();

        RuleFor(x => x.AdvanceId)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Advance id must be greater than or equal to 1.");
    }
}
