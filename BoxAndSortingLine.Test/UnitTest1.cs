using ParcelSortingLine;
using System;
using System.Collections.Generic;
using Xunit;

namespace ParcelSortingLine.Test {
    public class UnitTest1 {
        [Fact]
        public void When_ParcelHasNewDimensionsAndSortingLineHasNewDimensions_Then_Parcel_CanNotFitSortingLine() {
            var boxSizes = new List<BoxSize>() {
                new BoxSize {
                    Length = 70,
                    Width = 50,
                    SortingLineParams = new List<SortingLineParam>() {
                        new SortingLineParam { LineWidth = 50 },
                        new SortingLineParam { LineWidth = 50 },
                        new SortingLineParam { LineWidth = 100 },
                        new SortingLineParam { LineWidth = 100 }
                    }
                }
            };
            bool result = Program.ParcelLineFitController(boxSizes);
            Assert.True(result);
        }
    }
}
