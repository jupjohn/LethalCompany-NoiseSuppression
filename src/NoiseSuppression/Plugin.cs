using BepInEx;
using HarmonyLib;
using NoiseSuppression.Patches;

namespace NoiseSuppression;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private Harmony _harmony;

    private void Awake()
    {
        // TODO: reset profile on shutdown to prevent uninstalling mod keeping suppression active
        // PlayerPrefs.SetInt("Dissonance_Audio_BgDenoise_Enabled", 0);
        // PlayerPrefs.SetFloat("Dissonance_Audio_BgDenoise_Amount", 0);

        var toggleSuppressionKey = Config.Bind("Suppression", "ToggleKey", "0", "Toggle noise suppression");
        var enableSuppressionKey = Config.Bind("Suppression", "EnableKey", "PageUp", "Enable noise suppression");
        var disableSuppressionKey = Config.Bind("Suppression", "DisableKey", "PageDown", "Disable noise suppression");
        var decreaseSuppressionKey = Config.Bind("Suppression", "DecreaseKey", "8", "Decrease noise suppression");
        var increaseSuppressionKey = Config.Bind("Suppression", "IncreaseKey", "9", "Increase noise suppression");

        PlayerControllerInputPatch.ToggleSuppressionKey = toggleSuppressionKey.Value;
        PlayerControllerInputPatch.EnableSuppressionKey = enableSuppressionKey.Value;
        PlayerControllerInputPatch.DisableSuppressionKey = disableSuppressionKey.Value;
        PlayerControllerInputPatch.DecreaseSuppressionKey = decreaseSuppressionKey.Value;
        PlayerControllerInputPatch.IncreaseSuppressionKey = increaseSuppressionKey.Value;

        _harmony = new Harmony(PluginInfo.PLUGIN_NAME);
        _harmony.PatchAll(typeof(PlayerControllerInputPatch));
    }
}
