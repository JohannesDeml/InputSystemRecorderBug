# Input System + Recording = no Input

Starting the [Unity Recorder](https://docs.unity3d.com/Packages/com.unity.recorder@2.1/manual/index.html) in Play Mode results to no more input being passed from the Input System since preview 4

[Issue #1070](https://github.com/Unity-Technologies/InputSystem/issues/1070)

## Reproduce

1. Download this project
2. Open Unity Scene `Scenes/ReproInputSystemRecorderBug` and start playmode
3. Use arrow keys to move cube left and right
4. Open Recorder window (Stay in Play Mode) and load recording list from ScriptableObjects
5. Start Recording
6. Try to give input and notice, that the block does not move anymore

### Expected Result
Block should move in recording mode (which happens in preview 3)

### Actual Result

Block does not move while recording is active

## Tech

* Unity 2019.3.1f1
* Input System preview.5 -1.0.0
* Unity Recorder preview.1 - 2.1.0
* Windows 10 with keyboard input
