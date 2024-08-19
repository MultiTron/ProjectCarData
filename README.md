# Project Car Data

## Description

An ASP.NET Web API which allows you to track your cars's tax, tech inspection, insurance, toll tax and trip data (Currently only working for Bulgaria). The Web API designed as a multilayer application making it complient with the clean code principles.

## Tech Stack
- [ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet)
- [Entity Framework](https://learn.microsoft.com/en-us/ef/)
- [JWT Authentication](https://jwt.io/)
- [AutoMapper](https://automapper.org)
- [Swagger](https://swagger.io/)
- [Docker](https://www.docker.com/)

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)
- [Future Plans](#future-plans)
- [License](#license)

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/MultiTron/ProjectCarData.git
    ```
2. Navigate to the project directory:
    ```bash
    cd ProjectCarData
    ```
3. Install the required packages:
    ```bash
    dotnet restore
    ```
4. Update the database (if applicable):
    ```bash
    dotnet ef database update
    ```

## Usage

1. Run the application:
    ```bash
    dotnet run
    ```
2. Open your browser and navigate to `http://localhost:5000` to see the API in action.

## API Endpoints

Check Swagger Documentation(WIP)

- `GET /api/controller` - Retrieves all values.
- `GET /api/controller/{id}` - Retrieves a value by ID.
- `POST /api/controller` - Creates a new value.
- `PUT /api/controller/{id}` - Updates a value by ID.
- `DELETE /api/controller/{id}` - Deletes a value by ID.

## Contributing

If you would like to contribute to this project, please follow these steps:

1. Fork the repository.
2. Create a new branch:
    ```bash
    git checkout -b feature/your-feature-name
    ```
3. Make your changes and commit them:
    ```bash
    git commit -m "Add some feature"
    ```
4. Push to the branch:
    ```bash
    git push origin feature/your-feature-name
    ```
5. Open a pull request.

## Future Plans

- GUI (Webapp(PWM), Mobile)
- Real-Time Notifications
- Docker Support
- Insurance Data
- Tech Inspection Data
- Tax Data
- Gas Prices

## License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/MultiTron/ProjectCarData?tab=MIT-1-ov-file) file for details.
