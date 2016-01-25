#region

using DurandalAuth.Data.Common;
using DurandalAuth.Domain.Model;

#endregion

namespace DurandalAuth.Web.Extensions
{
    public static class AuditInfoExtension
    {
        public static void SetAuditDetails(this AuditInfoComplete auditInfoComplete)
        {
            if (auditInfoComplete == null)
            {
                return;
            }

            auditInfoComplete.CreatedBy = SystemAdminData.Username;
            auditInfoComplete.CreatedDate = SystemAdminData.CreationDateTime;
            auditInfoComplete.UpdatedBy = SystemAdminData.Username;
            auditInfoComplete.UpdatedDate = SystemAdminData.CreationDateTime;
        }
    }
}