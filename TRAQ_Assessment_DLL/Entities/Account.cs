using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAQ_Assessment_DLL.Entities;

public class Account : BaseEntity
{
    public int Person_Code { get; set; }
    public string Account_Number { get; set; }
    public decimal Outstanding_Balance { get; set; }
}
