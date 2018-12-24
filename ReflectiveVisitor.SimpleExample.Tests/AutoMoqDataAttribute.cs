using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectiveVisitor.SimpleExample.Tests
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : 
            base(() => new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }
}
