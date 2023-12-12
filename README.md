# Noise Suppression (for Lethal Company)

Sick of hearing your friends' mouth noises when you're being chased by a bracken? \
Would you rather not listen to your mate's TikToks while he's "watching the monitors" back at the ship? (yes, I'm talking about you Eugene 👿)

Listen no more with the NoiseSuppression mod!

As it turns out, the underlying audio engine has support for RNNoise noise suppression, so this mod simply turns it on.

## Compatability

This has been tested with the following Lethal Company versions, but it'll most likely work with future versions unless the backend audio engine changes.

 - v40
 - v45

## How to use

You don't need to do anything special: simply having this mod enabled will ensure that

## Installation

Same as every other project

- Thunderstore
- Manual

## Contributing

If you find an issue, or you see an issue you want to help with, please feel free to contribute!
I may be a .NET developer, but Unity's engine code is an unknown to me so who knows if I'm doing stuff correctly :D

You'll need to copy the following DLLs out of your game directory (`Lethal Company/Lethal Company_Data/Managed`) into the `/lib` directory of this solution

 - `Assembly-CSharp.dll`
 - `DissonanceVoip.dll`
 - `Unity.InputSystem.dll`
 - `Unity.Netcode.Runtime.dll`
 - `UnityEngine.dll`

## License

This project is licensed under the MIT license, see [LICENSE.txt](./LICENSE.txt) for more information
