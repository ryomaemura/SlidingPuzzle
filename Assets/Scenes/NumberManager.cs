using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberManager : MonoBehaviour
{
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;
    [SerializeField] Button button4;
    [SerializeField] Button button5;
    [SerializeField] Button button6;
    [SerializeField] Button button7;
    [SerializeField] Button button8;
    [SerializeField] Button button9;
    [SerializeField] Button button10;
    [SerializeField] Button button11;
    [SerializeField] Button button12;
    [SerializeField] Button button13;
    [SerializeField] Button button14;
    [SerializeField] Button button15;
    [SerializeField] Button button16;
    Button[] buttons;
    [SerializeField] TextMeshProUGUI buttonText1;
    [SerializeField] TextMeshProUGUI buttonText2;
    [SerializeField] TextMeshProUGUI buttonText3;
    [SerializeField] TextMeshProUGUI buttonText4;
    [SerializeField] TextMeshProUGUI buttonText5;
    [SerializeField] TextMeshProUGUI buttonText6;
    [SerializeField] TextMeshProUGUI buttonText7;
    [SerializeField] TextMeshProUGUI buttonText8;
    [SerializeField] TextMeshProUGUI buttonText9;
    [SerializeField] TextMeshProUGUI buttonText10;
    [SerializeField] TextMeshProUGUI buttonText11;
    [SerializeField] TextMeshProUGUI buttonText12;
    [SerializeField] TextMeshProUGUI buttonText13;
    [SerializeField] TextMeshProUGUI buttonText14;
    [SerializeField] TextMeshProUGUI buttonText15;
    [SerializeField] TextMeshProUGUI buttonText16;
    TextMeshProUGUI[] buttonTexts;
    [SerializeField] TextMeshProUGUI moveText;
    int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0};
    int[,] relasionshipNumbers = {
        {0, 1, 0, 0,   1, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0},
        {1, 0, 1, 0,   0, 1, 0, 0,   0, 0, 0, 0,   0, 0, 0, 0},
        {0, 1, 0, 1,   0, 0, 1, 0,   0, 0, 0, 0,   0, 0, 0, 0},
        {0, 0, 1, 0,   0, 0, 0, 1,   0, 0, 0, 0,   0, 0, 0, 0},

        {1, 0, 0, 0,   0, 1, 0, 0,   1, 0, 0, 0,   0, 0, 0, 0},
        {0, 1, 0, 0,   1, 0, 1, 0,   0, 1, 0, 0,   0, 0, 0, 0},
        {0, 0, 1, 0,   0, 1, 0, 1,   0, 0, 1, 0,   0, 0, 0, 0},
        {0, 0, 0, 1,   0, 0, 1, 0,   0, 0, 0, 1,   0, 0, 0, 0},

        {0, 0, 0, 0,   1, 0, 0, 0,   0, 1, 0, 0,   1, 0, 0, 0},
        {0, 0, 0, 0,   0, 1, 0, 0,   1, 0, 1, 0,   0, 1, 0, 0},
        {0, 0, 0, 0,   0, 0, 1, 0,   0, 1, 0, 1,   0, 0, 1, 0},
        {0, 0, 0, 0,   0, 0, 0, 1,   0, 0, 1, 0,   0, 0, 0, 1},

        {0, 0, 0, 0,   0, 0, 0, 0,   1, 0, 0, 0,   0, 1, 0, 0},
        {0, 0, 0, 0,   0, 0, 0, 0,   0, 1, 0, 0,   1, 0, 1, 0},
        {0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 1, 0,   0, 1, 0, 1},
        {0, 0, 0, 0,   0, 0, 0, 0,   0, 0, 0, 1,   0, 0, 1, 0},
    };
    int randomNumber = 0;
    int tempNumber = 0;
    int moveNumber = 0;
    int blockNumber = 6;

    // Start is called before the first frame update
    void Start() {
        buttons = new Button[] {button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16};
        buttonTexts = new TextMeshProUGUI[] {buttonText1, buttonText2, buttonText3, buttonText4, buttonText5, buttonText6, buttonText7, buttonText8, buttonText9, buttonText10, buttonText11, buttonText12, buttonText13, buttonText14, buttonText15, buttonText16};

        resetNumber();
    }

    // Update is called once per frame
    void Update() {
    }

    public void setBlock() {
        for (int i = 0; i < numbers.Length; i++) {
            relasionshipNumbers[blockNumber, i] = 0;
            relasionshipNumbers[i, blockNumber] = 0;
        }

        buttons[blockNumber].GetComponent<Image>().color = new Color32(100, 0, 200, 255);
    }

    public void resetNumber() {
        for (int i = 0; i < numbers.Length; i++) {
            numbers[i] = i + 1;
            buttons[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }

        numbers[numbers.Length - 1] = 0;

        if (blockNumber != -1) {
            setBlock();
        }

        for (int i = 0; i < 500; i++) {
            // output 0 ~ numbers.length - 1 (15)
            randomNumber = UnityEngine.Random.Range(0, numbers.Length);

            clickNumberButton(randomNumber);
        }

        moveNumber = 0;
        moveText.text = "Move:0";
    }

    public void setNumbers() {
        for (int i = 0; i < numbers.Length; i++) {
            buttonTexts[i].text = numbers[i].ToString();

            if (numbers[i] == 0) {
                buttonTexts[i].text = "";
            }
        }
    }

    public void clickNumberButton(int buttonNumber) {
        for (int i = 0; i < numbers.Length; i++) {
            if (relasionshipNumbers[buttonNumber, i] == 1 && numbers[i] == 0) {
                tempNumber = numbers[buttonNumber];
                numbers[buttonNumber] = numbers[i];
                numbers[i] = tempNumber;

                moveNumber++;
            }
        }

        setNumbers();

        moveText.text = "Move:" + moveNumber.ToString();
    }
}
