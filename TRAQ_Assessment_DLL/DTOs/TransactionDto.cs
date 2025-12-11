using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAQ_Assessment_DLL.DTOs;

public class TransactionDto
{
    public int Code { get; set; }
    public int Account_Code { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime Transaction_Date { get; set; }
    public DateTime Capture_Date { get; set; }
}
