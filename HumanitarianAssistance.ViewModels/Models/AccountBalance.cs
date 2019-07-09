using System;
using System.Collections.Generic;
using System.Text;
namespace HumanitarianAssistance.ViewModels.Models
{
    
    public class NoteAccountBalances
    {
        public int NoteId { get; set; }
        public string NoteName { get; set; }
        public int NoteHeadId { get; set; }
        public string NoteHeadName { get; set; }
        public List<AccountBalance> AccountBalances { get; set; }
    }

    public class AccountBalance
    {
        public long AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }
        public string AccountCode { get; set; }
    }
}
