﻿/*
The MIT License (MIT)
Copyright (c) 2018 Helix Toolkit contributors
*/
using SharpDX;
using SharpDX.Direct3D11;
using System.IO;
#if !NETFX_CORE
namespace HelixToolkit.Wpf.SharpDX.Model
#else
namespace HelixToolkit.UWP.Model
#endif
{
    using Shaders;
    public class DiffuseMaterialCore : MaterialCore
    {
        private Color4 diffuseColor = Color.White;
        /// <summary>
        /// Gets or sets the color of the diffuse.
        /// </summary>
        /// <value>
        /// The color of the diffuse.
        /// </value>
        public Color4 DiffuseColor
        {
            set { Set(ref diffuseColor, value); }
            get { return diffuseColor; }
        }
        private Stream diffuseMap;
        /// <summary>
        /// Gets or sets the diffuse map.
        /// </summary>
        /// <value>
        /// The diffuse map.
        /// </value>
        public Stream DiffuseMap
        {
            set { Set(ref diffuseMap, value); }
            get { return diffuseMap; }
        }
        private Matrix uvTransform = Matrix.Identity;
        /// <summary>
        /// Gets or sets the uv transform.
        /// </summary>
        /// <value>
        /// The uv transform.
        /// </value>
        public Matrix UVTransform
        {
            set { Set(ref uvTransform, value); }
            get { return uvTransform; }
        }
        private SamplerStateDescription diffuseMapSampler = DefaultSamplers.LinearSamplerWrapAni4;
        /// <summary>
        /// Gets or sets the DiffuseMapSampler.
        /// </summary>
        /// <value>
        /// DiffuseMapSampler
        /// </value>
        public SamplerStateDescription DiffuseMapSampler
        {
            set { Set(ref diffuseMapSampler, value); }
            get { return diffuseMapSampler; }
        }

        private bool renderDiffuseMap = true;
        /// <summary>
        /// 
        /// </summary>
        public bool RenderDiffuseMap
        {
            set
            {
                Set(ref renderDiffuseMap, value);
            }
            get { return renderDiffuseMap; }
        }

        private bool enableUnLit = false;
        /// <summary>
        /// Gets or sets a value indicating whether disable lighting. Directly render diffuse color and diffuse map
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable un lit]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableUnLit
        {
            set { Set(ref enableUnLit, value); }
            get { return enableUnLit; }
        }

        public override MaterialVariable CreateMaterialVariables(IEffectsManager manager, IRenderTechnique technique)
        {
            return new DiffuseMaterialVariables(DefaultPassNames.Diffuse, manager, technique, this);
        }
    }

    public sealed class ViewCubeMaterialCore : DiffuseMaterialCore
    {
        public override MaterialVariable CreateMaterialVariables(IEffectsManager manager, IRenderTechnique technique)
        {
            return new DiffuseMaterialVariables(DefaultPassNames.ViewCube, manager, technique, this);
        }
    }
}
