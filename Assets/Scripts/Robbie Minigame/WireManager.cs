using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireManager : MonoBehaviour
{
    public List<Color> wireColors = new List<Color>();
    public List<Wire> startWires = new List<Wire>();
    public List<Wire> endWires = new List<Wire>();

    private List<Color> availColors;
    private List<int> availStartWireIndex;
    private List<int> availEndWireIndex;

    public Wire currentWire;
    public Wire hoveredWire;

    public bool isTaskComplete = false;

    public GameObject door;
    public GameObject panel;

    private void Start()
    {
        availColors = new List<Color>(wireColors);
        availStartWireIndex = new List<int>();
        availEndWireIndex = new List<int>();

        for(int i = 0; i < startWires.Count; i++)
        {
            availStartWireIndex.Add(i);
        }
        for (int i = 0; i < endWires.Count; i++)
        {
            availEndWireIndex.Add(i);
        }

        while(availColors.Count > 0 && availStartWireIndex.Count > 0 && availEndWireIndex.Count > 0)
        {
            Color randColor = availColors[Random.Range(0, availColors.Count)];
            int randStartIndex = Random.Range(0, availStartWireIndex.Count);
            int randEndIndex = Random.Range(0,availEndWireIndex.Count);

            startWires[availStartWireIndex[randStartIndex]].SetColor(randColor);
            endWires[availEndWireIndex[randEndIndex]].SetColor(randColor);
            availColors.Remove(randColor);
            availStartWireIndex.RemoveAt(randStartIndex);
            availEndWireIndex.RemoveAt(randEndIndex);
        }

        StartCoroutine(checkWires());
    }

    IEnumerator checkWires()
    {
        while(!isTaskComplete)
        {
            int matchedWires = 0;
            for (int i = 0; i < startWires.Count; i++)
            {
                if (startWires[i].matched)
                {
                    matchedWires++;
                }
            }

            if (matchedWires >= startWires.Count)
            {
                door.SetActive(false);
                panel.SetActive(false);
                isTaskComplete = true;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
