using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class TimeCard : Card
{
    [Range(1, 24)]
    public int hour = 1;
    
    [Range(0, 59)]
    public int minute = 1;

    public string englishText;
}
