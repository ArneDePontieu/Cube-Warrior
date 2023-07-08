public interface ILevelable
{
    float CurrentExperience { get; set; }
    float CurrentLevel { get; set; }

    public void GiveExperience(float amount)
    {
        CurrentExperience += amount;
    }
}