using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerKeyboard : MonoBehaviour {

    [SerializeField] private Text text;
    [SerializeField] private TimerHandler timerHandler;
    Queue<string> digits;

    private void Start()
    {
        digits = new Queue<string>();
        text.text = timeText();
    }

    public void onClick(int code)
    {
        if (digits.Count >= 6)
            return;

        if (code >= 0)
            digits.Enqueue("" + code);
        else if (code == -1)
        {
            if (digits.Count > 0)
            {
                for (int i = 0; i < digits.Count - 1; i++)
                    digits.Enqueue(digits.Dequeue());
                digits.Dequeue();
            }
        }
        else if (code == -2)
            digits.Clear();

        text.text = timeText();
    }

    public void applyTimer()
    {
        timerHandler.AddTimer(timeText());
        //gameObject.SetActive(false);
        digits.Clear();
        text.text = timeText();
    }

    public string timeText()
    {
        string timer = "";
        int filler = 6 - digits.Count;

        for (int i = 0; i < 6; i++)
        {
            if (i != 0 && i % 2 == 0)
                timer += ":";

            if (filler > 0)
            {
                timer += "0";
                filler--;
            }
            else
            {
                string digit = digits.Dequeue();
                timer += digit;
                digits.Enqueue(digit);
            }

        }

        return timer;
    }
}
