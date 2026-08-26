# 🚗 DVLD — Driving & Vehicle License Department

<p align="center">

  <img src="docs/Images/MainScreen.png" alt="DVLD Main Screen" width="900">

</p>

<h3 align="center">
  Driving & Vehicle License Department Management System
</h3>

<p align="center">
  A complete desktop application for managing people, users, applications, tests, drivers, and driving licenses.
</p>

<p align="center">

![C#](https://img.shields.io/badge/C%23-.NET-512BD4?style=for-the-badge&logo=csharp&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![WinForms](https://img.shields.io/badge/UI-WinForms-0078D4?style=for-the-badge)
![ADO.NET](https://img.shields.io/badge/Data%20Access-ADO.NET-orange?style=for-the-badge)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Three Tier](https://img.shields.io/badge/Architecture-Three--Tier-success?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-yellow?style=for-the-badge)

</p>

---

## 📌 Table of Contents

- [📖 About The Project](#-about-the-project)
- [🎯 Project Goals](#-project-goals)
- [✨ Key Features](#-key-features)
  - [👤 Person Management](#-person-management)
  - [👥 User Management](#-user-management)
  - [📝 Applications & Tests](#-applications--tests)
  - [🚘 Drivers & Licenses](#-drivers--licenses)
  - [🌍 International License](#-international-license)
  - [⚠️ License Detention](#️-license-detention)
- [🔄 Main Application Workflows](#-main-application-workflows)
- [🏗️ Architecture](#️-architecture)
- [🗄️ Database Design](#️-database-design)
- [🛠️ Technologies](#️-technologies)
- [🧠 Concepts Applied](#-concepts-applied)
- [📂 Project Structure](#-project-structure)
- [📸 Screenshots](#-screenshots)
- [🚀 Getting Started](#-getting-started)
- [🗄️ Database Setup](#️-database-setup)
- [🔌 Connection Configuration](#-connection-configuration)
- [🎓 Learning Journey](#-learning-journey)
- [🙏 Special Thanks](#-special-thanks)
- [🔮 Future Improvements](#-future-improvements)
- [📄 License](#-license)
- [⭐ Support](#-support)

---

# 📖 About The Project

**DVLD — Driving & Vehicle License Department** is a comprehensive desktop application developed using **C#, .NET Framework, Windows Forms, ADO.NET, and SQL Server**.

The system simulates a real-world Driving & Vehicle License Department and manages different services related to:

- 👤 People
- 👥 Users
- 📝 Applications
- 🧪 Tests
- 🚘 Drivers
- 🪪 Local Driving Licenses
- 🌍 International Driving Licenses
- ⚠️ Detained Licenses
- 🔄 License Renewal
- 🛠️ License Replacement
- ⚙️ Account Management

The main objective of this project was not simply to build a working application, but to practice the complete development process:

```text
Requirements
     ↓
System Analysis
     ↓
Database Design
     ↓
Application Architecture
     ↓
Business Logic
     ↓
Data Access
     ↓
User Interface
     ↓
Testing & Debugging
     ↓
Complete System
```

The project was developed as part of my journey through **Programming Advices — Course 19**, and represents a major step in applying programming concepts to a large, interconnected system.

---

# 🎯 Project Goals

The project was built with several goals in mind:

- Apply Object-Oriented Programming in a real project.
- Practice database analysis and design.
- Work with SQL Server and ADO.NET.
- Apply Three-Tier Architecture.
- Separate UI, business logic, and database operations.
- Implement real-world business rules.
- Build reusable and maintainable components.
- Improve problem-solving and debugging skills.
- Understand how different modules work together inside a large system.

---

# ✨ Key Features

# 👤 Person Management

The Person Management module provides complete management of people registered in the system.

### Features

- ➕ Add new people
- 📋 View person information
- ✏️ Update person information
- 🔎 Search and filter people
- 🆔 National Number validation
- 📧 Optional Email with validation
- 🖼️ Person image management
- 🔄 Update person information
- 🗑️ Safe handling of records

### Data Validation

The system applies validation rules to maintain data integrity, including:

- Preventing duplicate National Numbers.
- Validating optional email addresses.
- Validating required fields.
- Validating personal information before saving.

### 🖼️ Image Management

Person images are handled carefully:

- Images are copied to a dedicated location.
- Images can be renamed using GUIDs.
- Existing images can be updated.
- Images can be removed when required.

This helps prevent filename conflicts and keeps uploaded images organized.

---

# 👥 User Management

The User Management module handles system users and their accounts.

### Features

- ➕ Add users
- 📋 View users
- ✏️ Update users
- 🟢 Activate users
- 🔴 Deactivate users
- 🔐 Manage login credentials
- 👤 Connect users with people
- 🔑 Manage permissions

Users are linked to their corresponding Person records instead of duplicating personal information.

---

# 📝 Applications & Tests

The application management module handles the different services and processes required for obtaining a driving license.

---

## 📋 Application Types

The system provides management for application types.

### Features

- View application types
- Update application information
- Manage application fees
- Maintain application type data

---

## 🧪 Test Types

The system manages different types of driving tests.

### Includes

- 👁️ Vision Test
- 📝 Written Test
- 🚘 Street Test

The system also allows managing test information and fees.

---

## 🪪 Local Driving License Application

The system supports the complete process of applying for a local driving license.

### Application Process

```text
Person
   ↓
Select License Class
   ↓
Create Application
   ↓
Schedule Tests
   ↓
Vision Test
   ↓
Written Test
   ↓
Street Test
   ↓
Complete Requirements
   ↓
Issue Driving License
```

### Business Rules

The application applies several validation rules, including:

- Checking the applicant's age.
- Validating the selected license category.
- Preventing duplicate active applications.
- Checking previous licenses.
- Validating application status.
- Ensuring required tests are completed.

---

## 📅 Schedule Test

The system provides test scheduling functionality.

### Features

- Schedule Vision Test
- Schedule Written Test
- Schedule Street Test
- View test appointments
- Prevent invalid scheduling
- Prevent scheduling when requirements are not met
- Track test results
- Support retesting when required

### Test Flow

```text
Vision
  ↓
Written
  ↓
Street
  ↓
License Issuance
```

The next stage cannot be completed until the previous required stage has been successfully completed.

---

# 🚘 Drivers & Licenses

The system provides a complete set of operations for managing drivers and their licenses.

---

## 🚗 Drivers

Drivers are managed separately from Person records.

### Features

- Create driver records
- View drivers
- Search drivers
- Display driver information
- View related licenses
- Connect drivers with their personal information

---

# 🪪 Local Driving Licenses

The system supports the complete lifecycle of local driving licenses.

### Supported Operations

- 🆕 Issue License
- 🔎 View License
- 🔄 Renew License
- 🛠️ Replace Damaged License
- 🚨 Replace Lost License
- 📋 Manage License History

---

# 🔄 Renew License

The system allows eligible licenses to be renewed.

### Renewal Process

```text
Existing License
       ↓
Validate License
       ↓
Create Renewal Application
       ↓
Pay Required Fees
       ↓
Issue New License
       ↓
Update License Status
```

The old license is handled appropriately while the new license becomes the active license.

---

# 🛠️ Replace License

The system supports replacing licenses in different situations.

### Supported Cases

- 🚨 Lost License
- 🛠️ Damaged License

The system validates the existing license before creating the replacement and maintains the related records.

---

# 🌍 International License

The system also supports International Driving Licenses.

### Features

- 🌍 Issue International License
- 🔎 View International License
- 📋 Manage International Licenses
- 👤 Link license with driver
- 📅 Track validity
- 🔐 Validate eligibility

The system checks the driver's eligibility before issuing an international license.

---

# ⚠️ License Detention

The system provides functionality for detaining and releasing licenses.

## 🔒 Detain License

A license can be detained when required.

### Features

- Select license
- Record detention
- Apply detention fees
- Store detention information
- Track detained licenses

---

## 🔓 Release License

The system allows a detained license to be released.

### Release Process

```text
Detained License
       ↓
Find Detention Record
       ↓
Create Release Operation
       ↓
Pay Required Fees
       ↓
Release License
       ↓
Update Detention Status
```

---

## 📋 Manage Detained Licenses

The system provides management functionality for detained licenses.

### Features

- Search detained licenses
- View detention information
- Release licenses
- Track detention status
- View related operations

---

# 🔄 Main Application Workflows

One of the most important aspects of DVLD is connecting different modules together.

## 🪪 Local License Workflow

```text
Person
  ↓
Application
  ↓
License Class
  ↓
Schedule Vision Test
  ↓
Pass Vision Test
  ↓
Schedule Written Test
  ↓
Pass Written Test
  ↓
Schedule Street Test
  ↓
Pass Street Test
  ↓
Issue License
  ↓
Driver
```

---

## 🔄 License Renewal Workflow

```text
Existing License
       ↓
Check License
       ↓
Renew Application
       ↓
Fees
       ↓
New License
       ↓
Old License Updated
```

---

## 🌍 International License Workflow

```text
Driver
  ↓
Check Eligibility
  ↓
Check Local License
  ↓
Create Application
  ↓
Pay Fees
  ↓
Issue International License
```

---

## ⚠️ Detention Workflow

```text
Active License
      ↓
Detain License
      ↓
Detention Record
      ↓
Detained License
      ↓
Release License
      ↓
Active License
```

---

# 🏗️ Architecture

The project follows **Three-Tier Architecture** to separate responsibilities and keep the system organized and maintainable.

```text
┌────────────────────────────────────────────┐
│           🖥️ Presentation Layer            │
│              Windows Forms                │
│                                            │
│       User Interface & Interaction         │
└──────────────────────┬─────────────────────┘
                       │
                       ▼
┌────────────────────────────────────────────┐
│             ⚙️ Business Layer              │
│                                            │
│          Business Rules & Logic            │
└──────────────────────┬─────────────────────┘
                       │
                       ▼
┌────────────────────────────────────────────┐
│            🗄️ Data Access Layer            │
│                                            │
│                 ADO.NET                   │
│          Database Communication            │
└──────────────────────┬─────────────────────┘
                       │
                       ▼
┌────────────────────────────────────────────┐
│              💾 SQL Server                │
│                                            │
│               DVLD Database                │
└────────────────────────────────────────────┘
```

## 🖥️ Presentation Layer

The Presentation Layer contains the Windows Forms interface.

Responsible for:

- User Interface
- User interaction
- Displaying information
- Collecting user input
- Calling business operations
- Handling UI-level validation

---

## ⚙️ Business Layer

The Business Layer contains the application's business rules and logic.

Responsible for:

- Business rules
- Validation
- Processing operations
- Managing workflows
- Coordinating operations between UI and database

This layer is especially important in DVLD because many operations depend on business rules and the current state of an application, test, driver, or license.

---

## 🗄️ Data Access Layer

The Data Access Layer is responsible for communicating with SQL Server.

It handles:

- Database connections
- SQL queries
- CRUD operations
- Stored procedures where applicable
- Reading data
- Updating data
- Inserting records
- Deleting or deactivating records

Database communication is implemented using **ADO.NET**.

---

# 🗄️ Database Design

Database design was one of the important stages of this project.

Before implementing the application, the system was analyzed and the relationships between its entities were considered.

The database is responsible for storing information related to:

- People
- Users
- Applications
- Application Types
- Tests
- Test Types
- Drivers
- Licenses
- International Licenses
- Detained Licenses
- Payments
- Related records and histories

The database design allows different modules to work together while maintaining relationships and data integrity.

---

# 🔗 Database & Application Relationship

The application communicates with SQL Server through the Data Access Layer:

```text
Windows Forms
      ↓
Business Layer
      ↓
Data Access Layer
      ↓
ADO.NET
      ↓
SQL Server
```

This keeps database operations away from the user interface and business logic.

---

# 🛠️ Technologies

| Technology | Purpose |
|---|---|
| **C#** | Main programming language |
| **.NET Framework 4.7.2** | Application framework |
| **Windows Forms** | Desktop User Interface |
| **ADO.NET** | Database access |
| **SQL Server** | Relational database |
| **T-SQL** | Database scripting |
| **OOP** | Application design |
| **Three-Tier Architecture** | Separation of responsibilities |
| **Visual Studio** | Development environment |
| **Git** | Version control |
| **GitHub** | Repository hosting |

---

# 🧠 Concepts Applied

The project was used to apply a wide range of programming and software engineering concepts.

### Programming

- Object-Oriented Programming
- Encapsulation
- Abstraction
- Inheritance
- Polymorphism
- Classes & Objects
- Interfaces
- Reusable Components

### Database

- Relational Database Design
- Primary Keys
- Foreign Keys
- Relationships
- Constraints
- SQL Queries
- CRUD Operations
- SQL Server
- ADO.NET

### Software Architecture

- Three-Tier Architecture
- Separation of Concerns
- Business Logic Separation
- Data Access Separation
- Reusability
- Maintainability

### Application Development

- Input Validation
- Error Handling
- Search & Filtering
- Image Management
- User Authentication
- Permission Management
- Workflow Management
- Business Rules

---

# 📂 Project Structure

```text
DVLD-Project
│
├── 📁 DVLDDataAccessLayer
│   └── Data Access Layer
│
├── 📁 DVLDDataBusinessLayer
│   └── Business Logic Layer
│
├── 📁 Database
│   └── SQL Server Database Scripts
│
├── 📁 Project
│   └── Presentation Layer / UI
│       ├── 📁 Application
│       ├── 📁 Driver
│       ├── 📁 Global Classes
│       ├── 📁 Licenses
│       ├── 📁 Login
│       ├── 📁 People
│       ├── 📁 Resources
│       ├── 📁 Test
│       ├── 📁 User
│       ├── 📄 App.config
│       ├── 📄 MainForm.cs
│       ├── 📄 packages.config
│       └── 📄 Program.cs
│
├── 📁 docs
│   └── 📁 Images
│       ├── AccountSettings.png
│       ├── ApplicationsMenu.png
│       ├── Login.png
│       ├── MainScreen.png
│       ├── ManageDriver.png
│       ├── ManagePeople.png
│       └── ManageUserAndAddUser.png
│
├── 📁 packages
│
└── 📄 .gitignore
```

---

# 📸 Screenshots

The following screenshots showcase **selected screens and key parts of the DVLD system**.

> ℹ️ **Note:** DVLD is a large application containing many modules, screens, and workflows. The screenshots below represent only a **selection of the implemented functionality** and are not intended to cover the entire system.

<details>
<summary>🖼️ <strong>View Selected Screenshots</strong></summary>

<br>

## 🔐 Login

<img src="docs/Images/Login.png" alt="DVLD Login" width="900">

---

## 🏠 Main Screen

<img src="docs/Images/MainScreen.png" alt="DVLD Main Screen" width="900">

---

## 👥 Manage People

<img src="docs/Images/ManagePeople.png" alt="Manage People" width="900">

---

## 👤 Manage Users & Add User

<img src="docs/Images/ManageUserAndAddUser.png" alt="Manage Users and Add User" width="900">

---

## 🚗 Manage Drivers

<img src="docs/Images/ManageDriver.png" alt="Manage Drivers" width="900">

---

## 📝 Applications Menu

<img src="docs/Images/ApplicationsMenu.png" alt="Applications Menu" width="900">

---

## ⚙️ Account Settings

<img src="docs/Images/AccountSettings.png" alt="Account Settings" width="900">

</details>

> 🚀 **More screens and workflows can be explored by running the project locally.**

---

# 🚀 Getting Started

Follow the steps below to run the project locally.

## 1️⃣ Requirements

Before running the project, make sure you have:

- Windows
- Visual Studio
- .NET Framework 4.7.2
- SQL Server
- SQL Server Management Studio (recommended)

---

## 2️⃣ Clone the Repository

Open a terminal and run:

```bash
git clone YOUR_REPOSITORY_URL
```

Then:

```bash
cd DVLD-Project
```

> Replace `YOUR_REPOSITORY_URL` with the repository URL.

---

## 3️⃣ Open the Solution

Open the solution in **Visual Studio**.

The solution contains:

```text
DVLDDataAccessLayer
DVLDDataBusinessLayer
Project
```

Make sure all projects are loaded correctly.

---

## 4️⃣ Restore Packages

The project contains the required package configuration.

If Visual Studio does not restore the packages automatically:

```text
Right Click Solution
        ↓
Restore NuGet Packages
```

Then rebuild the solution.

---

## 5️⃣ Build the Project

From Visual Studio:

```text
Build
   ↓
Rebuild Solution
```

Make sure there are no build errors.

---

# 🗄️ Database Setup

The project uses **Microsoft SQL Server**.

The database scripts are located in:

```text
Database/
```

### Setup Steps

1. Open SQL Server Management Studio.
2. Connect to your SQL Server instance.
3. Open the SQL script from the `Database` folder.
4. Execute the script.
5. Verify that the database was created successfully.
6. Verify the connection string.
7. Run the application.

---

# 🔌 Connection Configuration

The Data Access Layer is responsible for database communication.

Before running the application, make sure the configured connection string matches your local SQL Server environment.

For example:

```text
Server=.;
Database=DVLD;
Integrated Security=True;
```

Depending on your SQL Server configuration, you may need to modify:

- Server name
- Database name
- Authentication method
- Username
- Password

> ⚠️ Never commit real production credentials to a public repository.

---

# 🔐 Login

After completing the database setup, launch the application.

The system starts from the Login screen.

Use a valid user account available in the database.

> 🔑 If a demo account is provided with the database, use its credentials for local testing.

---

# 🔄 Application Flow

A simplified view of the application architecture and workflow:

```text
                   USER
                     │
                     ▼
          ┌─────────────────────┐
          │   Presentation UI   │
          │     WinForms        │
          └──────────┬──────────┘
                     │
                     ▼
          ┌─────────────────────┐
          │   Business Layer    │
          │   Rules & Logic     │
          └──────────┬──────────┘
                     │
                     ▼
          ┌─────────────────────┐
          │ Data Access Layer   │
          │      ADO.NET        │
          └──────────┬──────────┘
                     │
                     ▼
          ┌─────────────────────┐
          │     SQL Server      │
          │    DVLD Database    │
          └─────────────────────┘
```

---

# 🎓 Learning Journey

This project represents the completion of **Course 19** in my learning journey.

The project took approximately **one month** of learning, implementation, debugging, and continuous improvement.

The goal was not only to write code, but to understand the complete development process:

```text
Learn
  ↓
Analyze
  ↓
Design
  ↓
Implement
  ↓
Debug
  ↓
Improve
  ↓
Build
```

During this journey, I learned how to work with a large project containing multiple interconnected modules and business rules.

---

# 💡 What This Project Taught Me

Working on DVLD helped me improve my skills in:

- System analysis
- Database design
- Object-Oriented Programming
- SQL Server
- ADO.NET
- Three-Tier Architecture
- Business logic
- Reusable code
- Debugging
- Problem solving
- Data validation
- Working with complex workflows
- Maintaining large projects

More importantly, it taught me that errors and challenges are a natural part of software development.

The important thing is to keep searching, learning, testing, and improving.

---

# 📚 Project Parts & Demonstrations

The project was developed through several major parts.

## 👤 Part 1 — User & Person Management

Includes:

- User Management
- Person Management

🎥 **Project Demonstration:**

[▶️ Watch Part 1 — User & Person Management](https://lnkd.in/eH7vBKQf)

---

## 📝 Part 2 — Applications & Tests

Includes:

- Manage Application Types
- Manage Test Types
- Add Local Driving License Application
- Schedule Test

🎥 **Project Demonstration:**

[▶️ Watch Part 2 — Applications & Tests](https://lnkd.in/exajbVaX)

---

## 🚘 Part 3 — Drivers & Licenses

Includes:

- Drivers
- International License
- Manage International Licenses
- Renew License
- Replace License for Damaged or Lost
- Detain License
- Release License
- Manage Detained Licenses

🎥 **Project Demonstration:**

[▶️ Watch Part 3 — Drivers & Licenses](https://lnkd.in/enDiX-hu)

---

## 🗄️ Database Design & Analysis

The project started with analyzing the system and designing the database before implementing the application.

🎥 **Database Design & Analysis:**

[▶️ View Database Design & Analysis](https://lnkd.in/eft_NT9v)

---

# 🧩 Why This Architecture?

Three-Tier Architecture was chosen to keep responsibilities separated.

### 🧹 Maintainability

Changes to one layer can be made without unnecessarily affecting the others.

### 🔄 Reusability

Business and Data Access functionality can be reused by different forms.

### 🧠 Organization

Each layer has a clear responsibility.

### 🧪 Easier Debugging

Problems can be isolated more easily between UI, business logic, and data access.

### 📈 Scalability

New functionality can be added without mixing all application responsibilities together.

---

# 🔮 Future Improvements

Possible future improvements include:

- 📊 Advanced reports and dashboards
- 📄 PDF report generation
- 📊 Excel export
- 🧪 Automated testing
- 🔐 Improved authentication and security
- 👥 More advanced permissions
- 🌐 Multi-language support
- 🎨 Further UI/UX improvements
- ⚡ Performance improvements
- 📝 More comprehensive audit logging

---

# 🙏 Special Thanks

A special thanks and appreciation goes to:

### Dr. Mohammed Abu-Hadhoud

for his great efforts, valuable content, and the **Programming Advices** roadmap that played a major role in this learning journey.

The practical approach of the course helped transform programming concepts from theoretical knowledge into practical experience through real projects.

---

# 📄 License

This project is licensed under the **MIT License**.

See the [LICENSE](LICENSE) file for more information.

---

# ⭐ Support

If you find this project interesting or useful:

⭐ Give the repository a star.

🍴 Fork the repository.

💡 Share your feedback.

🐛 Report issues.

---

<p align="center">

### 🚗 DVLD — Driving & Vehicle License Department

**C# • WinForms • ADO.NET • SQL Server • Three-Tier Architecture**

<br>

### 🚀 Learn • Build • Debug • Improve

<br>

Made with ❤️ through continuous learning and practice.

</p>

<p align="center">

<a href="#-dvld--driving--vehicle-license-department">⬆️ Back to Top</a>

</p>
