namespace Comunidades.ApiService.Models.Requests
{
    public class CommunityCreatePostRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid CreatorUid { get; set; }

        public void Sanitize()
        {
            Name = Name?.Trim();
            Description = Description?.Trim();
        }
    }
}
