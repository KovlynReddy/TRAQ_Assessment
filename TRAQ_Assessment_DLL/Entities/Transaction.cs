using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAQ_Assessment_DLL.Entities;

public class Transaction : BaseEntity
{
    public int Account_Code { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime Transaction_Date { get; set; }
    public DateTime Capture_Date { get; set; }
}
