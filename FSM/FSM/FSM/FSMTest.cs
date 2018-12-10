namespace FSM
{
    /// <summary>
    /// 怪物
    /// </summary>
    class Monster
    {
        private bool target;
        private int distance2Target = 800;
        private int targetHP = 3;
    }

    public class FSMTest
    {
        private const int STATE_WAIT = 0;
        private const int STATE_BATTLE = 1;
        private const int STATE_CHARSE = 2;

        private const string KEY_TARGET_EXIST = "tar";
        private const string KET_DISTANCE = "dis";
        private const string KEY_TARGET_DEAD = "tarDead";

        private const int ATTACK_RANGE = 300;
        public static void Test()
        {
            FiniteStateMachine<Monster> finiteStateMachine = new FiniteStateMachine<Monster>();

        }
    }
}
