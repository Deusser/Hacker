using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
    public Text timerText;
    public Text EndGameText;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    private float gametime;
    public Text pin1pintext;
    public Text pin2pintext;
    public Text pin3pintext;
    public Text pin1currentpintext;
    public Text pin2currentpintext;
    public Text pin3currentpintext;
    [SerializeField] GameObject TrojanButton;
    [SerializeField] GameObject VirusButton;
    [SerializeField] GameObject ScriptButton;
    [SerializeField] GameObject EndingPanel;
    [SerializeField] GameObject BadEnd;
    [SerializeField] GameObject GoodEnd;
    private int pin1cur;
    private int pin2cur;
    private int pin3cur;

    public void Timer()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                pin1currentpintext.text = pin1cur.ToString();
                pin2currentpintext.text = pin2cur.ToString();
                pin3currentpintext.text = pin3cur.ToString();
                gametime = Mathf.Round(timeRemaining);
                timerText.text = gametime.ToString();
                timeRemaining -= Time.deltaTime;
                if (pin1currentpintext.text == pin1pintext.text && pin2currentpintext.text == pin2pintext.text && pin3currentpintext.text == pin3pintext.text)
                {
                    timerIsRunning = false;
                    EndingPanel.SetActive(true);
                    GoodEnd.SetActive(true);
                }
            }
            else
            {
                EndGameText.text = ("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                EndingPanel.SetActive(true);
                BadEnd.SetActive(true);
            }
        }
    }



    public void Tools(int indexTools)
    {
        switch (indexTools)
        {
            case 0:
                Trojan(pin1cur = Convert.ToInt32(pin1currentpintext.text),
                       pin2cur = Convert.ToInt32(pin2currentpintext.text),
                       pin3cur = Convert.ToInt32(pin3currentpintext.text)
                       );
                break;

            case 1:
                Virus(pin1cur = Convert.ToInt32(pin1currentpintext.text),
                       pin2cur = Convert.ToInt32(pin2currentpintext.text),
                       pin3cur = Convert.ToInt32(pin3currentpintext.text)
                       );
                break;
            case 2:
                Script(pin1cur = Convert.ToInt32(pin1currentpintext.text),
                       pin2cur = Convert.ToInt32(pin2currentpintext.text),
                       pin3cur = Convert.ToInt32(pin3currentpintext.text)
                       );
                break;

            default:
                break;
        }
    }

    public void Execute(int pin1cur, int pin2cur, int pin3cur)
    {
        pin1currentpintext.text = pin1cur.ToString();
        pin2currentpintext.text = pin2cur.ToString();
        pin3currentpintext.text = pin3cur.ToString();
    }
    public void Trojan(int pin1cur, int pin2cur, int pin3cur)
    {
        pin1cur = pin1cur + 1;
        pin2cur = pin2cur - 1;
        pin3cur = pin3cur + 0;

        Execute(pin1cur, pin2cur, pin3cur);
    }
    public void Virus(int pin1cur, int pin2cur, int pin3cur)
    {
        pin1cur = pin1cur - 1;
        pin2cur = pin2cur + 2;
        pin3cur = pin3cur - 0;

        Execute(pin1cur, pin2cur, pin3cur);
    }

    public void Script(int pin1cur, int pin2cur, int pin3cur)
    {
        pin1cur = pin1cur - 1;
        pin2cur = pin2cur + 1;
        pin3cur = pin3cur + 0;

        Execute(pin1cur, pin2cur, pin3cur);
    }
    private void Start()
    {
        pin1pintext.text = 4.ToString();
        pin2pintext.text = 3.ToString();
        pin3pintext.text = 6.ToString();
        timerIsRunning = true;
    }


    void Update()
    {
        Timer();
    }
}