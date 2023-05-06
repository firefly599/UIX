using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;


namespace UIX
{
    public class Person
    {
        public string Name;
        public string FirstName;
        public string LastName;
        public string Title;
        public string email;
        public string staff;

        public Person(string name, string title, string pstaff = null, string email=null, string firstname = null, string lastname = null)
        {
            Name = name;
            if (firstname == null)
            {
                FirstName = name.Split(' ')[0];
            }
            else
            {
                FirstName = firstname;
            }

            if (lastname == null)
            {
                LastName = name.Split(' ')[0];
            }
            else
            {
                LastName = lastname;
            }

            Title = title;
            email = email;
            staff = pstaff;
        }
    }

    public class Meeting
    {
        public int day;
        public int month;
        public int hour;
        public int minute;

        public string staff;
        public string student;

        public Meeting(int pday, int pmonth, int phour, int pminute, string pstaff, string pstudent)
        {
            day = pday;
            month = pmonth;
            hour = phour;
            minute = pminute;
            staff = pstaff;
            student = pstudent;
        }
    }

    public class Messages
    {
        public string staff;
        public string student;
        public int id;
        public List<string> messages;

        public Messages(string staff, string student, List<string> messages, int id)
        {
            this.staff = staff;
            this.student = student;
            this.messages = messages;
            this.id = id;
        }

        public void AddMsg(string text, string sender)
        {
            string toAdd = sender + ": " + text;
            messages.Add(toAdd);
        }
    }

    public static class DataManager
    {
        static public List<Person> data = new ();
        static public List<Meeting> meetings = new ();
        static public List<Messages> messages = new ();
        static public Person activeUser;

        static public void FillData()
        {
            Person person = new Person("Mike Hobs", "Professor");
            data.Add(person);
            person = new Person("Cameron Atkinson", "Student", "Mike Hobs");
            data.Add(person);
            person = new Person("Rias Grimory", "Student", "Mike Hobs");
            data.Add(person);
            person = new Person("Ina Bael", "Student", "Yeong Jin");
            data.Add(person);
            person = new Person("Gu Obs", "Professor");
            data.Add(person);
            person = new Person("Siahn Park", "Student", "Gu Obs");
            data.Add(person);
            person = new Person("Kim Sung", "Student", "Yeong Jin");
            data.Add(person);
            person = new Person("Yeong Jin", "Professor");

            data.Add(person);

            meetings.Add(new Meeting(4, 5, 10, 20, "Mike Hobs", "Cameron Atkinson"));
            meetings.Add(new Meeting(4, 7, 10, 40, "Mike Hobs", "Rias Grimory"));
            meetings.Add(new Meeting(4, 5, 10, 20, "Gu Obs", "Siahn Park"));
            meetings.Add(new Meeting(4, 5, 10, 20, "Yeong Jin", "Ina Bael"));
            meetings.Add(new Meeting(4, 5, 10, 20, "Yeong Jin", "Kim Sung"));

            List<string> mess = new List<string>();
            mess.Add("Ina Bael: Hi when can i meet you?");
            mess.Add("Mike Hobs: Let me check my calendar and get back to you ");   
            messages.Add(new Messages("Mike Hobs", "Ina Bael", mess, 0));
        }

        static public void Login(string username, string password)
        {
            foreach (Person user in data)
            {
                if (username == user.Name)
                {
                    activeUser = user;
                }
            }
        }

        static public void SignUp(string username, string password, string email, string firstname, string lastname)
        {
            Person newUser = new (username, password, "null", email, firstname, lastname);
            data.Add(newUser);
            activeUser = newUser;
        }

        static public void Logout()
        {
            activeUser = null;
        }

        static public void CreateMeeting(string student, string staff, int day, int month, int hour, int minute)
        {
            meetings.Add(new Meeting(day, month, hour, minute, staff, student));
        }

        static public void CreateMessage(string user, string staff, string text)
        {
            List<string> mess = new List<string>();
            mess.Add(text);
            messages.Add(new Messages(user, staff, mess, messages.Count()));
        }

        static public List<Person> MeetingView()
        {
            return data;
        }

        static public List<Person> HomeView()
        {
            return data;
        }
    }
}