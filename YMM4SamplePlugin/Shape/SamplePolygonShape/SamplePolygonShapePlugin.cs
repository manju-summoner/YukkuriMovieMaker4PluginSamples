using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukkuriMovieMaker.Plugin.Shape;
using YukkuriMovieMaker.Project;

namespace YMM4SamplePlugin.Shape.SamplePolygonShape
{
    internal class SamplePolygonShapePlugin : IShapePlugin
    {
        public bool IsExoShapeSupported => false;

        public bool IsExoMaskSupported => false;

        public string Name => "サンプル多角形";

        public IShapeParameter CreateShapeParameter(SharedDataStore? sharedData)
        {
            return new SamplePolygonShapeParameter(sharedData);
        }
    }
}
