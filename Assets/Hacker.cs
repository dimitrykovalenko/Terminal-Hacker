using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configurations
    string[] level1Passwords = { "domestic", "friend", "machine", "modern", "helpful" };
    string[] level2Passwords = { "internet", "dangerous", "protected", "server", "penetration" };
    string[] level3Passwords = { "perfection", "masterpeace", "inspiration", "precious", "security" };

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
        Terminal.WriteLine("Select your hacking area:");
        Terminal.WriteLine("Press 1 for domestic robot");
        Terminal.WriteLine("Press 2 for military AI");
        Terminal.WriteLine("Press 3 for museum vault");
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

    // Display main menu screen
    void RunMainMenu (string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Use 1-3 to select an option");
        }
    }

    // Ask user to guess the password from anagram
    void AskForPassword ()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        GeneratePassword();
        Terminal.WriteLine("Decypher the password: " + password.Anagram());
        ShowMenuHint();

    }

    // Choose random password from the collection
    void GeneratePassword() 
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }


    // Handle password input 
    void CheckPassword (string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    // Show win screen
    void DisplayWinScreen ()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        ShowMenuHint();
    }

    // Show level reward
    void ShowLevelReward() 
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Robot hacked and waiting for orders");
                break;
            case 2:
                Terminal.WriteLine("Accessing AI core... Information extracted");
                break;
            case 3:
                Terminal.WriteLine("Museum vault is open");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }        
    }

    // Hint user to type "menu" to exit curent screen
    void ShowMenuHint()
    {
        Terminal.WriteLine("Type 'menu' to refresh");   
    }

}