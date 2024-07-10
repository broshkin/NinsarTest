using UnityEngine;

public static class ReadingFile
{
    public static string[] split_content;


    public static void ReadFile()
    {
        TextAsset path = Resources.Load<TextAsset>("nums");
        string content = path.text;

        split_content = content.Split('\n');
    }
}
