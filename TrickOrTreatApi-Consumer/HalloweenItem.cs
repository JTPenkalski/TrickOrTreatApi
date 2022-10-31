using System.Text.Json.Serialization;

namespace TrickOrTreatApi.Models
{
    public class HalloweenItem
    {
        public enum Type
        {
            Trick,
            Treat
        }

        [JsonPropertyName("count")] public int Count { get; init; }
        [JsonPropertyName("candyName")] public string? CandyName { get; init; }
        [JsonPropertyName("imageUrl")] public string ImageUrl { get; init; }
        [JsonPropertyName("itemType")] public Type ItemType { get; init; }

        public HalloweenItem(Type itemType, string? candyName, string imageUrl, int count = 1)
        {
            Count = itemType == Type.Trick ? 0 : Math.Max(1, count);
            CandyName = candyName;
            ImageUrl = imageUrl;
            ItemType = itemType;
        }

        public override string ToString()
        {
            return $"[{ItemType}], Count = {Count}, Candy Name = {CandyName}, URL = {ImageUrl}";
        }
    }
}