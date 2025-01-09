# TaskFlow

Organize projects, tasks, and collaborations efficiently with a simple and modern task management application.

🚀 **Features**
- **User Management:** Secure registration and authentication system.
- **Project Management:** Easily create, update, and manage projects.
- **Task Tracking:** Assign tasks, set priorities, track statuses (TODO, IN_PROGRESS, DONE), and manage deadlines.
- **Collaborative Comments:** Add comments to tasks for teamwork and collaboration.
- **Responsive UI:** Built with MudBlazor, providing a polished and modern user experience.
- **Database Optimization:** PostgreSQL triggers for automatic timestamp updates and optimized indexing.
- **RESTful API:** Extendable endpoints for programmatic interaction.
- **Clean Architecture:** Implements Repository Pattern for maintainability and scalability.

🛠️ **Technologies Used**

| Tech Stack       | Details                                                 |
|------------------|---------------------------------------------------------|
| Frontend         | Blazor Server (.NET 9.0), MudBlazor UI library          |
| Backend          | .NET Core with Entity Framework Core                    |
| Database         | PostgreSQL with migrations and triggers                 |
| Design Patterns  | Repository Pattern                                      |
| Version Control  | Git/GitHub                                              |
| API              | REST API for data interaction                           |

📂 **Database Schema**

🔑 **Key Entities**
1. **Users:**<br>
   Tracks user details (username, email, password_hash) and timestamps (created_at, updated_at).
2. **Projects:**<br>
   Represents projects with a name, description, and owner relationship.
3. **Tasks:**<br>
   Tracks task details such as title, description, status, priority, due_date, and relationships (assigned_to, project_id).
4. **Comments:**<br>
   Allows users to discuss tasks collaboratively.

🗄️ **PostgreSQL Highlights**
- **Task Status Enum:** (TODO, IN_PROGRESS, DONE)
- **Indexes:** Optimized for faster query performance.
- **Triggers:** Automates updated_at timestamp updates on row changes.

📦 **Installation and Setup**

**Prerequisites**
- .NET 9.0 SDK
- PostgreSQL
- Git

**Steps**
1. **Clone the repository:**
   ```bash
   git clone https://github.com/KBDevLab/taskflow.git
   cd taskflow

Set up the database:
Create a PostgreSQL database.
Update the connection string in appsettings.json.
Apply migrations using Entity Framework Core:
bash
dotnet ef database update
Run the application:
bash
dotnet run
Access the application:
Open your browser and navigate to http://localhost:5032.

🚀 Usage
Sign Up: Register for a new account or log in.
Create Projects: Add and organize projects in the dashboard.
Manage Tasks: Assign tasks, set priorities, track progress, and manage deadlines.
Collaborate: Use the comments feature for effective teamwork.

📝 License

This project is licensed under the MIT License.

✉️ Contact

For any questions or suggestions, feel free to reach out:
Email: K.B_Bryant@icloud.com
GitHub: KBDevLab
