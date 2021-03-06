﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaxEditor.Viewport.Previews;
using FlaxEngine;
using FlaxEngine.GUI;

namespace VisjectPlugin.Source.Editor
{
    /// <summary>
    /// Small preview, only draws a number
    /// </summary>
    public class ExpressionGraphPreview : AssetPreview
    {
        private float UpdateDuration = 1f / 3f;
        private float _accumulatedTime;

        public ExpressionGraphPreview(bool useWidgets) : base(useWidgets)
        {
        }

        /// <summary>
        /// Expression graph instance
        /// </summary>
        public ExpressionGraph ExpressionGraph { get; set; }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            // Manually update simulation

            // Run it at a slow speed
            _accumulatedTime += deltaTime;
            if (_accumulatedTime > UpdateDuration)
            {
                _accumulatedTime = 0;
                ExpressionGraph?.Update(deltaTime);
            }
        }

        /// <inheritdoc />
        public override void Draw()
        {
            base.Draw();

            if (ExpressionGraph == null) return;

            // Just draw the output number
            Render2D.DrawText(
                Style.Current.FontLarge,
                $"Float: {ExpressionGraph.OutputFloat}\n",
                new Rectangle(Vector2.Zero, Size),
                Color.Wheat,
                TextAlignment.Near,
                TextAlignment.Far);

        }

        /// <inheritdoc />
        public override void OnDestroy()
        {
            ExpressionGraph = null;
            base.OnDestroy();
        }
    }
}
