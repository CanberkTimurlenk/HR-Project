﻿using HR.Schema.Response;
using MediatR;

namespace HR.Application.Features.Advances.Queries.GetById;
public record GetAdvanceByIdQuery(int EmployeeId, int AdvanceId) : IRequest<ApiResponse<AdvanceResponse>>;