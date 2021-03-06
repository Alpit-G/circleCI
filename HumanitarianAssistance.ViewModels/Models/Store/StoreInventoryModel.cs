﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanitarianAssistance.ViewModels.Models.Store
{
    public class StoreInventoryModel : BaseModel
    {
        public string InventoryId { get; set; }
        public string InventoryCode { get; set; }
        public string InventoryName { get; set; }
        public string InventoryDescription { get; set; }
        public int AssetType { get; set; }
		public long InventoryDebitAccount { get; set; }
		public long? InventoryCreditAccount { get; set; }
	}

}
