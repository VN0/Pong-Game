﻿namespace PongBrain.Base.Subsystems {

/*-------------------------------------
 * USINGS
 *-----------------------------------*/

using Components;
using Core;
using Input;

/*-------------------------------------
 * CLASSES
 *-----------------------------------*/

public class FpsCounterSubsystem: Subsystem {
    /*-------------------------------------
     * PRIVATE FIELDS
     *-----------------------------------*/

    private int m_NumDraws;
    private int m_NumUpdates;
    private float m_Time;
    private string m_Text;
    

    /*-------------------------------------
     * PUBLIC METHODS
     *-----------------------------------*/

    public override void Cleanup() {
        base.Init();
        
        Game.Inst.Window.Text = m_Text;
    }

    public override void Draw(float dt) {
        base.Draw(dt);

        m_NumDraws++;

        m_Time += dt;
        while (m_Time >= 1.0f) {
            Game.Inst.Window.Text = string.Format("{0} ({1}, {2} draws/s, {3} updates/s, {4} entities)", m_Text, Game.Inst.Graphics.Name, m_NumDraws, m_NumUpdates, Game.Inst.Scene.Entities.Count);

            m_NumDraws   = 0;
            m_NumUpdates = 0;

            m_Time -= 1.0f;
        }
    }

    public override void Init() {
        base.Init();
        
        m_Text = Game.Inst.Window.Text;
    }

    public override void Update(float dt) {
        base.Update(dt);

        m_NumUpdates++;
    }
}

}
