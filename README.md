# 🚗 DVLD — Driving & Vehicle License Department

<p align="center">

  <img src="docs/Images/MainScreen.png" width="900">

</p>

<h3 align="center">
  Driving & Vehicle License Department Management System
</h3>

<p align="center">
  A complete desktop application for managing people, users, applications, tests, drivers, and driving licenses.
</p>

<p align="center">

![C#](https://img.shields.io/badge/Language-C%23-512BD4?style=for-the-badge&logo=csharp&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![WinForms](https://img.shields.io/badge/UI-WinForms-0078D4?style=for-the-badge)
![ADO.NET](https://img.shields.io/badge/Data%20Access-ADO.NET-68217A?style=for-the-badge)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Architecture](https://img.shields.io/badge/Architecture-Three--Tier-success?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-yellow?style=for-the-badge)

</p>

---

## 📌 Overview

**DVLD (Driving & Vehicle License Department)** is a comprehensive desktop application developed using **C# and Windows Forms** to simulate a real-world Driving & Vehicle License Department.

The project focuses not only on implementing features, but also on understanding how to analyze a real system, design its database, organize the application into separate layers, and connect all components together to build a maintainable and scalable software solution.

The system covers multiple workflows related to:

- 👤 People Management
- 🔐 User Management
- 📝 Applications
- 🧪 Tests
- 🚗 Drivers
- 🪪 Driving Licenses
- 🌍 International Licenses
- ⚠️ License Detention
- 🔄 License Renewal & Replacement
- ⚙️ Account Management

> 🚀 **This project is part of my learning journey through Programming Advices and was developed as a practical application of the concepts learned throughout Course 19.**

---

# ✨ Key Features

## 👤 People Management

Manage and maintain information about people registered in the system.

### Features

- ➕ Add new people
- 📋 View people
- ✏️ Update personal information
- 🔎 Search and filter people
- 🗑️ Manage person records
- 🧩 Reusable person-related components

---

## 👥 User Management

Complete management of system users and their accounts.

### Features

- ➕ Add new users
- 📋 View users
- ✏️ Update user information
- 🔐 Manage user credentials
- ✅ Activate users
- ⛔ Deactivate users
- 👤 Link users with people
- 🔑 Control access to system functionality

---

## 📝 Applications Management

The system supports different types of applications and manages their complete lifecycle.

### Includes

- 📋 Manage Application Types
- 📝 Create applications
- 🔎 View application information
- 🔄 Manage application status
- 👤 Link applications with people
- 💳 Manage application fees
- 📅 Manage application-related workflows

---

## 🧪 Tests Management

The system provides functionality for managing different driving-related tests.

### Includes

- 🧪 Manage Test Types
- 📋 Schedule tests
- 📅 Manage test appointments
- 🔎 View test information
- 📊 Track test results
- 🔄 Manage test-related application workflows

---

## 🚗 Local Driving License

The system supports the complete workflow for issuing local driving licenses.

### Workflow

```text
Person
   ↓
Application
   ↓
Test Scheduling
   ↓
Tests
   ↓
Application Completion
   ↓
Driver
   ↓
Driving License
```
---
The system connects the different stages together to simulate a real licensing process.
---
🚘 Drivers Management

The system provides functionality for managing registered drivers.

Features
👤 View drivers
🔎 Search drivers
📋 Display driver information
🪪 View driver's licenses
🌍 Manage international licenses
🔗 Connect drivers with their related people and licenses
---
🪪 Driving Licenses

The system supports multiple license operations.

Supported Operations
🆕 Issue License
🔄 Renew License
♻️ Replace Lost License
🛠️ Replace Damaged License
🔎 View License Information
📋 Manage License Records
---
🌍 International Driving License
The system also supports international driving licenses.

Features
🌍 Issue International License
🔎 View International License
📋 Manage International Licenses
👤 Link international licenses with drivers
📅 Manage license validity

---
⚠️ License Detention
The project includes a complete workflow for handling detained licenses.

Features
🔒 Detain License
📋 Manage Detained Licenses
🔎 Search detained licenses
🔓 Release License
📝 Record detention information
💰 Manage applicable fees

---
🔄 License Renewal & Replacement
The system supports different license lifecycle operations.

Renewal
🔎 Find existing license
📅 Validate license status
🔄 Renew license
💰 Calculate applicable fees
📝 Create renewal records

Replacement
🛠️ Replace damaged license
🚨 Replace lost license
📝 Record replacement information
💰 Manage replacement fees

---
🏗️ Architecture
The application follows a Three-Tier Architecture to separate responsibilities, improve maintainability, and keep the code organized.

┌─────────────────────────────────────────┐
│         🖥️ Presentation Layer           │
│              Windows Forms              │
│                                         │
│        User Interface & Interaction     │
└────────────────────┬────────────────────┘
                     │
                     ▼
┌─────────────────────────────────────────┐
│           ⚙️ Business Layer             │
│                                         │
│        Business Rules & Logic           │
└────────────────────┬────────────────────┘
                     │
                     ▼
┌─────────────────────────────────────────┐
│        🗄️ Data Access Layer             │
│                                         │
│              ADO.NET                    │
│       Database Communication             │
└────────────────────┬────────────────────┘
                     │
                     ▼
┌─────────────────────────────────────────┐
│             💾 SQL Server               │
│                                         │
│              DVLD Database               │
└─────────────────────────────────────────┘

🔹 Presentation Layer

Responsible for:

User Interface
Windows Forms
User interaction
Input validation
Displaying information
Calling the Business Layer
🔹 Business Layer

Responsible for:

Business rules
Application logic
Validation
Processing operations
Connecting the Presentation Layer with the Data Access Layer
🔹 Data Access Layer

Responsible for:

Database communication
CRUD operations
Executing SQL commands
Retrieving data
Updating database records
Using ADO.NET
🔹 Database
SQL Server is used to store and manage the application's data.

---
🗂️ Project Structure
DVLD-Project
│
├── 📁 DVLDDataAccessLayer
│   └── Database access and ADO.NET operations
│
├── 📁 DVLDDataBusinessLayer
│   └── Business logic and application rules
│
├── 📁 Database
│   └── SQL Server database scripts
│
├── 📁 Project
│   └── Presentation Layer / Windows Forms
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
│   └── Project dependencies
│
├── 📄 .gitignore
└── 📄 Solution.sln

---
🛠️ Technologies & Tools

| Technology              | Purpose                     |
| ----------------------- | --------------------------- |
| C#                      | Main programming language   |
| .NET Framework 4.7.2    | Application framework       |
| Windows Forms           | Desktop User Interface      |
| ADO.NET                 | Database communication      |
| SQL Server              | Database management         |
| OOP                     | Object-Oriented Programming |
| Three-Tier Architecture | Application architecture    |
| Visual Studio           | Development environment     |
| Git & GitHub            | Version control             |


---
🧠 Concepts Applied

This project was built to apply practical software development concepts, including:

Object-Oriented Programming
Encapsulation
Abstraction
Inheritance
Polymorphism
Three-Tier Architecture
Separation of Concerns
Database Design
Relational Database Concepts
SQL Server
ADO.NET
CRUD Operations
Transactions
Validation
Error Handling
Reusable Components
Clean & Organized Code
Problem Solving

---
## 📸 Screenshots

The following screenshots showcase selected screens and key features of the DVLD system.

ℹ️ **Note:** DVLD is a large system containing many modules, screens, and workflows.

The screenshots below represent only a selection of the implemented functionality and are not intended to cover the entire application.

<details>
<summary>🖼️ <strong>View Selected Screenshots</strong></summary>
<br>

🔐 **Login**

<img src="docs/Images/Login.png" width="900">

🏠 **Main Screen**

<img src="docs/Images/MainScreen.png" width="900">

👥 **Manage People**

<img src="docs/Images/ManagePeople.png" width="900">

👤 **Manage Users & Add User**

<img src="docs/Images/ManageUserAndAddUser.png" width="900">

🚗 **Manage Drivers**

<img src="docs/Images/ManageDriver.png" width="900">

📝 **Applications Menu**

<img src="docs/Images/ApplicationsMenu.png" width="900">

⚙️ **Account Settings**

<img src="docs/Images/AccountSettings.png" width="900">

</details>

🚀 *More screens and workflows can be explored by running the project locally.*

---
## 🚀 Getting Started

Follow the steps below to run the project locally.

### 1️⃣ Clone the Repository

```bash
git clone [https://github.com/aimanameenmohammed/DVLD-Project.git](https://github.com/aimanameenmohammed/DVLD-Project.git)

Then open the project folder:

```bash
cd DVLD-Projec




