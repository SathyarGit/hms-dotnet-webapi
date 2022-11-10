using FSH.WebApi.Domain.Catalog;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace FSH.WebApi.Domain.HMS;

public class Purchase : AuditableEntity, IAggregateRoot
{ 
    public DateTime? PurchaseDate { get; private set; }
    public DefaultIdType? VendorId { get; private set; }
    public int? Amount { get; private set; }
    public string? Description{ get; private set; }
    public DefaultIdType? DepartmentId { get; private set; }
    public string? BillsOrInvoiceNumber { get; private set; }
    public string? ImagePath { get; private set; }
    public DefaultIdType? TransactionstatusId { get; private set; }

    public virtual Vendor Vendor { get; set; } = default!;
    public virtual Department Department { get; set; } = default!;
    public virtual Transactionstatus Transactionstatus { get; set; } = default!;
    public virtual ICollection<Accountentry> Accountentries { get; set; }

    public Purchase(DateTime? purchaseDate, DefaultIdType? vendorId, int? amount, string? description, DefaultIdType? departmentId, string? billsOrInvoiceNumber, string imagePath, DefaultIdType? transactionstatusId)
    {
        PurchaseDate = purchaseDate;
        VendorId = vendorId;
        Amount = amount;
        Description = description;
        DepartmentId = departmentId;
        BillsOrInvoiceNumber = billsOrInvoiceNumber;
        ImagePath = imagePath;
        TransactionstatusId = transactionstatusId;

        Accountentries = new HashSet<Accountentry>();

    }

    public Purchase Update(DateTime? purchaseDate, DefaultIdType? vendorId, int? amount, string? description, DefaultIdType? departmentId, string? billsOrInvoiceNumber, string imagePath, DefaultIdType? transactionstatusId)
    {
        if (purchaseDate.HasValue && PurchaseDate != purchaseDate) PurchaseDate = purchaseDate.Value;
        if (vendorId.HasValue && vendorId.Value != Guid.Empty && !VendorId.Equals(vendorId.Value)) VendorId = vendorId.Value;
        if (amount.HasValue && Amount!= amount) Amount = amount.Value;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (departmentId.HasValue && departmentId.Value != Guid.Empty && !DepartmentId.Equals(departmentId.Value)) DepartmentId = departmentId.Value;
        if (billsOrInvoiceNumber is not null && BillsOrInvoiceNumber?.Equals(billsOrInvoiceNumber) is not true) BillsOrInvoiceNumber = billsOrInvoiceNumber;
        if (imagePath is not null && ImagePath?.Equals(imagePath) is not true) ImagePath = imagePath;
        if (transactionstatusId.HasValue && transactionstatusId.Value != Guid.Empty && !TransactionstatusId.Equals(transactionstatusId.Value)) TransactionstatusId = transactionstatusId.Value;
        return this;
    }
}