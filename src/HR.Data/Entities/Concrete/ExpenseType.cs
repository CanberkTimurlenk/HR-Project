﻿using HR.Base;

namespace HR.Data.Entities.Concrete;

public class ExpenseType : BaseEntity
{
    public string TypeName { get; set; }
    public string Description { get; set; }

    public ICollection<Expense> Expenses { get; set; }
}