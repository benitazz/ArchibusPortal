using System.Data.Entity.ModelConfiguration;

namespace DurandalAuth.Domain.Model.Mapping
{
    public class emMap: EntityTypeConfiguration<em>
    {
        public emMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.em_number)
                .IsFixedLength()
                .HasMaxLength(12);

            this.Property(t => t.em_photo)
                .IsFixedLength()
                .HasMaxLength(64);

            this.Property(t => t.em_std)
                .IsFixedLength()
                .HasMaxLength(16);

            this.Property(t => t.em_title)
                .HasMaxLength(64);

            this.Property(t => t.email)
                .HasMaxLength(50);

            this.Property(t => t.emergency_contact)
                .IsFixedLength()
                .HasMaxLength(64);

            this.Property(t => t.emergency_phone)
                .IsFixedLength()
                .HasMaxLength(24);

            this.Property(t => t.emergency_relation)
                .IsFixedLength()
                .HasMaxLength(32);

            this.Property(t => t.extension)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.fax)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.fl_id)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.honorific)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.image_file)
                .IsFixedLength()
                .HasMaxLength(64);

            this.Property(t => t.layer_name)
                .IsFixedLength()
                .HasMaxLength(32);

            this.Property(t => t.mailstop)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.name_first)
                .IsFixedLength()
                .HasMaxLength(32);

            this.Property(t => t.name_last)
                .IsFixedLength()
                .HasMaxLength(32);

            this.Property(t => t.net_id)
                .IsFixedLength()
                .HasMaxLength(12);

            this.Property(t => t.net_user_name)
                .IsFixedLength()
                .HasMaxLength(16);

            this.Property(t => t.option1)
                .IsFixedLength()
                .HasMaxLength(16);

            this.Property(t => t.option2)
                .IsFixedLength()
                .HasMaxLength(16);

            this.Property(t => t.pager_number)
                .IsFixedLength()
                .HasMaxLength(24);

            this.Property(t => t.phone)
                .IsFixedLength()
                .HasMaxLength(24);

            this.Property(t => t.phone_home)
                .IsFixedLength()
                .HasMaxLength(24);

            this.Property(t => t.recovery_status)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(12);

            this.Property(t => t.rf_id)
                .IsFixedLength()
                .HasMaxLength(64);

            this.Property(t => t.rm_id)
                .IsFixedLength()
                .HasMaxLength(8);

            this.Property(t => t.status)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.tc_level)
                .IsFixedLength()
                .HasMaxLength(16);

            this.Property(t => t.bl_id)
                .IsFixedLength()
                .HasMaxLength(8);

            this.Property(t => t.calling_card_number)
                .IsFixedLength()
                .HasMaxLength(24);

            this.Property(t => t.cellular_number)
                .IsFixedLength()
                .HasMaxLength(24);

            this.Property(t => t.comments)
                .HasMaxLength(500);

            this.Property(t => t.contingency_bl_id)
                .IsFixedLength()
                .HasMaxLength(8);

            this.Property(t => t.contingency_email)
                .HasMaxLength(50);

            this.Property(t => t.contingency_fax)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.contingency_fl_id)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.contingency_phone)
                .IsFixedLength()
                .HasMaxLength(24);

            this.Property(t => t.contingency_rm_id)
                .IsFixedLength()
                .HasMaxLength(8);

            this.Property(t => t.curr_bl_id)
                .IsFixedLength()
                .HasMaxLength(8);

            this.Property(t => t.curr_fl_id)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.curr_rm_id)
                .IsFixedLength()
                .HasMaxLength(8);

            this.Property(t => t.curr_site_id)
                .IsFixedLength()
                .HasMaxLength(16);

            this.Property(t => t.dp_id)
                .IsFixedLength()
                .HasMaxLength(16);

            this.Property(t => t.dv_id)
                .IsFixedLength()
                .HasMaxLength(16);

            this.Property(t => t.dwgname)
                .HasMaxLength(128);

            this.Property(t => t.ehandle)
                .HasMaxLength(64);

            this.Property(t => t.Id)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(35);

            // Table & Column Mappings
            this.ToTable("em", "afm");
            this.Property(t => t.em_number).HasColumnName("em_number");
            this.Property(t => t.em_photo).HasColumnName("em_photo");
            this.Property(t => t.em_std).HasColumnName("em_std");
            this.Property(t => t.em_title).HasColumnName("em_title");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.emergency_contact).HasColumnName("emergency_contact");
            this.Property(t => t.emergency_phone).HasColumnName("emergency_phone");
            this.Property(t => t.emergency_relation).HasColumnName("emergency_relation");
            this.Property(t => t.extension).HasColumnName("extension");
            this.Property(t => t.fax).HasColumnName("fax");
            this.Property(t => t.fl_id).HasColumnName("fl_id");
            this.Property(t => t.geo_objectid).HasColumnName("geo_objectid");
            this.Property(t => t.honorific).HasColumnName("honorific");
            this.Property(t => t.image_file).HasColumnName("image_file");
            this.Property(t => t.lat).HasColumnName("lat");
            this.Property(t => t.layer_name).HasColumnName("layer_name");
            this.Property(t => t.lon).HasColumnName("lon");
            this.Property(t => t.mailstop).HasColumnName("mailstop");
            this.Property(t => t.name_first).HasColumnName("name_first");
            this.Property(t => t.name_last).HasColumnName("name_last");
            this.Property(t => t.net_id).HasColumnName("net_id");
            this.Property(t => t.net_user_name).HasColumnName("net_user_name");
            this.Property(t => t.option1).HasColumnName("option1");
            this.Property(t => t.option2).HasColumnName("option2");
            this.Property(t => t.pager_number).HasColumnName("pager_number");
            this.Property(t => t.pct_rm).HasColumnName("pct_rm");
            this.Property(t => t.phone).HasColumnName("phone");
            this.Property(t => t.phone_home).HasColumnName("phone_home");
            this.Property(t => t.recovery_status).HasColumnName("recovery_status");
            this.Property(t => t.rf_id).HasColumnName("rf_id");
            this.Property(t => t.rm_id).HasColumnName("rm_id");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.tc_level).HasColumnName("tc_level");
            this.Property(t => t.area_chargable).HasColumnName("area_chargable");
            this.Property(t => t.area_comn).HasColumnName("area_comn");
            this.Property(t => t.area_comn_nocup).HasColumnName("area_comn_nocup");
            this.Property(t => t.area_comn_ocup).HasColumnName("area_comn_ocup");
            this.Property(t => t.area_comn_rm).HasColumnName("area_comn_rm");
            this.Property(t => t.area_comn_serv).HasColumnName("area_comn_serv");
            this.Property(t => t.area_rm).HasColumnName("area_rm");
            this.Property(t => t.bl_id).HasColumnName("bl_id");
            this.Property(t => t.calling_card_number).HasColumnName("calling_card_number");
            this.Property(t => t.cellular_number).HasColumnName("cellular_number");
            this.Property(t => t.comments).HasColumnName("comments");
            this.Property(t => t.contingency_bl_id).HasColumnName("contingency_bl_id");
            this.Property(t => t.contingency_email).HasColumnName("contingency_email");
            this.Property(t => t.contingency_fac_at).HasColumnName("contingency_fac_at");
            this.Property(t => t.contingency_fax).HasColumnName("contingency_fax");
            this.Property(t => t.contingency_fl_id).HasColumnName("contingency_fl_id");
            this.Property(t => t.contingency_phone).HasColumnName("contingency_phone");
            this.Property(t => t.contingency_rm_id).HasColumnName("contingency_rm_id");
            this.Property(t => t.cost).HasColumnName("cost");
            this.Property(t => t.curr_bl_id).HasColumnName("curr_bl_id");
            this.Property(t => t.curr_fl_id).HasColumnName("curr_fl_id");
            this.Property(t => t.curr_rm_id).HasColumnName("curr_rm_id");
            this.Property(t => t.curr_site_id).HasColumnName("curr_site_id");
            this.Property(t => t.date_hired).HasColumnName("date_hired");
            this.Property(t => t.dp_id).HasColumnName("dp_id");
            this.Property(t => t.dv_id).HasColumnName("dv_id");
            this.Property(t => t.dwgname).HasColumnName("dwgname");
            this.Property(t => t.ehandle).HasColumnName("ehandle");
            this.Property(t => t.Id).HasColumnName("em_id");

            // Relationships
            /*this.HasOptional(t => t.afm_tclevel)
                .WithMany(t => t.ems)
                .HasForeignKey(d => d.tc_level);
            this.HasOptional(t => t.bl)
                .WithMany(t => t.ems)
                .HasForeignKey(d => d.bl_id);
            this.HasOptional(t => t.bl1)
                .WithMany(t => t.ems1)
                .HasForeignKey(d => d.contingency_bl_id);
            this.HasOptional(t => t.dp)
                .WithMany(t => t.ems)
                .HasForeignKey(d => new { d.dv_id, d.dp_id });
            this.HasOptional(t => t.dv)
                .WithMany(t => t.ems)
                .HasForeignKey(d => d.dv_id);
            this.HasOptional(t => t.fl)
                .WithMany(t => t.ems)
                .HasForeignKey(d => new { d.contingency_bl_id, d.contingency_fl_id });
            this.HasOptional(t => t.rm)
                .WithMany(t => t.ems)
                .HasForeignKey(d => new { d.contingency_bl_id, d.contingency_fl_id, d.contingency_rm_id });
            this.HasOptional(t => t.fl1)
                .WithMany(t => t.ems1)
                .HasForeignKey(d => new { d.curr_bl_id, d.curr_fl_id });
            this.HasOptional(t => t.rm1)
                .WithMany(t => t.ems1)
                .HasForeignKey(d => new { d.curr_bl_id, d.curr_fl_id, d.curr_rm_id });
            this.HasOptional(t => t.emstd)
                .WithMany(t => t.ems)
                .HasForeignKey(d => d.em_std);
            this.HasOptional(t => t.fl2)
                .WithMany(t => t.ems2)
                .HasForeignKey(d => new { d.bl_id, d.fl_id });
            this.HasOptional(t => t.net)
                .WithMany(t => t.ems)
                .HasForeignKey(d => d.net_id);
            this.HasOptional(t => t.rm2)
                .WithMany(t => t.ems2)
                .HasForeignKey(d => new { d.bl_id, d.fl_id, d.rm_id });*/

        }
         
    }
}