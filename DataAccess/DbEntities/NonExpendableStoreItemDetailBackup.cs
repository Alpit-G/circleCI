﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.DbEntities
{
    public partial class NonExpendableStoreItemDetailBackup : BaseEntityWithoutId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "serial")]
        public int StoreItemID { get; set; }
        [StringLength(20)]
        public string StoreItemCode { get; set; }
        [StringLength(10)]
        public string MasterCode { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(10)]
        public string OfficeCode { get; set; }
        [StringLength(10)]
        public string BLine { get; set; }
        [StringLength(10)]
        public string Area { get; set; }
        [StringLength(10)]
        public string Sector { get; set; }
        [StringLength(10)]
        public string CostBook { get; set; }
        [StringLength(10)]
        public string Project { get; set; }
        [StringLength(10)]
        public string Program { get; set; }
        [StringLength(10)]
        public string Job { get; set; }
        [StringLength(20)]
        public string VoucherNo { get; set; }
        public DateTime? VoucherDate { get; set; }
        [StringLength(50)]
        public string PurchaseOrderNo { get; set; }
        public DateTime? PurchaseOrderDate { get; set; }
        [StringLength(50)]
        public string ModelType { get; set; }
        [StringLength(50)]
        public string Maker { get; set; }
        [StringLength(50)]
        public string EngineNo { get; set; }
        [StringLength(50)]
        public string IdentificationNo { get; set; }
        [StringLength(50)]
        public string ChasisNo { get; set; }
        [StringLength(50)]
        public string RegistrationNo { get; set; }
        [StringLength(50)]
        public string InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        [StringLength(20)]
        public string AssetType { get; set; }
        [StringLength(20)]
        public string Unit { get; set; }
        public float? Quantity { get; set; }
        [StringLength(10)]
        public string CurrencyCode { get; set; }
        public float? Price { get; set; }
        [StringLength(100)]
        public string ReceiptVoucherNo { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public long? ReceiptFromEmployeeID { get; set; }
        [StringLength(10)]
        public string ReceiptFromLocation { get; set; }
        [StringLength(50)]
        public string DepreciationMethod { get; set; }
        public float? DepreciationRate { get; set; }
        [StringLength(20)]
        public string PurchaseYear { get; set; }
        [StringLength(100)]
        public string IssueVoucherNo { get; set; }
        public DateTime? IssuedDate { get; set; }
        public long? IssuedToEmployeeID { get; set; }
        [StringLength(10)]
        public string IssuedToLocation { get; set; }
        [StringLength(30)]
        public string ReceivedType { get; set; }
        [StringLength(30)]
        public string Status { get; set; }
        public string Remarks { get; set; }
        public DateTime? DepreciationPurchaseDate { get; set; }
    }
}
