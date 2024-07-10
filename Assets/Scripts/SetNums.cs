using UnityEngine;

public class SetNums : MonoBehaviour
{
    private Vector2 centerNum;
    private Vector2 currentNum;

    private string[] txt;
    private int num;
    private int cubesCount;

    public GameObject[] cubes;


    private void Start()
    {
        cubesCount = cubes.Length;

        ReadingFile.ReadFile();
        txt = ReadingFile.split_content;

        SetRandomSpawn();
        SetColor();
    }

    private void SetColor()
    {
        for (int i = 0; i < cubesCount; i++)
        {
            GetCurrentPos(i);

            num = txt[((int)currentNum.x + ((txt[0].Length - 1) * Mathf.Abs((int)currentNum.x))) % (txt[0].Length - 1)][((int)currentNum.y + (txt.Length * Mathf.Abs((int)currentNum.y))) % txt.Length] - 48;

            SetColorOnCube(num, cubes[i]);
        }
    }

    private void SetRandomSpawn()
    {
        centerNum = new Vector2(Random.Range(0, txt[0].Length - 2), Random.Range(0, txt.Length - 1));
    }

    private void GetCurrentPos(int i)
    {
        switch (i)
        {
            case 0:
                currentNum = centerNum - new Vector2(-1, 1);
                break;
            case 1:
                currentNum = centerNum - new Vector2(-1, 0);
                break;
            case 2:
                currentNum = centerNum - new Vector2(-1, -1);
                break;
            case 3:
                currentNum = centerNum - new Vector2(0, 1);
                break;
            case 4:
                currentNum = centerNum - new Vector2(0, 0);
                break;
            case 5:
                currentNum = centerNum - new Vector2(0, -1);
                break;
            case 6:
                currentNum = centerNum - new Vector2(1, 1);
                break;
            case 7:
                currentNum = centerNum - new Vector2(1, 0);
                break;
            case 8:
                currentNum = centerNum - new Vector2(1, -1);
                break;
        }
    }

    private void SetColorOnCube(int num, GameObject cube)
    {
        switch (num)
        {
            case 1:
                cube.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 2:
                cube.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case 3:
                cube.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 4:
                cube.GetComponent<Renderer>().material.color = Color.magenta;
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            centerNum += new Vector2(1, 0);
            SetColor();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            centerNum += new Vector2(0, -1);
            SetColor();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            centerNum += new Vector2(-1, 0);
            SetColor();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            centerNum += new Vector2(0, 1);
            SetColor();
        }
    }
}
