using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

        // Game states
        int level;

        enum Screen {Menu, Password, Win};
        Screen currentScreen;

        string password;

        // Use this for initialization
        void Start()
        {
            ShowMainMenu();
        }

        // This opens a menu in the Terminal
        void ShowMainMenu()
        {
            currentScreen = Screen.Menu;
            Terminal.ClearScreen();
            Terminal.WriteLine("Select your hacking target:");
            Terminal.WriteLine("Press 1 for domestic robot");
            Terminal.WriteLine("Press 2 for military AI");
            Terminal.WriteLine("Decypher the password to break through firewall.");
        }

        // Screen login branching
        void OnUserInput (string input)
        {
            if (input == "menu")
            {
                ShowMainMenu();
            }
            else if (currentScreen == Screen.Menu)
            {
                RunMainMenu(input);
            }
            else if (currentScreen == Screen.Password)
            {
                CheckPassword(input);  
            }
    }

    void RunMainMenu (string input)
    {
        if (input == "1")
        {
            level = 1;
            password = "cleaner";
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = "sniper";
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Use 1 or 2 to select an option");
        }
    }

    // Start game
    void StartGame ()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You've choosen level " + level);
        Terminal.WriteLine("Please enter your password:");
    }

    // Handle password input 
    void CheckPassword (string input)
    {
        if (input == password)
        {
            FinishGame();
        }
        else
        {
            Terminal.WriteLine("Wrong password. Try again");
        }
    }

    // Finish game
    void FinishGame ()
    {
        currentScreen = Screen.Win;
        Terminal.WriteLine("Conratulations! Access granted");
        Terminal.WriteLine("Type 'menu' for restart");
    }
}