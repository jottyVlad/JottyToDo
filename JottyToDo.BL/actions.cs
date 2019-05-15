using System;

namespace JottyToDo.BL
{
    [Serializable]
    public class Doing
    {
        public DateTime PostTime { get; }
        public DateTime TimeLead { get; }
        public string action { get; }
        public Doing(DateTime leadtime, string act)
        {
            if (leadtime < DateTime.Now) throw new ArgumentException("Время окончания не может быть меньше нынешнего времени!", nameof(leadtime));
            if (act == "") throw new ArgumentException("Действие не может быть пустым!", nameof(act));
            PostTime = DateTime.Now;
            TimeLead = leadtime;
            action = act;
        }
    }
    [Serializable]
    public class NeedToDo
    {
        public DateTime PostTime { get; }
        public DateTime WhenStart { get; }
        public string action { get; }
        public NeedToDo(DateTime whenstart, string act)
        {
            if (whenstart < DateTime.Now) throw new ArgumentException("Время начала действия не может быть меньше нынешнего времени!", nameof(whenstart));
            if (act == "") throw new ArgumentException("Действие не может быть пустым!", nameof(act));
            PostTime = DateTime.Now;
            WhenStart = whenstart;
            action = act;
        }
    }
    [Serializable]
    public class Done
    {
        public DateTime PostTime { get; }
        public DateTime WhenFinish { get; }
        public string action { get; }
        public Done(DateTime whenfinish, string act)
        {
            if (whenfinish > DateTime.Now) throw new ArgumentException("Время окончания действия не может быть больше нынешнего времени!", nameof(whenfinish));
            if (act == "") throw new ArgumentException("Действие не может быть пустым!", nameof(act));
            PostTime = DateTime.Now;
            WhenFinish = whenfinish;
            action = act;
        }
    }
}
