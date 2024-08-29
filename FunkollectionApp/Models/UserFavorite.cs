namespace FunkollectionApp.Models
{
    public class UserFavorite
    {
        public int Id { get; set; }
        public string UserId { get; set; }  // Foreign key to the user
        public int PopId { get; set; }       // Foreign key to the Pop

        public virtual Pop Pop { get; set; }
    }
}
