﻿using static System.Net.Mime.MediaTypeNames;
using System;
using euroma2.Models.Promo;

namespace euroma2.Models.Events
{
    public class Mall_Event
    {
        public int id { get; set; }

        public Date_Range dateRange { get; set; }

        public string image { get; set; }

        public string title { get; set; }

        public string description { get; set; }
        public string youtubeLink { get; set; }

        public List<LineaInterest_event> interestIds { get; set; }

    }

    public class LineaInterest_event { 
        public int id { get; set; }
        public int id_event { get; set; }
        public int id_interest { get; set; }
    }


    public class Mall_EventCMS
    {

        public Mall_EventCMS() { }
        public Mall_EventCMS(Mall_Event p)
        {
            this.id = p.id;
            this.image = p.image;
            this.dateRange = p.dateRange;
            this.title = p.title;
            this.description = p.description;
            this.interestIds = p.interestIds;
            this.youtubeLink = p.youtubeLink;
        }

        public int id { get; set; }

        public Date_Range dateRange { get; set; }

        public string image { get; set; }

        public string title { get; set; }
        public string? title_it { get; set; }

        public string description { get; set; }
        public string? description_it { get; set; }
        public string youtubeLink { get; set; }

        public List<LineaInterest_event> interestIds { get; set; }

    }

    public class Mall_Event_it
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }

        public Mall_Event mall_event { get; set; }
    }

    public class EventView
    {

        public EventView() { }

        public EventView(Mall_Event p)
        {
            this.id = p.id;
            this.dateRange = p.dateRange;
            this.image = p.image;
            this.title = p.title;
            this.description = p.description;
            this.youtubeLink = p.youtubeLink;
        }

        public int id { get; set; }

        public Date_Range dateRange { get; set; }

        public string image { get; set; }

        public string title { get; set; }

        public string description { get; set; }
        public string youtubeLink { get; set; }

        public List<int> interestIds { get; set; }
    }

}
