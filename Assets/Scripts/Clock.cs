using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Clock : MonoBehaviour
{
    public float lerpSpeed = 12;
    
    [Range(1, 24)]
    public int hour = 1;
    [Range(0, 59)]
    public int minute = 30;

    [Space] 
    public ClockHand hourHand;
    public ClockHand minuteHand;

    void OnEnable()
    {
        hourHand.RandomizeRotation();
        minuteHand.RandomizeRotation();
    }

    // Update is called once per frame
    void Update()
    {
        hourHand.UpdateHand(lerpSpeed);
        minuteHand.UpdateHand(lerpSpeed);
    }


    [Button]
    public void ApplyTime()
    {
        minuteHand.setAngle = 360 - (minute * 6);
        hourHand.setAngle = 360 - (hour * 30);
    }

    [System.Serializable]
    public class ClockHand
    {
        public GameObject hand;
        
        [HorizontalGroup("angles", Title = "angle (current / set)")]
        [Tooltip("The angle of the hand at this exact frame. May differ from setAngle when lerping to it."), HideLabel]
        public float currentAngle;
        
        [HorizontalGroup("angles")]
        [Tooltip("The angle associated with the time this hand is set to."), HideLabel]
        public float setAngle;

        public void RandomizeRotation() 
        {
            if (!hand) return;
            float randomEuler = Random.Range(300, 900);
            currentAngle = randomEuler;
            hand.transform.localEulerAngles = new Vector3(0, 0, randomEuler);
        }
        
        public void UpdateHand(float lerpSpeed)
        {
            if (!hand) return;
            currentAngle =  Mathf.Lerp(currentAngle, setAngle, Time.deltaTime * lerpSpeed);
            hand.transform.localEulerAngles = new Vector3(0, 0, currentAngle);
        }
    }
}
