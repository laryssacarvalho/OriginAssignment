# Origin Assignment - Backend

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
    </li>
    <li><a href="#built-with">Built With</a></li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#dependencies">Dependencies</a></li>
        <li><a href="#execution">Execution</a></li>
      </ul>
    </li>
  </ol>
</details>

## About The Project

This project is the backend application ([click here](https://github.com/laryssacarvalho/origin-assignment-frontend) to access the frontend repository) of this [Origin's assignment](https://github.com/OriginFinancial/full-stack-take-home-assignment). 

The application consists of an API with only one endpoint to calculate the financial score of a user based on their personal data, so the user inputs the annual income and monthly costs and the response contains the score that can be Healthy, Medium or Low.

The endpoint URL is **/FinancialScore** and it is a POST method. This is the body request expected:
```
{
    "annualIncome": 1000,
    "monthlyCosts": 10
}
```
This is a body response example:
```
{
    "score": "Healthy"
}
```

## Built With

The project was built using a Web API from [.NET 6](https://dotnet.microsoft.com/en-us/).

I chose .NET because it's the backend framework I have the most experience with.

## Getting Started
There are two ways of running this project: on your machine or on a docker container. The latter one is easier if you have Docker installed. 

### Dependencies

If you are going to execute the project on your machine instead of using Docker, then you will need to install [.NET](https://dotnet.microsoft.com/en-us/download).

This is not a actually a dependency (since you can make requests directly to the endpoint) but if you want, you can execute the frontend application to see both of them running together (check the project documentation to see how to execute it):

* [Frontend project](https://github.com/laryssacarvalho/origin-assignment-frontend)

### Execution


#### On your machine

After cloning this repository you will need to execute the following commands on the root folder:

```
dotnet restore
dotnet build
```

Access the Web API project folder (/OriginAssignmentApi) and execute this one to run the project.
```
dotnet run
```
The API is now running on http://localhost:8000.

#### Using Docker

If you have Docker installed, then access the Web API project folder (/OriginAssignmentApi) to execute this two commands. The first one is going to build the image using the Dockerfile and the second one will run a container using that image.

```
docker build -t origin-api-image .
```

```
docker run -it --rm -p 8000:80 origin-api-image
```
The API is now running on http://localhost:8000.
