using Dissonance.Config;
using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NoiseSuppression.Patches;

public class PlayerControllerInputPatch
{
    private const float SuppressionStepPercentage = 0.10f;

    public static string ToggleSuppressionKey;
    public static string EnableSuppressionKey;
    public static string DisableSuppressionKey;
    public static string DecreaseSuppressionKey;
    public static string IncreaseSuppressionKey;

    private static bool _isEnabled = false;
    private static float _wetAudioMix = 0.0f;

    // ReSharper disable once InconsistentNaming
    [HarmonyPatch(typeof(PlayerControllerB), "Update"), HarmonyPostfix]
    private static void UpdateHandleKeyPresses(PlayerControllerB __instance)
    {
        if (!__instance.isPlayerControlled || !__instance.IsOwner)
        {
            return;
        }

        if (Keyboard.current[ToggleSuppressionKey].IsPressed())
        {
            SetSuppressionState(!_isEnabled);
            return;
        }

        if (Keyboard.current[EnableSuppressionKey].IsPressed())
        {
            SetSuppressionState(true);
            return;
        }

        if (Keyboard.current[DisableSuppressionKey].IsPressed())
        {
            SetSuppressionState(false);
            return;
        }

        if (Keyboard.current[IncreaseSuppressionKey].IsPressed())
        {
            AdjustWetMix(SuppressionStepPercentage);
            return;
        }

        if (Keyboard.current[DecreaseSuppressionKey].IsPressed())
        {
            AdjustWetMix(-SuppressionStepPercentage);
            return;
        }
    }

    private static void SetSuppressionState(bool state)
    {
        _isEnabled = state;

        // FIXME: this call persists into the game's preferences, so this NEEDS to be reset on shutdown
        // else removing the mod puts the game into an unintended state
        VoiceSettings.Instance.BackgroundSoundRemovalEnabled = _isEnabled;
    }

    private static void AdjustWetMix(float delta) => _wetAudioMix = Mathf.Clamp(_wetAudioMix + delta, 0, 1);
}
