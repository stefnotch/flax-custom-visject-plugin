using Flax.Build;

public class VisjectPluginEditorTarget : GameProjectEditorTarget
{
    /// <inheritdoc />
    public override void Init()
    {
        base.Init();

        // Reference the modules for editor
        Modules.Add("VisjectPlugin");
        Modules.Add("VisjectPluginEditor");
    }
}
