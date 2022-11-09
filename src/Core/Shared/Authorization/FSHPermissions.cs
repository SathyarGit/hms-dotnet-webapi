using System.Collections.ObjectModel;

namespace FSH.WebApi.Shared.Authorization;

public static class FSHAction
{
    public const string View = nameof(View);
    public const string Search = nameof(Search);
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
    public const string Export = nameof(Export);
    public const string Generate = nameof(Generate);
    public const string Clean = nameof(Clean);
    public const string UpgradeSubscription = nameof(UpgradeSubscription);
}

public static class FSHResource
{
    public const string Tenants = nameof(Tenants);
    public const string Dashboard = nameof(Dashboard);
    public const string Hangfire = nameof(Hangfire);
    public const string Users = nameof(Users);
    public const string UserRoles = nameof(UserRoles);
    public const string Roles = nameof(Roles);
    public const string RoleClaims = nameof(RoleClaims);
    public const string Products = nameof(Products);
    public const string Brands = nameof(Brands);
    public const string Floors = nameof(Floors);
    public const string Departments = nameof(Departments);
    public const string Rooms = nameof(Rooms);
    public const string Employees = nameof(Employees);

}

public static class FSHPermissions
{
    private static readonly FSHPermission[] _all = new FSHPermission[]
    {
        new("View Dashboard", FSHAction.View, FSHResource.Dashboard),
        new("View Hangfire", FSHAction.View, FSHResource.Hangfire),
        new("View Users", FSHAction.View, FSHResource.Users),
        new("Search Users", FSHAction.Search, FSHResource.Users),
        new("Create Users", FSHAction.Create, FSHResource.Users),
        new("Update Users", FSHAction.Update, FSHResource.Users),
        new("Delete Users", FSHAction.Delete, FSHResource.Users),
        new("Export Users", FSHAction.Export, FSHResource.Users),
        new("View UserRoles", FSHAction.View, FSHResource.UserRoles),
        new("Update UserRoles", FSHAction.Update, FSHResource.UserRoles),
        new("View Roles", FSHAction.View, FSHResource.Roles),
        new("Create Roles", FSHAction.Create, FSHResource.Roles),
        new("Update Roles", FSHAction.Update, FSHResource.Roles),
        new("Delete Roles", FSHAction.Delete, FSHResource.Roles),
        new("View RoleClaims", FSHAction.View, FSHResource.RoleClaims),
        new("Update RoleClaims", FSHAction.Update, FSHResource.RoleClaims),
        new("View Products", FSHAction.View, FSHResource.Products, IsBasic: true),
        new("Search Products", FSHAction.Search, FSHResource.Products, IsBasic: true),
        new("Create Products", FSHAction.Create, FSHResource.Products),
        new("Update Products", FSHAction.Update, FSHResource.Products),
        new("Delete Products", FSHAction.Delete, FSHResource.Products),
        new("Export Products", FSHAction.Export, FSHResource.Products),
        new("View Brands", FSHAction.View, FSHResource.Brands, IsBasic: true),
        new("Search Brands", FSHAction.Search, FSHResource.Brands, IsBasic: true),
        new("Create Brands", FSHAction.Create, FSHResource.Brands),
        new("Update Brands", FSHAction.Update, FSHResource.Brands),
        new("Delete Brands", FSHAction.Delete, FSHResource.Brands),
        new("Generate Brands", FSHAction.Generate, FSHResource.Brands),
        new("Clean Brands", FSHAction.Clean, FSHResource.Brands),
        new("View Tenants", FSHAction.View, FSHResource.Tenants, IsRoot: true),
        new("Create Tenants", FSHAction.Create, FSHResource.Tenants, IsRoot: true),
        new("Update Tenants", FSHAction.Update, FSHResource.Tenants, IsRoot: true),
        new("Upgrade Tenant Subscription", FSHAction.UpgradeSubscription, FSHResource.Tenants, IsRoot: true),

        new("View Departments", FSHAction.View, FSHResource.Departments, IsBasic: true),
        new("Search Departments", FSHAction.Search, FSHResource.Departments, IsBasic: true),
        new("Create Departments", FSHAction.Create, FSHResource.Departments),
        new("Update Departments", FSHAction.Update, FSHResource.Departments),
        new("Delete Departments", FSHAction.Delete, FSHResource.Departments),
        new("Generate Departments", FSHAction.Generate, FSHResource.Departments),
        new("Clean Departments", FSHAction.Clean, FSHResource.Departments),
        new("View Floors", FSHAction.View, FSHResource.Floors, IsBasic: true),
        new("Search Floors", FSHAction.Search, FSHResource.Floors, IsBasic: true),
        new("Create Floors", FSHAction.Create, FSHResource.Floors),
        new("Update Floors", FSHAction.Update, FSHResource.Floors),
        new("Delete Floors", FSHAction.Delete, FSHResource.Floors),
        new("Generate Floors", FSHAction.Generate, FSHResource.Floors),
        new("Clean Floors", FSHAction.Clean, FSHResource.Floors),
        new("View Rooms", FSHAction.View, FSHResource.Rooms, IsBasic: true),
        new("Search Rooms", FSHAction.Search, FSHResource.Rooms, IsBasic: true),
        new("Create Rooms", FSHAction.Create, FSHResource.Rooms),
        new("Update Rooms", FSHAction.Update, FSHResource.Rooms),
        new("Delete Rooms", FSHAction.Delete, FSHResource.Rooms),
        new("Generate Rooms", FSHAction.Generate, FSHResource.Rooms),
        new("Clean Rooms", FSHAction.Clean, FSHResource.Rooms),
        new("View Employees", FSHAction.View, FSHResource.Employees, IsBasic: true),
        new("Search Employees", FSHAction.Search, FSHResource.Employees, IsBasic: true),
        new("Create Employees", FSHAction.Create, FSHResource.Employees),
        new("Update Employees", FSHAction.Update, FSHResource.Employees),
        new("Delete Employees", FSHAction.Delete, FSHResource.Employees),
        new("Generate Employees", FSHAction.Generate, FSHResource.Employees),
        new("Clean Employees", FSHAction.Clean, FSHResource.Employees)
    };

    public static IReadOnlyList<FSHPermission> All { get; } = new ReadOnlyCollection<FSHPermission>(_all);
    public static IReadOnlyList<FSHPermission> Root { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => p.IsRoot).ToArray());
    public static IReadOnlyList<FSHPermission> Admin { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => !p.IsRoot).ToArray());
    public static IReadOnlyList<FSHPermission> Basic { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => p.IsBasic).ToArray());
}

public record FSHPermission(string Description, string Action, string Resource, bool IsBasic = false, bool IsRoot = false)
{
    public string Name => NameFor(Action, Resource);
    public static string NameFor(string action, string resource) => $"Permissions.{resource}.{action}";
}
