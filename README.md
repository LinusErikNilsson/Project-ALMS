Project ALMS is a demonstration/showcase project in .NET MAUI.
Parts of the project was part of the repo owners System developer .NET / Systemutvecklare .NET education.
The project will be updated from time to time, but it should be considured as a beta-project.

# Project overview
Project ALMS (Application for Logging Medicine and Statistics/Applikation för loggning av medicin och statistik) is a cross-platform mobile application developed in .NET MAUI.
The application is created as a tool to log medicine administration and keep track of key statistics.

Data recorded in the application is stored on-device using a SQLite database.
The project also includes a WebAPI, from which the application gets MedicineData.

# Dev requirements:
- Visual Studio 2022, with:
- .NET MAUI workloads
- .NET 8.0 SDK
- ASP.NET Core

# Build and run the project
Open the solution file (.sln) in Visual Studio 2022.
Select MAUIAPP as Start up project.
Select a target framrwork to run/debug, either Windows or Android (iOS/MacOS not currently tested and supported)
Note: The WebAPI Project does not need to be started, as it is already deployed and running in Azure and the MAUI app will by default get data from the deployed API.

