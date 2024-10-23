using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColoringManager : MonoBehaviour
{
    [SerializeField] List<Color> lists = new List<Color>();
    [SerializeField] Color[] colors;
    [SerializeField] int listCount = 10;

    public List<Color> Lists
    {
        get { return lists; }
    }

    public void FillColors()
    {
        colors = new Color[]
        {
            new Color(1, 0, 0),
            new Color(0, 1, 0),
            new Color(0, 0, 1),
            new Color(1, 1, 0),
            new Color(0, 1, 1)
        };
    }

    public void CreateColorList()
    {
        for (int i = 0; i < listCount; i++)
        {
            lists.Add(colors[i % (listCount / 2)]);
        }
    }

    public void Shuffle()
    {
        for (int i = lists.Count - 1; i > 0; i--)
        {
            int random = Random.Range(0, i);

            Color temp = lists[random];
            lists[random] = lists[i];
            lists[i] = temp;
        }
    }
}