using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events.tac.local.Models
{
    public class EventIntro
    {
        public HtmlString ContentHeading { get; set; }
        public HtmlString ContentIntro { get; set; }
        public HtmlString ContentBody { get; set; }
        public HtmlString EventImage { get; set; }
        public HtmlString Highlights { get; set; }
        public HtmlString StartDate { get; set; }
        public HtmlString Duration { get; set; }
        public HtmlString DifficultyLevel { get; set; }

    }
}