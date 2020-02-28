public class FeatureToggle : IFeatureToggle
{
    private readonly bool isProd;
    public FeatureToggle(bool isProd)
    {
        this.isProd = isProd;
    }
    public bool shouldRun()
    {
        return isProd ? true : false;
    }
}