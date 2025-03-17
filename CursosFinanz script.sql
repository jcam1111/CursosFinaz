-- Create the Students table
CREATE TABLE Students (
    StudentID INT IDENTITY(1,1) PRIMARY KEY, 
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    BirthDate DATE,
    Email NVARCHAR(100),
    CreatedAt DATETIME DEFAULT GETDATE(),
    ModifiedAt DATETIME DEFAULT GETDATE()
);

-- Create the Teachers table
CREATE TABLE Teachers (
    TeacherID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    Email NVARCHAR(100),
    CreatedAt DATETIME DEFAULT GETDATE(),
    ModifiedAt DATETIME DEFAULT GETDATE()
);

-- Create the Courses table
CREATE TABLE Courses (
    CourseID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Description NVARCHAR(255),
    TeacherID INT,
    CreatedAt DATETIME DEFAULT GETDATE(),
    ModifiedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID) -- Relationship with Teachers
);

-- Create the Grades table
CREATE TABLE Grades (
    GradeID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT,
    CourseID INT,
    Grade DECIMAL(5,2),
    CreatedAt DATETIME DEFAULT GETDATE(),
    ModifiedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID), -- Relationship with Students
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID) -- Relationship with Courses
);
