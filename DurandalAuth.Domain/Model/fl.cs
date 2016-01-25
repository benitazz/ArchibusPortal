using System.ComponentModel.DataAnnotations;

namespace DurandalAuth.Domain.Model
{
    public class fl
    {
        public decimal area_allocated { get; set; }

        public decimal area_em_dp { get; set; }

        public decimal area_ext_wall { get; set; }

        public decimal area_fl_comn_gp { get; set; }

        public decimal area_fl_comn_nocup { get; set; }

        public decimal area_fl_comn_ocup { get; set; }

        public decimal area_fl_comn_rm { get; set; }

        public decimal area_fl_comn_serv { get; set; }

        public decimal area_gp { get; set; }

        public decimal area_gp_comn { get; set; }

        public decimal area_gp_dp { get; set; }

        public decimal area_gross_ext { get; set; }

        public decimal area_gross_int { get; set; }

        public decimal area_manual { get; set; }

        public decimal area_nocup { get; set; }

        public decimal area_nocup_comn { get; set; }

        public decimal area_nocup_dp { get; set; }

        public decimal area_ocup { get; set; }

        public decimal area_ocup_comn { get; set; }

        public decimal area_ocup_dp { get; set; }

        public decimal area_remain { get; set; }

        public decimal area_rentable { get; set; }

        public decimal area_rm { get; set; }

        public decimal area_rm_comn { get; set; }

        public decimal area_rm_dp { get; set; }

        public decimal area_serv { get; set; }

        public decimal area_su { get; set; }

        public decimal area_usable { get; set; }

        public decimal area_vert_pen { get; set; }

        public decimal height_nom { get; set; }

        public string image_file { get; set; }

        public string name { get; set; }

        public string option1 { get; set; }

        public string option2 { get; set; }

        public string prorate_remain { get; set; }

        public decimal ratio_ru { get; set; }

        public decimal ratio_ur { get; set; }

        public decimal std_area_per_em { get; set; }

        public decimal cost_sqft { get; set; }

        public decimal count_em { get; set; }

        public string detail_dwg { get; set; }

        public string dwgname { get; set; }

        public string ehandle { get; set; }

        public decimal elevation_nom { get; set; }

        public string bl_id { get; set; }

        [Key]
        public string fl_id { get; set; }
    }
}