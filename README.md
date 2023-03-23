# WPF Login and User Management Application

This is a WPF application that utilizes the Caliburn.Micro MVVM framework to create a simple user login and management system with SQLite as the database.

## Features

- Login functionality: Validates user credentials against the SQLite database and grants access upon successful authentication.
- Sign-up functionality: Allows new users to register by providing the necessary information, which is then stored in the SQLite database.
- User information display: After successful login, the user is redirected to a UserPage, where their information is displayed.

## Getting Started

### Prerequisites

- Visual Studio 2019 or later
- .NET Framework 4.7.2 or later
- Caliburn.Micro 4.0.62 or later
- System.Data.SQLite.Core 1.0.115 or later

### Installation

1. Clone the repository
git clone https://github.com/mlhylmz/login-app-with-wpf-caliburn-mvvm-sqlite.git

2. Open the solution file `LoginAppWithCaliburn.sln` in Visual Studio

3. Restore the NuGet packages if necessary

4. Build and run the project

## Usage

1. Launch the application
2. Enter your username and password in the login page or click on "Sign Up" to create a new account
3. If the provided credentials are valid, you will be redirected to the UserPage, where your information will be displayed
4. To register a new account, fill in the required information in the Sign Up page and click on "Sign Up" again to save the information to the SQLite database

## License

This project is licensed under the [CC BY-NC 4.0 License](LICENSE) - see the [LICENSE](LICENSE) file for details.
