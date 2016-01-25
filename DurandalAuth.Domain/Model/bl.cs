#region

using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

#endregion

namespace DurandalAuth.Domain.Model
{
    public class bl
    {
        [DataMember]
        public string ac_id { get; set; }

        [DataMember]
        public string address1 { get; set; }

        [DataMember]
        public string address2 { get; set; }

        [DataMember]
        public decimal area_avg_em { get; set; }

        [DataMember]
        public decimal area_avg_floor { get; set; }

        [DataMember]
        public decimal area_bl_comn_gp { get; set; }

        [DataMember]
        public decimal area_bl_comn_nocup { get; set; }

        [DataMember]
        public decimal area_bl_comn_ocup { get; set; }

        [DataMember]
        public decimal area_bl_comn_rm { get; set; }

        [DataMember]
        public decimal area_bl_comn_serv { get; set; }

        [DataMember]
        public decimal area_em_dp { get; set; }

        [DataMember]
        public decimal area_ext_wall { get; set; }

        [DataMember]
        public decimal area_gp { get; set; }

        [DataMember]
        public decimal area_gp_comn { get; set; }

        [DataMember]
        public decimal area_gp_dp { get; set; }

        [DataMember]
        public decimal area_gross_ext { get; set; }

        [DataMember]
        public decimal area_gross_int { get; set; }

        [DataMember]
        public decimal area_ls_negotiated { get; set; }

        [DataMember]
        public decimal area_nocup { get; set; }

        [DataMember]
        public decimal area_nocup_comn { get; set; }

        [DataMember]
        public decimal area_nocup_dp { get; set; }

        [DataMember]
        public decimal area_ocup { get; set; }

        [DataMember]
        public decimal area_ocup_comn { get; set; }

        [DataMember]
        public decimal area_ocup_dp { get; set; }

        [DataMember]
        public decimal area_remain { get; set; }

        [DataMember]
        public decimal area_rentable { get; set; }

        [DataMember]
        public decimal area_rm { get; set; }

        [DataMember]
        public decimal area_rm_comn { get; set; }

        [DataMember]
        public decimal area_rm_dp { get; set; }

        [DataMember]
        public decimal area_serv { get; set; }

        [DataMember]
        public decimal area_su { get; set; }

        [DataMember]
        public decimal area_usable { get; set; }

        [DataMember]
        public decimal area_vert_pen { get; set; }

        [DataMember]
        public short auto_est_balance_points { get; set; }

        [DataMember]
        public string bldg_photo { get; set; }

        [DataMember]
        public string campus { get; set; }

        [DataMember]
        public string campus_id { get; set; }

        [DataMember]
        public string city_id { get; set; }

        [DataMember]
        public string comments { get; set; }

        [DataMember]
        public string construction_type { get; set; }

        [DataMember]
        public string contact_name { get; set; }

        [DataMember]
        public string contact_phone { get; set; }

        [DataMember]
        public decimal cooling_balance_point { get; set; }

        [DataMember]
        public decimal cooling_balance_point_manual { get; set; }

        [DataMember]
        public decimal cost_operating_total { get; set; }

        [DataMember]
        public decimal cost_other_total { get; set; }

        [DataMember]
        public decimal cost_sqft { get; set; }

        [DataMember]
        public decimal cost_tax_total { get; set; }

        [DataMember]
        public decimal cost_utility_total { get; set; }

        [DataMember]
        public decimal count_em { get; set; }

        [DataMember]
        public int count_fl { get; set; }

        [DataMember]
        public int count_max_occup { get; set; }

        [DataMember]
        public int count_occup { get; set; }

        [DataMember]
        public string ctry_id { get; set; }

        [DataMember]
        public DateTime? date_bl { get; set; }

        [DataMember]
        public DateTime? date_book_val { get; set; }

        [DataMember]
        public DateTime? date_costs_end { get; set; }

        [DataMember]
        public DateTime? date_costs_last_calcd { get; set; }

        [DataMember]
        public DateTime? date_costs_start { get; set; }

        [DataMember]
        public DateTime? date_market_val { get; set; }

        [DataMember]
        public DateTime? date_rehab { get; set; }

        [DataMember]
        public string detail_dwg { get; set; }

        [DataMember]
        public string dwgname { get; set; }

        [DataMember]
        public string ehandle { get; set; }

        [DataMember]
        public string energy_baseline_year { get; set; }

        [DataMember]
        public int? geo_objectid { get; set; }

        [DataMember]
        public string grp_uid { get; set; }

        [DataMember]
        public decimal heating_balance_point { get; set; }

        [DataMember]
        public decimal heating_balance_point_manual { get; set; }

        [DataMember]
        public string image_file { get; set; }

        [DataMember]
        public decimal income_total { get; set; }

        [DataMember]
        public decimal? lat { get; set; }

        [DataMember]
        public decimal? lon { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string option1 { get; set; }

        [DataMember]
        public string option2 { get; set; }

        [DataMember]
        public string pr_id { get; set; }

        [DataMember]
        public decimal ratio_ru { get; set; }

        [DataMember]
        public decimal ratio_ur { get; set; }

        [DataMember]
        public string regn_id { get; set; }

        [DataMember]
        public string site_id { get; set; }

        [DataMember]
        public string state_id { get; set; }

        [DataMember]
        public decimal std_area_per_em { get; set; }

        [DataMember]
        public string use1 { get; set; }

        [DataMember]
        public string utility_type_cool { get; set; }

        [DataMember]
        public string utility_type_heat { get; set; }

        [DataMember]
        public decimal value_book { get; set; }

        [DataMember]
        public decimal value_market { get; set; }

        [DataMember]
        public string weather_source_id { get; set; }

        [DataMember]
        public string weather_station_id { get; set; }

        [DataMember]
        public string zip { get; set; }

        [Key]
        [DataMember]
        public string bl_id { get; set; }
    }
}