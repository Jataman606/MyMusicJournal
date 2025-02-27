namespace Domain.Types;

public struct Rating(int score)
{
    private int Score { get; set; } = score;
    
    public static implicit operator int(Rating rating) => rating.Score;
    public static implicit operator Rating(int score) => new Rating(score);
}