#region

using System;
using System.ComponentModel.DataAnnotations;

#endregion

namespace DurandalAuth.Domain.Model
{
    public class rm
    {
        public decimal area { get; set; }

        public decimal area_alloc { get; set; }

        public decimal area_chargable { get; set; }

        public decimal area_comn { get; set; }

        public decimal area_comn_nocup { get; set; }

        public decimal area_comn_ocup { get; set; }

        public decimal area_comn_rm { get; set; }

        public decimal area_comn_serv { get; set; }

        public decimal area_manual { get; set; }

        public decimal area_unalloc { get; set; }

        public short cap_em { get; set; }

        public decimal cost { get; set; }

        public decimal cost_sqft { get; set; }

        public decimal count_em { get; set; }

        public DateTime? date_last_surveyed { get; set; }

        public string dp_id { get; set; }

        public string dv_id { get; set; }

        public string dwgname { get; set; }

        public string ehandle { get; set; }

        public string extension { get; set; }

        public int? geo_objectid { get; set; }

        public short hotelable { get; set; }

        public decimal? lat { get; set; }

        public string layer_name { get; set; }

        public decimal length { get; set; }

        public decimal? lon { get; set; }

        public string ls_id { get; set; }

        public string name { get; set; }

        public string option1 { get; set; }

        public string option2 { get; set; }

        public string org_id { get; set; }

        public string phone { get; set; }

        public string prorate { get; set; }

        public string recovery_status { get; set; }

        public short reservable { get; set; }

        public string rm_cat { get; set; }

        public string rm_std { get; set; }

        public string rm_type { get; set; }

        public string rm_use { get; set; }

        public string survey_comments_rm { get; set; }

        public string survey_photo { get; set; }

        public string survey_redline_rm { get; set; }

        public string tc_level { get; set; }

        public string transfer_status { get; set; }

        public string bl_id { get; set; }

        public string fl_id { get; set; }

        [Key]
        public string rm_id { get; set; }

        public virtual bl bl { get; set; }
    }
}