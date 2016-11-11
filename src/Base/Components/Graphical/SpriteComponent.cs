﻿namespace PongBrain.Base.Components.Graphical {

/*-------------------------------------
 * USINGS
 *-----------------------------------*/

using Graphics.Shaders;
using Graphics.Textures;

/*-------------------------------------
 * CLASSES
 *-----------------------------------*/

public sealed class SpriteComponent {
    /*-------------------------------------
     * PUBLIC PROPERTIES
     *-----------------------------------*/

    public float ScaleX { get; set; } = 1.0f;

    public float ScaleY { get; set; } = 1.0f;

    public IShader Shader { get; set; }

    public ITexture Texture { get; set; }
}

}
