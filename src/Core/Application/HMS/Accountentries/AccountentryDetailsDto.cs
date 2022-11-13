using FSH.WebApi.Application.HMS.Departments;
using FSH.WebApi.Application.HMS.Expensecategories;
using FSH.WebApi.Application.HMS.Folios;
using FSH.WebApi.Application.HMS.Paymentmodes;
using FSH.WebApi.Application.HMS.Purchases;
using FSH.WebApi.Application.HMS.Transactionstatuses;
using FSH.WebApi.Application.HMS.Transactiontypes;
using FSH.WebApi.Application.HMS.Travelagents;

namespace FSH.WebApi.Application.HMS.Accountentries;

public class AccountentryDetailsDto : IDto
{
    public DefaultIdType Id { get; set; }
    public DateTime? TransactionDate { get; set; }
    public int? Amount { get; set; }
    public string? Description { get; set; }

    public FolioDto Folio { get; set; } = default!;
    public PurchaseDto Purchase { get; set; } = default!;
    public PaymentmodeDto Paymentmode { get; set; } = default!;
    public DepartmentDto Department { get; set; } = default!;
    public ExpensecategoryDto Expensecategory { get; set; } = default!;
    public TransactiontypeDto Transactiontype { get; set; } = default!;
 }