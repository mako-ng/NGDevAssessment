-------------------------------
 Next Gen Developer Assessment
-------------------------------

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
