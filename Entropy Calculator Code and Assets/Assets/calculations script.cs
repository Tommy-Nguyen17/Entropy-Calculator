using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class calculationsscript : MonoBehaviour
{
    private string userPassword;
    private int numGuessesPerSecond;
    private int poolSize = 0;

    private const int SECONDS_IN_A_YEAR = 31536000;
    private  Regex regex1 = new Regex(@"[a-z]"); 
    private  Regex regex2 = new Regex(@"[A-Z]"); 
    private  Regex regex3 = new Regex(@"[0-9]"); 
    private  Regex regex4 = new Regex(@"[`~!@#$%^&*()-_=+[{}]\;:’”<>/?]"); 



    public GameObject userPasswordInput, userGuessesInput, resultsObj;

    void Start() {
        resultsObj.SetActive(false);
    }

    public void calculateYearsToCrackPassword() {
        readInputs();
        resultsObj.SetActive(true);

        Match match = regex1.Match(userPassword);
        if(match.Success) {
            poolSize += 26;
        }

        match = regex2.Match(userPassword);
        if(match.Success) {
            poolSize += 26;
        }

        match = regex3.Match(userPassword);
        if(match.Success) {
            poolSize += 10;
        }

        match = regex4.Match(userPassword);
        if(match.Success) {
            poolSize += 32;
        }
        
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
        poolSize = 0;
    }

    public void readInputs() {
        numGuessesPerSecond = 0;
        string userGuessesString = userGuessesInput.GetComponent<InputField>().text;
        Int32.TryParse(userGuessesString, out numGuessesPerSecond);

        userPassword = userPasswordInput.GetComponent<InputField>().text;
    }

    private double calculateEntropy(int passwordLength) {
        return Math.Round(passwordLength * Math.Log10(poolSize) / Math.Log10(2), 2);
    }

    private double calculateYears(double entropy, int numGuessesPerSecond) {
        return Math.Round((Math.Pow(2, entropy - 1) / numGuessesPerSecond)/SECONDS_IN_A_YEAR);
    }

}
