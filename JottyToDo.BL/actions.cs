using System;

namespace JottyToDo.BL
{
    [Serializable]
    public abstract class ActionsForm
    {
        public DateTime PostTime { get; protected set; }
        public DateTime TimeLead { get; protected set; }
        public string action { get; protected set; }
    }

    [Serializable]
    public class Doing : ActionsForm
    {
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
    public class NeedToDo : ActionsForm
    {
        public NeedToDo(DateTime whenstart, string act)
        {
            if (whenstart < DateTime.Now) throw new ArgumentException("Время начала действия не может быть меньше нынешнего времени!", nameof(whenstart));
            if (act == "") throw new ArgumentException("Действие не может быть пустым!", nameof(act));
            PostTime = DateTime.Now;
            TimeLead = whenstart;
            action = act;
        }
    }
    [Serializable]
    public class Done : ActionsForm
    {
        public Done(DateTime whenfinish, string act)
        {
            if (whenfinish > DateTime.Now) throw new ArgumentException("Время окончания действия не может быть больше нынешнего времени!", nameof(whenfinish));
            if (act == "") throw new ArgumentException("Действие не может быть пустым!", nameof(act));
            PostTime = DateTime.Now;
            TimeLead = whenfinish;
            action = act;
        }
    }
}
