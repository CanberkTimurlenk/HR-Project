﻿using HR.Api.Helpers;
using HR.Data.Contexts;
using HR.Schema.Response;
using MediatR;
using System;

namespace HR.Application.Features.Users.Commands.ResetPassword;

public class ResetPasswordCommandHandler(HrDbContext dbContext)
    : IRequestHandler<ResetPasswordCommand, ApiResponse>
{
    private readonly HrDbContext dbContext = dbContext;
    public async Task<ApiResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        //var admin = await dbContext.Users.FindAsync([3], cancellationToken: cancellationToken);

        //admin.Password = Md5Extension.GetHash(request.NewPassword);
        //var result = await dbContext.SaveChangesAsync(cancellationToken);

        //return new ApiResponse();

        return null;
    }
}
