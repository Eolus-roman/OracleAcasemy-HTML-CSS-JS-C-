using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleverHouse
{
    public class Warhammer : Device, IGetDice, IBattle, IChooseBattlefield
    {
        private BattlePlace battlefront;

        private string report = "Игрок, ты еще не сыграл ни одной битвы!";
        private int eldar; //  для бросков эльдар
        private int chaos;// для бросков хаоситов
        private int emp;// для бросков Имперской Гвардии
        private int orc;// для бросков орков
        private int tau;// для бросков Тау
        public bool Toys { get; set; }
        public Warhammer(bool status, bool toys)
            : base(status)
        {
            Toys = toys;
        }

        public virtual int Dice()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int x = rnd.Next(1, 12);
            System.Threading.Thread.Sleep(1);
            return x;
        }
        public void DoSpace() //космос
        {
            battlefront = BattlePlace.Space;
        }
        public void DoRiot() //востание
        {
            battlefront = BattlePlace.Riot;
        }
        public void DoBattleForPlanet() //битва за планету
        {
            battlefront = BattlePlace.BattleForPlanet;
        }
        public void DoChaosBreakthrough() //прорыв хаоса
        {
            battlefront = BattlePlace.ChaosBreakthrough;
        }
        public void DoBattleForWorldHive() //Битва за Мир-Улей
        {
            battlefront = BattlePlace.BattleForWorldHive;
        }

        public void PlayBattle()
        {
            if (battlefront == BattlePlace.Space)
            {
                emp = Dice();
                orc = Dice();
                if (orc > emp)
                {
                    report = "Игрок! В этой битве победили орки. Так сказать, бальшие парни наваляли мелким юдишкам! Waaaahhhh!!!";
                }
                else if (orc < emp)
                {
                    report = "Игрок! В этой битве Имперская Гвардия одержала победу! Так сказать, показали мерзким ксеносам свое место!!";
                }
                else
                {
                    report = "Игрок обе стороны были слишком истощены и отступили с поле боя.";
                }
            }
            if (battlefront == BattlePlace.Riot)
            {
                emp = Dice();
                chaos = Dice();
                if (chaos > emp)
                {
                    report = "Игрок! В этой битве победили хаоситы. Боюсь этот регион пал жертвой ереси.";
                }
                else if (chaos < emp)
                {
                    report = "Игрок! В этой битве Имперская Гвардия одержала победу! Ересь не пройдет!";
                }
                else
                {
                    report = "Игрок из-за затяжных боев на это поле обратила внимание Инквизиция. Боюсь эта планета больше не пригодна для жизни";
                }
            }
            if (battlefront == BattlePlace.BattleForPlanet)
            {
                emp = Dice();
                tau = Dice();
                if (tau > emp)
                {
                    report = "Игрок! Эта планета познала всю радость Великого Блага Тау!";
                }
                else if (tau < emp)
                {
                    report = "Игрок! На эту планету пришел закон и порядок, а так же наша искренняя вера в Бога-Императора!!";
                }
                else
                {
                    report = "Игрок, из-за затяжных боев на это поле обратила внимание Инквизиция. Боюсь эта планета больше не пригодна для жизни";
                }
            }
            if (battlefront == BattlePlace.ChaosBreakthrough)
            {
                emp = Dice();
                chaos = Dice();
                eldar = Dice();
                if (emp < chaos && chaos > eldar)
                {
                    report = "Игрок! Теперь здесь установлена власть Великой Четверки!";
                }
                else if (chaos < emp && emp > eldar)
                {
                    report = "Игрок! Имперская Гвардия сумела отбить прорыв хаоса!";
                }
                else if (chaos < eldar && eldar > emp)
                {
                    report = "Игрок! Эльдары показали свое место мон-кей.";
                }
                else
                {
                    report = "Игрок! Из-за аномалии в Имматериуме наши провидцы не смогли узнать исход битвы";
                }
            }
            if (battlefront == BattlePlace.BattleForWorldHive)
            {
                eldar = Dice();
                orc = Dice();
                if (eldar > orc)
                {
                    report = "Игрок! Эльдары отстояли свой Мир-Улей!";
                }
                else if (eldar < orc)
                {
                    report = "Игрок! Бальшие парни разобрались с остроухими!";
                }
                else
                {
                    report = "Игрок! Из-за аномалии в Имматериуме наши провидцы не смогли узнать исход битвы";
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
            else if (battlefront == BattlePlace.BattleForWorldHive)
            {
                mode = "Нападение на Мир-Улей";
            }
            else if (battlefront == BattlePlace.BattleForPlanet)
            {
                mode = "Битва за планету";
            }
            else
            {
                mode = "не определен";
            }
            return "\nСостояние: " + status + "; Поле боя: " + mode + ";\nОтчет о битве: " + report + ";\n";
        }

    }
}
