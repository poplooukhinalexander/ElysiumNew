namespace Elysium.Model
{
    public class Tour
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string ShortDescription { get; set; } = default!;
        public string DetailedDescription { get; set; } = default!;
        public virtual List<Category> Categories { get; set; } = new List<Category>();
        public RouteDifficulty? Difficulty { get; set; } = RouteDifficulty.Medium;
        public string? RouteDifficultyDescription { get; set; }
        public virtual List<Language> Languages { get; set; } = new List<Language>();
        public Guid DirectionId { get; set; }     
        public virtual Location Direction { get; set; } = default!;
        public Guid MeetPointId { get; set; }
        public virtual Location MeetPoint { get; set; } = default!;     
        public Guid ProviderId { get; set; }
        public virtual Provider Provider { get; set; } = default!;
        public virtual List<Ride> Rides { get; set; } = new List<Ride>();
        public virtual List<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
        public bool VisaMandatory { get; set; } = false;
        public string? VisaDetails { get; set;}
        public string TransferDetails { get; set; } = default!;       
        public string MainPhotoLink { get; set; } = default!;
        public string MainPhotoTitle { get; set; } = default!;

        /// <summary>
        /// Популярность тура.
        /// </summary>
        public int Popularity { get; set; } = 0;    

        /// <summary>
        /// Отзывы пользователей.
        /// </summary>
        public int Rate { get; set; } = 0;

        /// <summary>
        /// Кол-во отзывов.
        /// </summary>
        public int FeedbackCount { get; set; } = 0;
        public int? MinAge { get; set; }
        public string ParticipateTerms { get; set; } = default!;
        public virtual List<ScheduleItem> ScheduleItems { get; set; } = new List<ScheduleItem>();
        public DateOnly? ArchivedAt { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
