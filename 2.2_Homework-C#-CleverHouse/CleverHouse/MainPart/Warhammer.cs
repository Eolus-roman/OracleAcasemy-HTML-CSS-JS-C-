using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverHouse
{
    public class Warhammer : Device, IUse, ILevelChange
    {
        private BattlePlace battlefront;
        private int eldar; //  для бросков эльдар
        private int chaos;// для бросков хаоситов
        private int emp;// для бросков Имперской Гвардии
        private int orc;// для бросков орков
        private int tau;// для бросков Тау
        public string Report {get; set;}
        public Warhammer(bool status, string report)
            : base(status)
        {
                        Report = report;
        }
        public virtual int Dice()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int x = rnd.Next(1, 12);
            System.Threading.Thread.Sleep(1);
            return x;
        }
        public void FirstLvl() //космос
        {
            battlefront = BattlePlace.Space;
        }
        public void SecondLvl() //востание
        {
            battlefront = BattlePlace.Riot;
        }
        public void ThirdLvl() //битва за планету
        {
            battlefront = BattlePlace.BattleForPlanet;
        }
        public void FourthLvl() //прорыв хаоса
        {
            battlefront = BattlePlace.ChaosBreakthrough;
        }
        public void Apply()
        {
            if (battlefront == BattlePlace.Space)
            {
                emp = Dice();
                orc = Dice();
                if (orc > emp)
                {
                    Report = "Игрок! В этой битве победили орки. Так сказать, бальшие парни наваляли мелким юдишкам! Waaaahhhh!!!";
                }
                else if (orc < emp)
                {
                    Report = "Игрок! В этой битве Имперская Гвардия одержала победу! Так сказать, показали мерзким ксеносам свое место!!";
                }
                else
                {
                    Report = "Игрок обе стороны были слишком истощены и отступили с поле боя.";
                }
            }
            if (battlefront == BattlePlace.Riot)
            {
                emp = Dice();
                chaos = Dice();
                if (chaos > emp)
                {
                    Report = "Игрок! В этой битве победили хаоситы. Боюсь этот регион пал жертвой ереси.";
                }
                else if (chaos < emp)
                {
                    Report = "Игрок! В этой битве Имперская Гвардия одержала победу! Ересь не пройдет!";
                }
                else
                {
                    Report = "Игрок из-за затяжных боев на это поле обратила внимание Инквизиция. Боюсь эта планета больше не пригодна для жизни";
                }
            }
            if (battlefront == BattlePlace.BattleForPlanet)
            {
                emp = Dice();
                tau = Dice();
                if (tau > emp)
                {
                    Report = "Игрок! Эта планета познала всю радость Великого Блага Тау!";
                }
                else if (tau < emp)
                {
                    Report = "Игрок! На эту планету пришел закон и порядок, а так же наша искренняя вера в Бога-Императора!!";
                }
                else
                {
                    Report = "Игрок, из-за затяжных боев на это поле обратила внимание Инквизиция. Боюсь эта планета больше не пригодна для жизни";
                }
            }
            if (battlefront == BattlePlace.ChaosBreakthrough)
            {
                emp = Dice();
                chaos = Dice();
                eldar = Dice();
                if (emp < chaos && chaos > eldar)
                {
                    Report = "Игрок! Теперь здесь установлена власть Великой Четверки!";
                }
                else if (chaos < emp && emp > eldar)
                {
                    Report = "Игрок! Имперская Гвардия сумела отбить прорыв хаоса!";
                }
                else if (chaos < eldar && eldar > emp)
                {
                    Report = "Игрок! Эльдары показали свое место мон-кей.";
                }
                else
                {
                    Report = "Игрок! Из-за аномалии в Имматериуме наши провидцы не смогли узнать исход битвы";
                }
            }
        }
        public override string ToString()
        {
            string status;
            if (Status)
            {
                status = "влючена";
            }
            else
            {
                status = "выключена";
            }
            string mode;
            if (battlefront == BattlePlace.Space)
            {
                mode = "Бескрайний Космос";
            }
            else if (battlefront == BattlePlace.Riot)
            {
                mode = "Зерна Ереси";
            }
            else if (battlefront == BattlePlace.ChaosBreakthrough)
            {
                mode = "Прорыв Хаоса";
            }
            else if (battlefront == BattlePlace.BattleForPlanet)
            {
                mode = "Битва за планету";
            }
            else
            {
                mode = "не определен";
            }
            return "\nСостояние: " + status + "; Поле боя: " + mode + ";\nОтчет о битве: " + Report + ";\n";
        }

    }
}
