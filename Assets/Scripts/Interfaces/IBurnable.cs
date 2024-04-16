public interface IBurnable
{
    bool isBurning { get; set; }

    bool isCatchingFire { get; set; }

    void Burn();
    void CatchFire(bool guaranteedToCatchFire);
}