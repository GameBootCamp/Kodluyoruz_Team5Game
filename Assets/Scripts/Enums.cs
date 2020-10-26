using System;
namespace Game
{
    public enum SceneType
    {
        START_SCENE,
        LEVEL_SCENE,
        GAMEOVER_SCENE
    }

    public enum PlatformSizeChangeType
    {
        NONE,
        WIDTH_CHANGE,
        LENGTH_CHANGE,
        DEPTH_CHANGE,
        UNIFORM_CHANGE
    }

    public enum PlatformMovingDirection
    {
        NONE,
        HORIZONTAL,
        VERTICAL,
        Z_AXIS
    }

}
