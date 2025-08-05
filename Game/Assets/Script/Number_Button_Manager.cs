using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Number_Button_Manager : MonoBehaviour
{
    string text = "";
    bool open = true;
    Dictionary<char, int> fr = new Dictionary<char, int>
    {
    {'+', 1}, {'-', 1}, {'*', 2}, {'/', 2}
    };
    List<string> fp = new List<string>();
    Stack<char> st = new Stack<char>();
    Stack<float> nr = new Stack<float>();
    public TextMeshProUGUI Result;
    public TextMeshProUGUI Calc;
    public int maxDigitsBeforeDecimal = 6;
    public int maxDigitsAfterDecimal = 2;

    public void clear()
    {
        open = true;
        text = "";
        Calc.text = text;
        Result.text = "";
    }

    public void equal()
    {
        form_polish();
        calculare();
        print(string.Join(" ", fp));
        float x = nr.Pop();
        text = "";
        open = true;
        Result.text = Convert.ToString(x);
    }

    void form_polish()
    {
        fp.Clear();
        st.Clear();
        string number = "";
        bool buildingNumber = false;

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];

            if (char.IsDigit(c) || c == '.')
            {
                number += c;
                buildingNumber = true;
            }
            else
            {
                if (buildingNumber)
                {
                    fp.Add(number);
                    number = "";
                    buildingNumber = false;
                }

                if (c == '(')
                {
                    st.Push(c);
                }
                else if (c == ')')
                {
                    while (st.Count > 0 && st.Peek() != '(')
                        fp.Add(st.Pop().ToString());
                    if (st.Count > 0 && st.Peek() == '(')
                        st.Pop();
                }
                else if ("+-*/".Contains(c))
                {
                    while (st.Count > 0 && st.Peek() != '(' && fr[st.Peek()] >= fr[c])
                        fp.Add(st.Pop().ToString());
                    st.Push(c);
                }
            }
        }

        if (buildingNumber)
        {
            fp.Add(number);
        }

        while (st.Count > 0)
        {
            fp.Add(st.Pop().ToString());
        }
    }

    void calculare()
    {
        nr.Clear();
        foreach (string token in fp)
            if (float.TryParse(token, out float value))
                nr.Push(value); // E un număr → îl pui pe stivă
            else
            {
                // E un operator → scoți 2 numere și aplici operația
                float b = nr.Pop(); // ultimul intrat
                float a = nr.Pop(); // înaintea lui
                if (token == "+")
                    nr.Push(a + b);
                else if (token == "-")
                    nr.Push(a - b);
                else if (token == "*")
                    nr.Push(a * b);
                else if (token == "/")
                    nr.Push(a / b);
            }
    }

    public void create_calc(string x)
    {
        Result.text = "";

        if ("+-*/".Contains(x))
        {
            if (text.Length > 0 && "+-*/".Contains(text[^1].ToString()))
            {
                text = text.Substring(0, text.Length - 1) + x;
            }
            else
            {
                text += x;
            }
        }
        else
        {
            // Get the current number being built
            int lastOp = text.LastIndexOfAny("+-*/()".ToCharArray());
            string currentNumber = (lastOp == -1) ? text : text.Substring(lastOp + 1);

            bool hasDot = currentNumber.Contains(".");
            int digitsBeforeDot = hasDot ? currentNumber.IndexOf('.') : currentNumber.Length;
            int digitsAfterDot = hasDot ? currentNumber.Length - currentNumber.IndexOf('.') - 1 : 0;

            if (x == ".")
            {
                // Allow only one dot
                if (!hasDot && currentNumber.Length > 0) // prevent just starting with "."
                    text += x;
            }
            else if (char.IsDigit(x[0]))
            {
                if (!hasDot && digitsBeforeDot < maxDigitsBeforeDecimal)
                {
                    text += x;
                }
                else if (hasDot && digitsAfterDot < maxDigitsAfterDecimal)
                {
                    text += x;
                }
            }
        }

        Calc.text = text;
    }

    public void parantese()
    {
        if (open == true)
        {
            open = false;
            text += "(";
        }
        else
        {
            open = true;
            text += ")";
        }
        Calc.text = text;
    }

    public void backspace()
    {
        if (text.Length > 0)
        {
            text = text.Remove(text.Length - 1);
            Calc.text = text;
        }
    }
}