using System;
using System.Collections.Generic;
using System.Text;

namespace Stackoverflow.Model
{
    class UserOperationClaim:BaseEntity
    {
       
         public int UserId { get; set; }
         public int OperationClaimId{ get; set; }
    }
}
