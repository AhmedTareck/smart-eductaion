
Create Model from DB (Db first)
Scaffold-DbContext "server=DESKTOP-PTGVLQG;Database=MailSystem;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

Scaffold-DbContext "server=DESKTOP-RNT1C11;database=StudentTracker;uid=Ahmed;pwd=35087124567Ahmed;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -context "StudentTrackerContext" -Force

Scaffold-DbContext "server=LAPTOP-DVJT5BST;database=StudentTracker;uid=Ahmed;pwd=35087124567Ahmed;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force

public StudentTrackerContext(DbContextOptions<StudentTrackerContext> options) : base(options) { }


Abdala PC : 
Scaffold-DbContext "server=DESKTOP-4AI87L8\SQLEXPRESS;Database=Mail;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
-----------------------------------------

Code-First Approach

Enable-migrate
Add-Migration StudentTracker
update-database