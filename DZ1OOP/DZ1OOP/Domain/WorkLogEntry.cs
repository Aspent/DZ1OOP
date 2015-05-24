using System;

namespace DZ1OOP.Domain
{
    class WorkLogEntry
    {
        #region Fields

        private readonly DateTime _dateTime;
        private readonly string _description;
        private readonly string _responsible;
        private readonly TimeSpan _timeSpent;

        #endregion

        #region Constructor

        public WorkLogEntry(DateTime dateTime, string description, string responsible, TimeSpan timeSpent)
        {
            _dateTime = dateTime;
            _description = description;
            _responsible = responsible;
            _timeSpent = timeSpent;
        }
       
        #endregion

        #region Methods

        //public static WorkLogEntry CreateFromConsole()
        //{
        //    var dateTime = DateTime.Now;
        //    const string description = "Работа над изделием прошла нормально";
        //    const string responsible = "Иванов Петр Сергеевич";
        //    Console.WriteLine("Введите время, затраченное на изготовление изделия (в формате час:минута:секунда)");
        //    var buf = Console.ReadLine().Split(':');
        //    var timeSpent = new TimeSpan(int.Parse(buf[0]), int.Parse(buf[1]), int.Parse(buf[2]));          
        //    return new WorkLogEntry(dateTime, description, responsible, timeSpent);
        //}

        #endregion

        #region Properties

        public DateTime AdditionDateTime
        {
            get { return _dateTime; }
        }

        public string Description
        {
            get { return _description; }
        }

        public string Responsible
        {
            get { return _responsible; }
        }

        public TimeSpan TimeSpent
        {
            get { return _timeSpent; }
        }

        #endregion
    }
}
