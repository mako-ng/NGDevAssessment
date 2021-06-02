-------------------------------
 Next Gen Developer Assessment
-------------------------------

-------------------------
Baker Griffith's Changes:
-------------------------

New structure:
There now exists an Angular project within the root file structure (Angular-UI). This was built to replicate the existing functionality of the MVC site and
to implement the desired new functionality. There is also a new forwar-facing API structure (formcontroller.cs) which contains endpoints for all SCRUM needs
requested by the new UI.

To run:
Angular UI: Run the existing .NET project. Then `cd Angular-UI`, install the dependencies using `npm i` (make sure node is installed), and run using `ng serve`. Navigate to http://localhost:4200/ for viewing.

Implemented:
UI
A basic Angular material form UI which includes a date selector, numerical hours input, and buttons for various function (deletion, add entry, run payroll).
All aspects populate dynamically based on input (deletion happens in real-time, etc.). When you submit the payroll, it runs a request through the front facing API
and shows a popup of the calculation at the bottom of the screen. This appears for 8 seconds and is closeable.

API
As oppsed to a standard MVC controller, a new ASP Web API controller was constructed for the front end to use. This routes requests to the necesarry endpoints
which then utilizes the DB functions in the TimesheetService for data read/write. Exception handling was added to the service as well as to each action method
in the new controller, they will return 404s when bad requests are committed. Pertaining to the bonus points section, when a request comes in for the same date,
the previous value is updated with the new data.

This should cover all of the required functionality as well as bonus points and then also demonstrate an understanding of JavaScript and frameworks.


Welcome to the Next Gen Developer Assessment.  The goal of this exercise is for you, the developer, to show off your full stack .NET skills.  In this solution, you will find stubbed out for you a very basic time keeping web site.  The solution is built on .NET Core 3.1 and uses a simple home-grown database "context" which reads/writes a JSON file.  If you need to change anything to get the project up and running (e.g. the version of .NET Core because you do not have 3.1 installed), feel free to do so.


REQUIRED tasks to complete:
---------------------------
1. Implement the incomplete methods of TimesheetService.cs
   
   a.) AddTimeEntry: should add a new time entry to the database
   
   b.) DeleteTimeEntry: should delete the time entry
   
   c.) RunPayroll: run a calculation of the time entries.  We are looking for a count of regular hours and overtime hours.

 Regular hours are all hours worked up until 40 for the work week.
 Overtime hours are all hours worked over 40 for the work week.
     
 For this exercise, a "work week" is considered seven consecutive days, starting on Sunday at midnight.

         Example 1                 Example 2
     -----------------         -----------------
      Mo 1/20 8 hours	         	Fr 1/17 8 hours
      Tu 1/21 8 hours           Sa 1/18 8 hours
      We 1/22 8 hours           Su 1/19 8 hours 
      Th 1/23 8 hours           Mo 1/20 8 hours
      Fr 1/24 8 hours           Tu 1/21 8 hours
      Sa 1/25 8 hours           We 1/22 8 hours

      Regular hours = 40        Regular hours = 48
      Overtime hours = 8        Overtime hours = 0

2. Make the UI work.  You'll notice the main page of the site has a stubbed-out UI and buttons that don't do anything!  Feel free to alter the UI as much as you want, so long as it implements all the methods of ITimesheetService (add/delete time entries and run payroll)


BONUS points:
-------------
1. Add validation to prevent two entries on the same day
2. Use jQuery or other JavaScript frameworks to make ajax calls rather than full form POSTs and page re-rendering


Lastly, please do not spend more than a few hours on this project.  We are trying to see to what kind of a "full-stack" developer you are and where your strengths lie, not if you are willing to spend a week to make things code-perfect and ready for a code review at Microsoft.


When you are finished, please submit a pull request of your changes and send us an email.

Thanks, and have fun!
