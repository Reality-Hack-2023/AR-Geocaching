# REPO-031 [HARDWARE] AR Geocaching

## Team Members:
- Stuart Aldrich
- Thomas Manoka
- Andrew Li
- Kai Zhang
- Erika Zhou

## Description
Geocaching and Hot-Cold game with Augmented Reality passthrough!

## How To Use
1. Upload Arduino code to ESP-32 microcontroller
2. It needs to have a power supply and be turned on
3. Sideload the application to the Meta Quest 2 headset. It must run in standalone mode.
4. Pair Meta Quest 2 headset with ESP-32 over Bluetooth
5. Start application in headset
6. Connect to device with UI in application.
7. The meter indicates how close (hot) or far (cold) the user is from the ESP-32. Also, the sonar ping changes volume and pitch. (This is based off of Bluetooth RSSI (Received Signal Strength Indicator).)

## Technologies Used
- Unity 3D
- Oculus Integration SDK
- XR Interaction Toolkit
- Arduino C++
- C# scripting
- ESP-32 microcontroller
- AR passthrough

## References
- Hardware Hack - MIT Reality Hack 2023 [https://mitrealityhack.notion.site/Hardware-Hack-cea762eb43344eda849dec1067666775](https://mitrealityhack.notion.site/Hardware-Hack-cea762eb43344eda849dec1067666775)
- The Singularity, package by VRatMIT for integrating custom microcontroller VR hardware with Unity project [https://github.com/VRatMIT/TheSingularity-Unity](https://github.com/VRatMIT/TheSingularity-Unity)
- "Passthrough | Unity VR Tutorial for Oculus Quest" by RealaryVR [https://youtu.be/RtoTGYBdGI4](https://youtu.be/RtoTGYBdGI4)
- Sonar audio ping modified from "radar sound effect" by sounds fx [https://www.youtube.com/watch?v=_YFXdDppLw0](https://www.youtube.com/watch?v=_YFXdDppLw0)
- "How to use esp_bt_gap_read_rssi_delta function to get bluetooth classic RSSI from ESP32?" - Stack Overflow [https://stackoverflow.com/questions/52572703/how-to-use-esp-bt-gap-read-rssi-delta-function-to-get-bluetooth-classic-rssi-fro](https://stackoverflow.com/questions/52572703/how-to-use-esp-bt-gap-read-rssi-delta-function-to-get-bluetooth-classic-rssi-fro)
