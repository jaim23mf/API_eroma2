﻿using euroma2.Models.Events;
using euroma2.Models.Hours;
using euroma2.Models.Interest;
using euroma2.Models.Map;
using euroma2.Models.Promo;
using euroma2.Models.Reach;
using euroma2.Models.Service;
using euroma2.Models.Users;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using euroma2.Models.Blog_model;
using euroma2.Models.Firebase;

namespace euroma2.Models
{
    public class DataContext: DbContext
    {

        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("ConnectionString");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Shop> shop { get; set; } = null!;
        public DbSet<Shop_it> shop_it { get; set; } = null!;



        public DbSet<ShopCategory> shopCategory { get; set; } = null!;

        public DbSet<ShopCategory_it> shopCategory_it { get; set; } = null!;

        public DbSet<ShopSubCategory> shopSubCategory { get; set; } = null!;
        public DbSet<ShopSubCategory_it> shopSubCategory_it { get; set; } = null!;
        public DbSet<Mall_Event> events { get; set; } = null!;
        public DbSet<Mall_Event_it> events_it { get; set; } = null!;
        public DbSet<Opening> opening_hours { get; set; } = null!;
        public DbSet<General> opening_general { get; set; } = null!;
        public DbSet<Exception_Rules> opening_exceptions { get; set; } = null!;
        public DbSet<Interest_model> interests { get; set; } = null!;
        public DbSet<Interest_model_it> interests_it { get; set; } = null!;
        public DbSet<Promotion> promotion { get; set; } = null!;
        public DbSet<Promotion_it> promotion_it { get; set; } = null!;
        public DbSet<Reach_Us> reach { get; set; } = null!;
        public DbSet<Reach_Us_it> reach_it { get; set; } = null!;

        public DbSet<Service_model> service { get; set; } = null!;
        public DbSet<Service_model_it> service_it { get; set; } = null!;
        public DbSet<FloorInfo> floor_info { get; set; } = null!;
        public DbSet<FloorInfo_it> floor_info_it { get; set; } = null!;
        public DbSet<FloorNavPoint> floor_navpoint { get; set; }
        public DbSet<FloorNavPointRelation> floor_navpoint_relation { get; set; }
        public DbSet<FloorShop> floor_shop { get; set; }

        public DbSet<LineaInterest_shop> liShop { get; set; } = null!;
        public DbSet<LineaInterest_promo> liPromo { get; set; } = null!;
        public DbSet<LineaInterest_event> liEvents { get; set; } = null!;
        public DbSet<oDay> oDay { get; set; } = null!;
        public DbSet<Date_Range> dRange { get; set; } = null!;
        public DbSet<User> user { get; set; } = null!;
        //public DbSet<Map_Map> map { get; set; } = null!;
        //public DbSet<Map_Shop> map_shop { get; set; } = null!;
        //public DbSet<Map_Graph_Node> map_graph_node { get; set; } = null!;
        //public DbSet<Map_Graph_Node_Relations> map_graph_node_relations { get; set; } = null;

        public DbSet<Blog> blog { get; set; } = null!;
        public DbSet<Blog_it> blog_it { get; set; } = null!;

        public DbSet<Firebase_model> fire { get; set; } = null!;


    }
}
