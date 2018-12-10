namespace FSM
{
   

    public class FSMTest
    {
       
        public static void Test()
        {
            FiniteStateMachine<Monster> monsterStateMachine = new FiniteStateMachine<Monster>(new MonsterStateProcesser<Monster>(),new MonsterOnStateChangeProcess<Monster>());
            FiniteState<Monster> wait = monsterStateMachine.AddState(Monster.STATE_WAIT);
            wait.SetStateExecutor(new MonsterWaitExecutor<Monster>());
            FiniteState<Monster> battle = monsterStateMachine.AddState(Monster.STATE_BATTLE);
            battle.SetStateExecutor(new MonsterBattleExecutor<Monster>());
            FiniteState<Monster> charse = monsterStateMachine.AddState(Monster.STATE_CHARSE);
            charse.SetStateExecutor(new MonsterCharseExecutor<Monster>());
            monsterStateMachine.setDefaultState(wait);

            // 待机>战斗
            // 存在目标
            FiniteStateTransaction<Monster> wait2Battle = monsterStateMachine.AddTranscation(wait, battle);
            wait2Battle.AddCondition(new BoolCondition(Monster.KEY_TARGET_EXIST, true));

            // 追击>战斗
            // 和目标的距离小于攻击距离
            FiniteStateTransaction<Monster> move2Battle = monsterStateMachine.AddTranscation(charse, battle);
            move2Battle.AddCondition(new IntCondition(Monster.KET_DISTANCE, IntCondition.SMALLER, Monster.ATTACK_RANGE));

            // 追击>待机
            // 目标死亡
            FiniteStateTransaction<Monster> move2Wait = monsterStateMachine.AddTranscation(charse, wait);
            move2Wait.AddCondition(new BoolCondition(Monster.KEY_TARGET_DEAD, true));

            // 战斗>移动
            // 和目标的距离大于攻击距离
            FiniteStateTransaction<Monster> battle2Move = monsterStateMachine.AddTranscation(battle, charse);
            battle2Move.AddCondition(new IntCondition(Monster.KET_DISTANCE, IntCondition.LARGER, Monster.ATTACK_RANGE));

            // 战斗>待机
            // 目标死亡
            FiniteStateTransaction<Monster> battle2Wait = monsterStateMachine.AddTranscation(battle, wait);
            battle2Wait.AddCondition(new BoolCondition(Monster.KEY_TARGET_DEAD, true));

            Monster m = new Monster();
            for (int i = 0; i < 10; i++)
            {
                monsterStateMachine.Tick(m, 0, 0);
            }


        }


    }
}
