Michel Musangu
ST10079108
PROG6212
POE PART 1
 
Contents
Documentation	3
UML Class Diagram	12
Project Plan	15


 

Documentation

For the web application, I’ve gone and chosen a logo for the Institution and chose colours that complement that logo. There is a navigation bar that will help users navigate the website. The buttons are big and blue, so they stand out quite easily. The word on the buttons make the purpose of the button very clear.
Homepage
Here we see the logo that I mentioned above, this logo has different variations of the colour blue, which is how I decided on the colour scheme. Below the Institution logo are other company logos, these logos are supposed to be other companies and businesses that are partnered with the institution. For now, I have specifically chosen free logos that do not represent an existing company. Users will be able to click the login button in the top left corner if they would like to login, or any one of the other links in the navigation bar in the top right corner. Currently only the Homepage and Login page has any content



Login as
From this page, users will have to select what their position in the Institution is in order to login. In the bottom left corner, you can see three buttons that handle this. There is also an image in the right with some text below it, this is simply eye candy for users.











Login form 
This page is very similar to the one above it, the only difference now is that there is a login form underneath the image, this means that the user clicked on one of the options in the bottom left corner. Now they will have to enter their details and press on the submit button to login.











Claims (for lecturers)
Assuming the user clicked the Lecturer option on the previous page and logged in successfully, they would be taken to this page. Here, the lecturer can fill out the claim form, select a supporting document and submit the form (the calculate button will display the appropriate total depending on the hours worked and hourly rate that the user entered), or if they submitted a claim in the past, they can press the “MY CLAIMS” button to navigate them to the next page where they can view their pending claims.









My Claims (for lecturers)
This page displays the lecturer’s pending claims and their status












Claims (for Programme Coordinator and Academic Manager)
This page is similar to the one above it, only this one is for the Academic Managers and Programme Coordinators. From here they are able to approve a claim.











Assumptions
•	Independent Contractor Lecturers have already been approved and have profiles; the sign-up/create account feature will therefore be completely omitted from the web application. Only the Login feature will be included. Fields for attributes like, Lecturer_ID ill be grabbed upon login so that the relevant information can be displayed and/or recorded. What I mean by this is, lets say for example a lecturer logs in to the web application, the application will display information related to that Lecturer_ID, their existing claims. The lecturer will then be able to make a claim and those details will be attached to their Lecturer_ID.
•	There is more than one active, IC lecturer, programme coordinator and academic manager.
•	When an IC lecturer is hired, they have profiles created for them that include a unique ID, which is then used as a PK/unique identifier for them in the database.
•	The Contract Monthly Claim System is a subsystem of an existing website, which outside users have access to, however the CMCS is only accessible to authorized personnel.
•	Besides the relational database, there will be a non-relational database used to store documents that are uploaded on the web application.
•	The programme coordinator and academic manager discuss the validity of a claim and come to a unanimous decision that then determines whether the claim is approved or not. There won’t be a situation where one approves the claim, and another does not.

Constraints
•	Currently, at this point in time my biggest issue is the non-relational database that will have to be used to store the documents that are uploaded on the web application.
•	The programme coordinator and academic manager have separate votes, so how will a situation where they have different votes be handled?























UML Class Diagram
 




The database I have designed has 4 entities, Lecturer, Claim, Academic Manager, and Programme Coordinator.
The Lecturer entity, which holds the information about each IC lecturer, has the following attributes:
•	Lecturer_ID – unique identifier for lecturers: int
•	First_Name – the first name of the lecturer: varchar2
•	Surname – the surname of the lecturer: varchar2
•	Phone_Number – the phone number of the lecturer: int
•	Email – the email address of the lecturer: varchar2
•	Address – the addresss of the lecturer: varchar2

The Claim entity, which holds the details of each claim, has the following attributes:
•	Claim_ID – unique identifier for claims: int
•	Lecturer_ID – foreign key referencing Lecturer table
•	Programme_Coordinator_ID– foreign key referencing Programme_Coordinator table
•	Academic_Manager_ID – foreign key referencing Academic_Manager table
•	Hours_Worked – the number of hours that the lecturer worked: int
•	Hourly_Rate – the rate per hour: int
•	Description – optional information to describe possible anomaly: varchar2
•	Date_Submitted – date that the claim was submitted: varchar2
•	Date_Approved – date that the claim was approved: varchar2

The Programme_Coordinator entity, which holds the information about each programme coordinator, has the following attributes:
•	Programme_Coordinator_ID – unique identifier for lecturers: int
•	First_Name – the first name of the programme coordinator: varchar2
•	Surname – the surname of the programme coordinator: varchar2
•	Phone_Number – the phone number of the programme coordinator: int
•	Email – the email address of the programme coordinator: varchar2
•	Address – the addresss of the programme coordinator: varchar2

The Academic_Manager entity, which holds the information about each academic manager, has the following attributes:
•	Academic_Manager_ID – unique identifier for academic manager: int
•	First_Name – the first name of the academic manager: varchar2
•	Surname – the surname of the academic manager: varchar2
•	Phone_Number – the phone number of the academic manager: int
•	Email – the email address of the academic manager: varchar2
•	Address – the addresss of the academic manager: varchar2






















Project Plan
Contract Monthly Claim System

The goal of this project is to deliver a system that facilitates the process submitting and approving claims. This is will be achieved through a well-designed web application that makes use of a relational database.

Tasks
Task 1 – Scrutinize Project Requirements
This task involves analyzing the project and getting a better understanding of the requirements, scope, constraints and so on. Entities and attributes for the UML diagrams are identified, no relationships are included yet. Very simple wireframes for the UI design are drawn.
Task 2 – Database Design
Now that the Entities and their attributes have been identified, the final UML Diagram can be designed. All relationships and multiplicities have been added. The Database will be designed electronically, using  an online design tool.
Task 3 – UI Design
The Entities and attributes identified in task 1 now allow us to come up with a UI that ensures that when the web application is developed, all of these attributes will be given a value. The UI should be user-friendly, functional, and intuitive. Things like images, colour schemes, and fonts are chosen and added. The UI will be designed electronically, using a software design tool.
Task 4 – Code the web application
Now that we have a database design and a UI design, we can finally proceed to coding the web application. At this point, the web application does not need to be functional. The UI will be prioritized at this point. The web application will be coded using an IDE.

Task 5 – Version Control
This involves making updates/changes to the web application where necessary.

Dependencies – Software
•	Draw.io will be used to design the database
•	Figma will be used to design the UI 
•	Visual Studio 2022 will be used to code the web application
•	Microsoft Word will be used for the documentation

Timeline

Task 1 – 3 days
Start: 10 August 2024
End: 12 August 2024

Task 2 - 2 days
Start: 13 August 2024
End: 14 August 2024

Task 3 - 5 days
Start: 15 August 2024
End: 19 August 2024

Task 4 – 7 days
Start: 20 August 2024
End: 26 August 2024

Task 5 – 15 Days
Start: 27 August 2024
End: 10 August 2024






References:
Reference 1: 
w3schools. (2023) How to: Responsive top navigation. Available at: https://www.w3schools.com/howto/howto_js_topnav_responsive.asp (Accessed: 7 September 2024).
