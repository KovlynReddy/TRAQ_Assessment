using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAQ_Assessment_DLL.Entities;

public class BaseEntity
{
    [Key]
    public int Code { get; set; }
}
