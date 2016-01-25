#region

using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

#endregion

namespace DurandalAuth.Domain.Model
{
    public class em
    {
        [DataMember]
        public string em_number { get; set; }

        [DataMember]
        public string em_photo { get; set; }

        [DataMember]
        public string em_std { get; set; }

        [DataMember]
        public string em_title { get; set; }

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string emergency_contact { get; set; }

        [DataMember]
        public string emergency_phone { get; set; }

        [DataMember]
        public string emergency_relation { get; set; }

        [DataMember]
        public string extension { get; set; }

        [DataMember]
        public string fax { get; set; }

        [DataMember]
        public string fl_id { get; set; }

        [DataMember]
        public int? geo_objectid { get; set; }

        [DataMember]
        public string honorific { get; set; }

        [DataMember]
        public string image_file { get; set; }

        [DataMember]
        public decimal? lat { get; set; }

        [DataMember]
        public string layer_name { get; set; }

        [DataMember]
        public decimal? lon { get; set; }

        [DataMember]
        public string mailstop { get; set; }

        [DataMember]
        public string name_first { get; set; }

        [DataMember]
        public string name_last { get; set; }

        [DataMember]
        public string net_id { get; set; }

        [DataMember]
        public string net_user_name { get; set; }

        [DataMember]
        public string option1 { get; set; }

        [DataMember]
        public string option2 { get; set; }

        [DataMember]
        public string pager_number { get; set; }

        [DataMember]
        public decimal pct_rm { get; set; }

        [DataMember]
        public string phone { get; set; }

        [DataMember]
        public string phone_home { get; set; }

        [DataMember]
        public string recovery_status { get; set; }

        [DataMember]
        public string rf_id { get; set; }

        [DataMember]
        public string rm_id { get; set; }

        [DataMember]
        public string status { get; set; }

        [DataMember]
        public string tc_level { get; set; }

        [DataMember]
        public decimal area_chargable { get; set; }

        [DataMember]
        public decimal area_comn { get; set; }

        [DataMember]
        public decimal area_comn_nocup { get; set; }

        [DataMember]
        public decimal area_comn_ocup { get; set; }

        [DataMember]
        public decimal area_comn_rm { get; set; }

        [DataMember]
        public decimal area_comn_serv { get; set; }

        [DataMember]
        public decimal area_rm { get; set; }

        [DataMember]
        public string bl_id { get; set; }

        [DataMember]
        public string calling_card_number { get; set; }

        [DataMember]
        public string cellular_number { get; set; }

        [DataMember]
        public string comments { get; set; }

        [DataMember]
        public string contingency_bl_id { get; set; }

        [DataMember]
        public string contingency_email { get; set; }

        [DataMember]
        public short contingency_fac_at { get; set; }

        [DataMember]
        public string contingency_fax { get; set; }

        [DataMember]
        public string contingency_fl_id { get; set; }

        [DataMember]
        public string contingency_phone { get; set; }

        [DataMember]
        public string contingency_rm_id { get; set; }

        [DataMember]
        public decimal cost { get; set; }

        [DataMember]
        public string curr_bl_id { get; set; }

        [DataMember]
        public string curr_fl_id { get; set; }

        [DataMember]
        public string curr_rm_id { get; set; }

        [DataMember]
        public string curr_site_id { get; set; }

        [DataMember]
        public DateTime? date_hired { get; set; }

        [DataMember]
        public string dp_id { get; set; }

        [DataMember]
        public string dv_id { get; set; }

        [DataMember]
        public string dwgname { get; set; }

        [DataMember]
        public string ehandle { get; set; }

        [DataMember]
        [Key]
        public string Id { get; set; }
    }
}