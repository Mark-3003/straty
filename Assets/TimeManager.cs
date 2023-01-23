using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private int startingYear;
    [SerializeField] private int speed;
    [SerializeField] bool updateSettings;

    [Header("Debug")]
    [SerializeField] private int time;
    [SerializeField] private float timeTimer;
    private float speedMultiplier;
    private int years, month, days, hours;
    private string[] monthsList;

    // Start is called before the first frame update
    void Start()
    {
        convertSpeedToMultiplier();
        monthsList = new string[12];
        FillArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (updateSettings)
        {
            convertSpeedToMultiplier();
            updateSettings = false;
        }

        timeTimer += Time.deltaTime * speedMultiplier;
        if(timeTimer >= 1)
        {
            timeTimer -= 1;
            time += 1;
        }

        ConvertTimeToInts(time);
        timeText.text = "Y:" + (startingYear + years).ToString() + " M:" + monthsList[month] + " D:" + days.ToString() + "[" + hours + ":00]";
    }
    public void convertSpeedToMultiplier()
    {
        if(speed == 1)
        {
            speedMultiplier = 1;
        }
        else if(speed == 2)
        {
            speedMultiplier = 6;
        }
        else if(speed == 3)
        {
            speedMultiplier = 12;
        }
        else if(speed == 4)
        {
            speedMultiplier = 24;
        }
        else if(speed == 5)
        {
            speedMultiplier = 30 * 24;
        }
    }
    void ConvertTimeToInts(float _time)
    {
        years = Mathf.FloorToInt(_time / 8928);
        month = Mathf.FloorToInt((_time - years * 8928) / 744);
        days = Mathf.FloorToInt(((_time - years * 8928) - month * 744) / 24);
        hours = Mathf.FloorToInt(((_time - years * 8928) - month * 744) - days * 24);
    }
    void FillArray()
    {
        monthsList[0] = "January";
        monthsList[1] = "Febuary";
        monthsList[2] = "March";
        monthsList[3] = "April";
        monthsList[4] = "May";
        monthsList[5] = "June";
        monthsList[6] = "July";
        monthsList[7] = "August";
        monthsList[8] = "September";
        monthsList[9] = "October";
        monthsList[10] = "November";
        monthsList[11] = "December";
    }
}
