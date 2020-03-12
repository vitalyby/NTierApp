using System.Data.Entity;

public class MsSqlContext : DbContext
{
	public MsSqlContext() : base("name=DefaultConnection")
	{
	}

	public DbSet<NTierApp.BLL.Models.EmployeeModel> EmployeeModels { get; set; }

	public DbSet<NTierApp.BLL.Models.CompanyModel> CompanyModels { get; set; }
}
