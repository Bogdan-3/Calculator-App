using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Globalization;

public class Number_Button_Manager : MonoBehaviour
{
    string text = "";
    Dictionary<char, int> fr = new Dictionary<char, int>
    {
    {'+', 1}, {'-', 1}, {'*', 2}, {'/', 2}
    };
    float x;
    List<string> fp = new List<string>();
    Stack<char> st = new Stack<char>();
    Stack<float> nr = new Stack<float>();
    public TextMeshProUGUI Result;
    public TextMeshProUGUI Calc;
    public int maxDigitsBeforeDecimal = 6;
    public int maxDigitsAfterDecimal = 2;

    public void clear()
    {
        text = "";
        Calc.text = text;
        Result.text = "";
    }

    public void equal()
    {
        if (!verif())
            return;

        form_polish();
        calculare();
        if (nr.Count != 1)
        {
            Result.text = "Eroare: expresia este incompletă";
            return;
        }
        x = nr.Pop();
        text = "";
        Result.text = x.ToString(CultureInfo.InvariantCulture);
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
                    st.Push(c);
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
            fp.Add(number);

        while (st.Count > 0)
            fp.Add(st.Pop().ToString());
    }

    void calculare()
    {
        nr.Clear();
        foreach (string token in fp)
            if (float.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
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
                text = text.Substring(0, text.Length - 1) + x;
            else if (text.Length == 0 && "+-".Contains(x))
                text = text + "0" + x;
            else if (text.Length == 0 && "*/".Contains(x))
                text = text + "1" + x;
            else if (text[^1] == '.')
                text = text + "0" + x;
            else
                text += x;
        }
        else if ("()".Contains(x))
        {
            if (x == "(")
            {
                if (text.Length>0 && text[^1] == '.')
                    text += "0";
                if (text.Length > 0 && (char.IsDigit(text[^1]) || text[^1]==')'))
                    text += "*(";
                else
                    text += "(";
            }
            else
                text += ")";
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
                else if (!hasDot && currentNumber.Length == 0)
                    text += "0.";
            }
            else if (char.IsDigit(x[0]))
            {
                if (text.Length > 0 && text[^1] == ')')
                    text += "*";
                if (!hasDot && digitsBeforeDot < maxDigitsBeforeDecimal)
                {
                    if (digitsBeforeDot == 1 && currentNumber == "0")
                        text = text.Substring(0, text.Length - 1) + x;
                    else
                        text += x;
                }
                else if (hasDot && digitsAfterDot < maxDigitsAfterDecimal)
                    text += x;
            }
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


    bool verif()
    {
        //este calc gol?
        if (text.Length == 0)
            return false;

        //verific paranteze
        int balance = 0;
        foreach (char c in text)
        {
            if (c == '(') balance++;
            if (c == ')') balance--;
            if (balance < 0)
            {
                Result.text = "Bitch, () nu )(";
                return false;
            }
        }
        if (balance != 0)
        {
            Result.text = "Bitch, nu inchizi ()";
            return false;
        }

        //se termina cu operator
        if ("+-*/".Contains(text[^1]))
        {
            Result.text = "Bitch, operator la final";
            return false;
        }

        return true;
    }
}