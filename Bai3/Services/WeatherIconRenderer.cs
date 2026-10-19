using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Bai3.Models;

namespace Bai3.Services;

public static class WeatherIconRenderer
{
    public static Image CreateWeatherIcon(WeatherCategory category, int width = 100, int height = 80)
    {
        var bmp = new Bitmap(width, height);
        using var g = Graphics.FromImage(bmp);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.Clear(Color.Transparent);

        switch (category)
        {
            case WeatherCategory.Clear:
                DrawSun(g, width, height);
                break;
            case WeatherCategory.Cloudy:
                DrawCloudy(g, width, height);
                break;
            case WeatherCategory.Fog:
                DrawFog(g, width, height);
                break;
            case WeatherCategory.Rain:
                DrawRain(g, width, height);
                break;
            case WeatherCategory.Thunderstorm:
                DrawThunderstorm(g, width, height);
                break;
            default:
                DrawCloudy(g, width, height);
                break;
        }

        return bmp;
    }

    private static GraphicsPath CreateCloudPath(float x, float y, float w, float h)
    {
        var path = new GraphicsPath();
        float r1 = h * 0.45f;
        float r2 = h * 0.65f;
        float r3 = h * 0.45f;

        // Bottom horizontal base
        path.AddLine(x + r1 * 0.5f, y + h, x + w - r3 * 0.5f, y + h);
        // Right puff
        path.AddArc(x + w - r3, y + h - r3, r3, r3, 90, -180);
        // Center-top large puff
        path.AddArc(x + w * 0.28f, y + h * 0.15f, r2, r2, 0, -180);
        // Left puff
        path.AddArc(x, y + h - r1, r1, r1, -90, -180);
        path.CloseFigure();
        return path;
    }

    private static void DrawSun(Graphics g, int w, int h)
    {
        float cx = w / 2f;
        float cy = h / 2f;
        float radius = Math.Min(w, h) * 0.26f;

        // Sun glow/rays
        using var rayPen = new Pen(Color.FromArgb(245, 166, 35), 3.5f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
        for (int i = 0; i < 8; i++)
        {
            double angle = i * Math.PI / 4;
            float x1 = cx + (float)(Math.Cos(angle) * (radius + 5));
            float y1 = cy + (float)(Math.Sin(angle) * (radius + 5));
            float x2 = cx + (float)(Math.Cos(angle) * (radius + 14));
            float y2 = cy + (float)(Math.Sin(angle) * (radius + 14));
            g.DrawLine(rayPen, x1, y1, x2, y2);
        }

        // Sun body
        using var brush = new SolidBrush(Color.FromArgb(255, 193, 7));
        g.FillEllipse(brush, cx - radius, cy - radius, radius * 2, radius * 2);

        using var strokePen = new Pen(Color.FromArgb(245, 124, 0), 2.5f);
        g.DrawEllipse(strokePen, cx - radius, cy - radius, radius * 2, radius * 2);
    }

    private static void DrawCloudy(Graphics g, int w, int h)
    {
        // Sun peeking behind
        using var sunBrush = new SolidBrush(Color.FromArgb(255, 193, 7));
        g.FillEllipse(sunBrush, w * 0.45f, h * 0.12f, w * 0.35f, h * 0.42f);

        // Fluffy cloud in front
        using var cloudPath = CreateCloudPath(w * 0.1f, h * 0.25f, w * 0.75f, h * 0.55f);
        using var cloudBrush = new SolidBrush(Color.FromArgb(240, 244, 248));
        using var cloudPen = new Pen(Color.FromArgb(69, 90, 100), 3.5f) { LineJoin = LineJoin.Round };
        g.FillPath(cloudBrush, cloudPath);
        g.DrawPath(cloudPen, cloudPath);
    }

    private static void DrawFog(Graphics g, int w, int h)
    {
        using var pen = new Pen(Color.FromArgb(120, 144, 156), 4f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
        g.DrawLine(pen, w * 0.15f, h * 0.25f, w * 0.85f, h * 0.25f);
        g.DrawLine(pen, w * 0.25f, h * 0.45f, w * 0.75f, h * 0.45f);
        g.DrawLine(pen, w * 0.12f, h * 0.65f, w * 0.88f, h * 0.65f);
        g.DrawLine(pen, w * 0.3f, h * 0.85f, w * 0.7f, h * 0.85f);
    }

    private static void DrawRain(Graphics g, int w, int h)
    {
        // Cloud outline matching screenshot
        using var cloudPath = CreateCloudPath(w * 0.12f, h * 0.08f, w * 0.76f, h * 0.52f);
        using var cloudPen = new Pen(Color.FromArgb(33, 33, 33), 4.5f) { LineJoin = LineJoin.Round };
        g.DrawPath(cloudPen, cloudPath);

        // Raindrops falling slanting
        using var rainPen = new Pen(Color.FromArgb(33, 33, 33), 3.5f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
        // 4 slanting raindrops matching the mock image
        float[][] drops = new float[][]
        {
            new float[] { w * 0.28f, h * 0.68f, w * 0.22f, h * 0.88f },
            new float[] { w * 0.44f, h * 0.68f, w * 0.38f, h * 0.88f },
            new float[] { w * 0.60f, h * 0.68f, w * 0.54f, h * 0.88f },
            new float[] { w * 0.74f, h * 0.68f, w * 0.68f, h * 0.88f }
        };

        foreach (var d in drops)
        {
            g.DrawLine(rainPen, d[0], d[1], d[2], d[3]);
        }
    }

    private static void DrawThunderstorm(Graphics g, int w, int h)
    {
        // Dark cloud
        using var cloudPath = CreateCloudPath(w * 0.12f, h * 0.08f, w * 0.76f, h * 0.5f);
        using var cloudBrush = new SolidBrush(Color.FromArgb(55, 71, 79));
        using var cloudPen = new Pen(Color.FromArgb(38, 50, 56), 4f) { LineJoin = LineJoin.Round };
        g.FillPath(cloudBrush, cloudPath);
        g.DrawPath(cloudPen, cloudPath);

        // Lightning bolt
        var boltPoints = new PointF[]
        {
            new PointF(w * 0.52f, h * 0.55f),
            new PointF(w * 0.42f, h * 0.72f),
            new PointF(w * 0.50f, h * 0.72f),
            new PointF(w * 0.38f, h * 0.95f),
            new PointF(w * 0.58f, h * 0.68f),
            new PointF(w * 0.48f, h * 0.68f),
            new PointF(w * 0.56f, h * 0.55f)
        };
        using var boltBrush = new SolidBrush(Color.FromArgb(255, 214, 0));
        using var boltPen = new Pen(Color.FromArgb(255, 171, 0), 1.5f);
        g.FillPolygon(boltBrush, boltPoints);
        g.DrawPolygon(boltPen, boltPoints);
    }
}
