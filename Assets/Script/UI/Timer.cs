using System;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;

    private Stopwatch clock;

    // Start is called before the first frame update
    void Start()
    {
        clock = Stopwatch.StartNew();
        clock.Start();
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan ts = clock.Elapsed;
        textMeshProUGUI.text = ts.ToString("mm\\:ss\\.ff");
    }
}
