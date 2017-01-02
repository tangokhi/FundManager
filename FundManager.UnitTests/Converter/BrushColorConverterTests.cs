using FundManager.Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FundManager.UnitTests.Converter
{
    [TestClass]
    public class BrushColorConverterTests
    {
        [TestMethod]
        public void Convert_WhenCalled_ReturnsRedForTrueValue()
        {
            var brushColorConverter = new BrushColorConverter();

            SolidColorBrush val = (SolidColorBrush)brushColorConverter.Convert(true, null, null, null);

            Assert.AreEqual(Colors.Red, val.Color);
        }

        [TestMethod]
        public void Convert_WhenCalled_ReturnsBlackForTrueValue()
        {
            var brushColorConverter = new BrushColorConverter();

            SolidColorBrush val = (SolidColorBrush)brushColorConverter.Convert(false, null, null, null);

            Assert.AreEqual(Colors.Black, val.Color);
        }
    }
}
