using System;
using UnityEngine;

public class HPGUI : MonoBehaviour
{
    [SerializeField]
    private int _healthBarWidth;
    [SerializeField]
    private int _healthBarHeight;
    [SerializeField]
    [Range(0,100)]
    private int _healthAmount;
    [SerializeField]
    private Color _healthTextColor;
    [SerializeField]
    private Color _healthBarBackGroundColor;

    private void OnGUI()
    {
        DrawBackGroundHealthBarBox();
        DrawHealthBarBox();
        DrawHealthAmountBox();
    }

    private void DrawHealthAmountBox()
    {
        DrawQuad(new Rect(FindScreenWidthCenter(), FindScreenHeightBottom(), _healthBarWidth, _healthBarHeight), new Color(0f, 0f, 0f, 0.0f), _healthTextColor, GetHealthBarCaption());
    }

    private void DrawHealthBarBox()
    {
        DrawQuad(new Rect(FindScreenWidthCenter(), FindScreenHeightBottom(), getFillHelthBarWidth(), _healthBarHeight), ScrollsGUI.HealthBarColor);
    }

    private void DrawBackGroundHealthBarBox()
    {
        DrawQuad(new Rect(FindScreenWidthCenter(), FindScreenHeightBottom(), _healthBarWidth, _healthBarHeight), _healthBarBackGroundColor);
    }

    private float FindScreenHeightBottom()
    {
        return Screen.height - (_healthBarHeight + 20);
    }

    private float FindScreenWidthCenter()
    {
        return Screen.width / 2 - _healthBarWidth / 2;
    }

    private int getFillHelthBarWidth()
    {
        return _healthBarWidth*_healthAmount/100;
    }

    private void DrawQuad(Rect position, Color color)
    {
        DrawQuad(position, color, Color.black);
    }

    private void DrawQuad(Rect position, Color color,Color fontColor)
    {
        DrawQuad(position, color, fontColor, string.Empty);
    }

    private void DrawQuad(Rect position, Color color, Color fontColor,string content)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, color);
        texture.Apply();
        GUI.skin.box.normal.background = texture;
        GUI.skin.box.normal.textColor = fontColor;
        GUI.Box(position, content);
    }

    private string GetHealthBarCaption()
    {
        return $"{_healthAmount}/100";
    }
}
