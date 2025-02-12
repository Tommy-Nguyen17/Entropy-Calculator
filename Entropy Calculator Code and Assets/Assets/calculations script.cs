using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class calculationsscript : MonoBehaviour
{
    private string userPassword;
    private int numGuessesPerSecond;

    private const int SECONDS_IN_A_YEAR = 31536000;

    public GameObject userPasswordInput, userGuessesInput, resultsObj;

    void Start() {
        resultsObj.SetActive(false);
    }

    public void calculateYearsToCrackPassword() {
        readInputs();
        resultsObj.SetActive(true);
        
        string stringOne = "Sorry. No free iPhone lmao. \n Thanks for the password though nerd \n";
        string stringTwo = "Entropy: " + calculateEntropy(userPassword.Length) + "\n";
        string stringThree = "Years to brute force password: " + calculateYears(calculateEntropy(userPassword.Length), numGuessesPerSecond) + "\n";

        Debug.Log("Entropy: " + calculateEntropy(userPassword.Length));
        Debug.Log("Years to brute force password: " + calculateYears(calculateEntropy(userPassword.Length), numGuessesPerSecond));

        resultsObj.GetComponentInChildren<Text>().text = stringOne + stringTwo + stringThree;
    }

    public void resetCalculator() {
         resultsObj.GetComponentInChildren<Text>().text = "";
        resultsObj.SetActive(false);
    }

    public void readInputs() {
        numGuessesPerSecond = 0;
        string userGuessesString = userGuessesInput.GetComponent<InputField>().text;
        Int32.TryParse(userGuessesString, out numGuessesPerSecond);

        userPassword = userPasswordInput.GetComponent<InputField>().text;
    }

    private double calculateEntropy(int passwordLength) {
        return Math.Round(passwordLength * Math.Log10(94) / Math.Log10(2), 2);
    }

    private double calculateYears(double entropy, int numGuessesPerSecond) {
        return Math.Round((Math.Pow(2, entropy - 1) / numGuessesPerSecond)/SECONDS_IN_A_YEAR);
    }

}
