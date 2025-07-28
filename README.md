# Job Portal API

This is a backend-only REST API for a job portal application, built with .NET 8 and C#. The project allows users to register as employers or applicants, post jobs, apply for jobs, and more.

---

## Features Implemented

- **User Management:** User registration and a secure login endpoint with password hashing (BCrypt).
- **Role-Based Access:** Differentiates between "Employers" who can post jobs and "Applicants" who can apply.
- **Full CRUD for Jobs:** Employers can Create, Read, Update, and Delete job postings.
- **Job Applications:** Applicants can submit applications for jobs.
- **Filtering & Searching:** API endpoint to filter jobs by title, location, and type.
- **Bookmarking:** Users can save or "bookmark" jobs they are interested in.
- **Dashboard Analytics:** An endpoint to provide basic stats like total users, jobs, and applications.
- **Robust Architecture:**
  - **Repository Pattern:** Separates data access logic from business logic.
  - **Service Layer:** Contains all the core business logic.
  - **DTOs (Data Transfer Objects):** Ensures clean and secure API contracts.
- **Validation & Error Handling:** Uses data annotations for validation and a global middleware for handling unexpected errors.
- **Logging:** Integrated with **Serilog** to log application events and errors to a file.
- **Unit Testing:** Includes a unit test project (`xUnit` and `Moq`) to demonstrate testing principles.

---

## Technologies Used

- **Framework:** .NET 8
- **Language:** C#
- **API:** ASP.NET Core Web API
- **Database:** SQL Server
- **ORM:** Entity Framework Core (Code-First)
- **Authentication:** BCrypt.Net-Next for password hashing
- **Testing:** xUnit, Moq
- **Logging:** Serilog

---

## How to Run the Project

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/rsjadoun8092005/Job_Portal.git](https://github.com/rsjadoun8092005/Job_Portal.git)
    ```
2.  **Configure the database:**
    - Open `Job_Portal.API/appsettings.json`.
    - Modify the `DefaultConnection` string to point to your local SQL Server instance.
3.  **Apply database migrations:**
    - Open a terminal in the root project folder.
    - Run the command: `dotnet ef database update`
4.  **Run the API:**
    - Navigate to the `Job_Portal.API` folder.
    - Run the command: `dotnet run`
5.  **Access the API:**
    - The API will be running at the URL specified in the terminal (e.g., `https://localhost:7123`).
    - Access the Swagger UI for testing at `[your_api_url]/swagger`.