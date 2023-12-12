# Changelog

## 1.0.1

Summary: Fixed key inputs not working as they should

- Fixed holding keys causing actions to repeat (used BepInEx's input system wrapper instead of `Input.current[keyCode]`)

## 1.0.0

Summary: Initial code dump, with the most basic functionality

- Enable/disable/toggle suppression using the keys PageUp/PageDown/0
- Increase/decrease the noise suppression applied to the audio source using the keys 8/9

Caveats:
- Keys can't be rebound via the UI, but can be changed in the mod's config file (see [jupjohn/LethalCompany-NoiseSuppression#1](https://github.com/jupjohn/LethalCompany-NoiseSuppression/issues/1))
- If you're using the toggle key, or adjusting the mix, there's no indication of those states (see [jupjohn/LethalCompany-NoiseSuppression#2](https://github.com/jupjohn/LethalCompany-NoiseSuppression/issues/2))
- When uninstalling the mod, your last set noise suppression state will be kept. Make sure you disable noise suppression in-game before uninstalling (see [jupjohn/LethalCompany-NoiseSuppression#3](https://github.com/jupjohn/LethalCompany-NoiseSuppression/issues/3))
