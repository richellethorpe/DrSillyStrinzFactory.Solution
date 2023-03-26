# Dr. Silly Stringz Factory

#### By Richelle Thorpe 

#### This application set in a wacky factory that lets the uses keep track of machines and engineers.

## Technologies Used

- C#
- CSHTML
- .NET 6
- ASP.NET Core
- Markdown
- Entity Framework Core

## Description

- This application will the user to add machines and engineers to the system. It will also allow the user to add multiple machines to engineers as well as to ad multiple engineers to machines to show that they are licenced to service them.

## Setup/Installation Requirements

1. Clone this repo and create a SQL database for Stylists and Clients.
2. Open your shell (e.g., Terminal or GitBash) and navigate to this project's production directory called "Factory". 
3. Within the production directory "Factory", create a new file called appsettings.json.
4 .Within appsettings.json, put in the following code, replacing the database name with your database naming convention, uid and pwd values with your own username and password for MySQL. 

{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[database_name];uid=[id_here];pwd=[your_password];"
  }
}

5. Run `dotnet watch run` in the command line to start the project in development mode with a watcher.
6. Open the browser to _https://localhost:5001_. If you cannot access localhost:5001 it is likely because you have not configured a .NET developer security certificate for HTTPS. To learn about this, review this lesson: [Redirecting to HTTPS and Issuing a Security Certificate](https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/redirecting-to-https-and-issuing-a-security-certificate).


## Known Bugs

- No known bugs.

## License

Copyright 2023 Richelle Thorpe; Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions: The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software. THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.