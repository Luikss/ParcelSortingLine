using System;
using System.Collections.Generic;

namespace ParcelSortingLine {
    public class Program {
        static void Main(string[] args) {
            ParcelLineFitController(BoxSizes);
        }

        public static bool ParcelLineFitController(List<BoxSize> boxSizes) {
            bool parcelFits = false;

            foreach (BoxSize box in boxSizes) {
                Console.WriteLine("New sorting line starts");

                var boxLengthInHalf = box.Length / 2;
                var halfParcelDiagonal = Math.Sqrt((boxLengthInHalf * boxLengthInHalf) + (box.Width * box.Width));
                var lineWidth = 0;

                foreach (SortingLineParam sortingLine in box.SortingLineParams) {
                    var cornerDiagonal = Math.Sqrt((sortingLine.LineWidth * sortingLine.LineWidth) + (lineWidth * lineWidth));

                    if (sortingLine.LineWidth >= halfParcelDiagonal) {
                        Console.WriteLine("Sorting line width is {0} and it fits", sortingLine.LineWidth);
                    } else if (sortingLine.LineWidth <= halfParcelDiagonal && lineWidth >= halfParcelDiagonal) {
                        Console.WriteLine("Sorting line width is {0} and it fits", sortingLine.LineWidth);
                    } else if (box.Width <= halfParcelDiagonal && lineWidth >= halfParcelDiagonal) {
                        Console.WriteLine("Sorting line width is {0} and it fits", sortingLine.LineWidth);
                    } else if (box.Width >= cornerDiagonal) {
                        Console.WriteLine("Sorting line width is {0} and it fits", sortingLine.LineWidth);
                    } else if (sortingLine.LineWidth <= halfParcelDiagonal && sortingLine.LineWidth >= cornerDiagonal) {
                        parcelFits = sortingLine.LineWidth <= halfParcelDiagonal &&
                        sortingLine.LineWidth >= cornerDiagonal;
                        var result = parcelFits ? "Sorting line width is " + sortingLine.LineWidth + " and it fits" : "Parcel doesn't fit";
                        Console.WriteLine(result);
                    } else {
                        Console.WriteLine("Parcel doesn't fit");
                    }
                    lineWidth = sortingLine.LineWidth;
                }
            }
            return parcelFits;
        }

        public static readonly List<BoxSize> BoxSizes = new List<BoxSize> {
            new BoxSize {
                Length = 120,
                Width = 60,
                SortingLineParams = new List<SortingLineParam> {
                    new SortingLineParam { LineWidth = 100 },
                    new SortingLineParam { LineWidth = 75 }
                }
            },
            new BoxSize {
                Length = 100,
                Width = 35,
                SortingLineParams = new List<SortingLineParam> {
                    new SortingLineParam { LineWidth = 75 },
                    new SortingLineParam { LineWidth = 50 },
                    new SortingLineParam { LineWidth = 80 },
                    new SortingLineParam { LineWidth = 100 },
                    new SortingLineParam { LineWidth = 37 }
                }
            },
            new BoxSize {
                Length = 70,
                Width = 50,
                SortingLineParams = new List<SortingLineParam> {
                    new SortingLineParam { LineWidth = 60 },
                    new SortingLineParam { LineWidth = 60 },
                    new SortingLineParam { LineWidth = 55 },
                    new SortingLineParam { LineWidth = 90 }
                }
            }
        };
    }

    public class BoxSize {
        public int Length { get; set; }
        public int Width { get; set; }
        public List<SortingLineParam> SortingLineParams { get; set; } = new List<SortingLineParam>();
    }

    public class SortingLineParam {
        public int LineWidth { get; set; }
    }
}
