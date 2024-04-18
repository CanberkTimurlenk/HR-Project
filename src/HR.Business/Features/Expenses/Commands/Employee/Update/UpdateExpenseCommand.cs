﻿using HR.Base.Response;
using MediatR;

namespace HR.Business.Features.Expenses.Commands.Employee.Update;

public record UpdateExpenseCommand(int UserId, int ExpenseId, UpdateExpenseCommandRequest Model) : IRequest<ApiResponse>;

public record UpdateExpenseCommandRequest(int ExpenseType, decimal Amount, int CurrencyType, List<string> AttachedFiles);
