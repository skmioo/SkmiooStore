using System;
using UnityEngine;

/// <summary>
/// 图像选项控制类
/// </summary>
public static class ImageController
{
    public enum WindowMode {
        /// <summary>
        /// 全屏
        /// </summary>
        FullScreen,
        /// <summary>
        /// 窗口最大化
        /// </summary>
        WindowMaximize,
        /// <summary>
        /// 窗口模式
        /// </summary>
        Window }
    public enum Resolution { _1280x720, _1366x768, _1600x900, _1920x1080, _2560x1440, _3840x2160 }

    private static WindowMode windowMode;
    private static Resolution resolution;
    private static int windowWidth;
    private static int windowHeight;
    private static bool is16_9Screen;

    static ImageController() //暂时使用静态构造函数为其指定初始值
    {
        windowMode = WindowMode.Window;
        TryUseScreenResolution();
    }

    /// <summary>
    /// 设置全屏/窗口最大化/窗口模式，该方法会改变当前游戏窗口
    /// </summary>
    /// <param name="windowMode">窗口模式</param>
    public static void SetWindowMode(WindowMode _windowMode)
    {
        windowMode = _windowMode;
        if (windowMode == WindowMode.WindowMaximize || windowMode == WindowMode.FullScreen)
        {
            TryUseScreenResolution();
        }
        else
        {
            ChangeWindow();
        }
    }

    /// <summary>
    /// 设置分辨率，该方法会改变当前游戏窗口
    /// </summary>
    /// <param name="_resolution">分辨率</param>
    public static void SetResolution(Resolution _resolution)
    {
        resolution = _resolution;
        switch(_resolution)
        {
            case Resolution._1280x720:
                windowWidth = 1280;
                windowHeight = 720;
                break;
            case Resolution._1366x768:
                windowWidth = 1366;
                windowHeight = 768;
                break;
            case Resolution._1600x900:
                windowWidth = 1600;
                windowHeight = 900;
                break;
            case Resolution._1920x1080:
                windowWidth = 1920;
                windowHeight = 1080;
                break;
            case Resolution._2560x1440:
                windowWidth = 2560;
                windowHeight = 1440;
                break;
            case Resolution._3840x2160:
                windowWidth = 3840;
                windowHeight = 2160;
                break;
        }
        ChangeWindow();
    }

    public static WindowMode GetWindowMode()
    {
        return windowMode;
    }

    public static Resolution GetResolution()
    {
        return resolution;
    }

    public static bool GetIs16_9Screen()
    {
        return is16_9Screen;
    }

    //获取屏幕分辩率，如果为16:9则使用，否则使用1280x720；同时为resolution windowWidth windowHeight is16_9Screen赋值
    private static void TryUseScreenResolution()
    {
        UnityEngine.Resolution[] resolutions = Screen.resolutions;
        windowWidth = resolutions[resolutions.Length - 1].width;
        windowHeight = resolutions[resolutions.Length - 1].height;
        is16_9Screen = true;
        string str = "_" + windowWidth.ToString() + "x" + windowHeight.ToString();
        try
        {
            resolution = (Resolution)Enum.Parse(typeof(Resolution), str, true);
        }
        catch (ArgumentException)
        {
            windowMode = WindowMode.Window;
            SetResolution(Resolution._1280x720);
            is16_9Screen = false;
        }
        finally
        {
            ChangeWindow();
        }
    }

    private static void ChangeWindow()
    {
        Screen.SetResolution(windowWidth, windowHeight, windowMode == WindowMode.FullScreen? true: false);
    }
}