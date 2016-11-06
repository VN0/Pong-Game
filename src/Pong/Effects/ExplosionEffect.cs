﻿namespace PongBrain.Pong.Effects {
    
/*-------------------------------------
 * USINGS
 *-----------------------------------*/

using System;

using Base.Components;
using Base.Components.Physical;
using Base.Core;

using Entities.Graphical;

/*-------------------------------------
 * CLASSES
 *-----------------------------------*/

public sealed class ExplosionEffect: Effect {
    /*-------------------------------------
     * PUBLIC PROPERTIES
     *-----------------------------------*/

    private readonly int m_NumParticles;

    private readonly float m_X;
    private readonly float m_Y;

    /*-------------------------------------
     * CONSTRUCTORS
     *-----------------------------------*/

    public ExplosionEffect(float x, float y, int numParticles=10): base(0.0f) {
        m_X = x;
        m_Y = y;

        m_NumParticles = numParticles;
    }

    /*-------------------------------------
     * PUBLIC METHODS
     *-----------------------------------*/

    public override void Begin() {
        base.Begin();

        var random = new Random();

        for (var i = 0; i < m_NumParticles; i++) {
            var size     = 0.01f + 0.01f*(float)random.NextDouble();
            var particle = new RectangleEntity(m_X, m_Y, size, size);
            var velocity = particle.AddComponent(new VelocityComponent());
            var theta    = 2.0f*(float)Math.PI * (float)random.NextDouble();
            var r        = 0.4f + 0.4f*(float)random.NextDouble();
            var a        = 0.2f + 0.2f*(float)random.NextDouble();

            velocity.X = (float)Math.Cos(theta)*r;
            velocity.Y = (float)Math.Sin(theta)*r;

            particle.AddComponent(new LifetimeComponent { Lifetime = a });

            Game.Inst.AddEntity(particle);
        }
    }
}

}