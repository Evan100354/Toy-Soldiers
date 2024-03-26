public interface IBurnable
{
    bool isBurning { get; set; }
    void Burn();

    void Spread();
}