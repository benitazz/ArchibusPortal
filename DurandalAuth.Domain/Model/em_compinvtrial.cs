#region

using DurandalAuth.Domain.Model;

#endregion

namespace testHomeServer.Models
{
    public class em_compinvtrial
    {
        public string difference { get; set; }

        public string dwgnames { get; set; }

        public string em_id { get; set; }

        public string inv_bl_id { get; set; }

        public string inv_fl_id { get; set; }

        public string inv_rm_id { get; set; }

        public string layers { get; set; }

        public int? mo_id { get; set; }

        public string trial_bl_id { get; set; }

        public string trial_fl_id { get; set; }

        public string trial_project_id { get; set; }

        public string trial_rm_id { get; set; }

        public int auto_number { get; set; }

        public virtual bl bl { get; set; }

        public virtual bl bl1 { get; set; }

        public virtual em em { get; set; }

        public virtual fl fl { get; set; }

        public virtual rm rm { get; set; }

        public virtual fl fl1 { get; set; }

        public virtual rm rm1 { get; set; }
    }
}