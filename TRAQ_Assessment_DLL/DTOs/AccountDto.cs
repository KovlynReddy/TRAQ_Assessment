using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAQ_Assessment_DLL.DTOs;

public class AccountDto
{    public int Code { get; set; }
    public int Person_Code { get; set; }
    public string Account_Number { get; set; }
    public decimal Outstanding_Balance { get; set; }
    public DateOnly OpenDateTime { get; set; }
}
