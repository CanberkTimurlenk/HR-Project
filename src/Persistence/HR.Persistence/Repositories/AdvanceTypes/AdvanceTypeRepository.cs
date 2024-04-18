using HR.Application.Contracts.Repositories.Admins;
using HR.Domain.Entities.Concrete;
using HR.Persistence.Contexts;
using HR.Persistence.Repositories.Common;

namespace HR.Persistence.Repositories.AdvanceTypes;

public class AdvanceTypeRepository(HrDbContext context) : EfBaseRepository<AdvanceType>(context), IAdvanceTypeRepository

{

}
