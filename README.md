# GG-LogService

This project is a simple log service built using **Azure Functions**. The service allows for saving and retrieving log entries via HTTP endpoints.

## Features

### 1. Save Log Entry
- **Endpoint**: `/api/Function1` (POST)
- **Description**: This endpoint accepts a log entry and stores it in memory.
- **Input required**: JSON object with `Severity` and `Message`.
  
  Example to make an input to save a log entry:
  ```json
  {
      "Severity": "info",
      "Message": "This is a test log."
  }
   ```

### 2. Get Log Entry
- **Endpoint**: `/api/GetLogs` (GET)
- **Description**: This endpoint retrieves the 100 most recent log entries.

### Prerequisites
- **Azure Functions Core Tools (for local development)**
- **Postman or curl (for testing API endpoints)**


### Technologies Used
- **Azure Functions **
- **C#**
- **.NET Core**
- **Postman**
  
