using Newtonsoft.Json;
using Plotly.NET.CSharp;

namespace PlotlyBlazorTest.Data
{

    public class PlotService
    {

        private Plotly.NET.GenericChart.GenericChart plot =>
            Chart.Point<int, int, string>(
                x: Enumerable.Range(0, 10),
                y: Enumerable.Range(0, 10)
            ).WithXAxisStyle<int, int, string>(
                TitleText: "xAxis"
            ).WithYAxisStyle<int, int, string>(
                TitleText: "yAxis"
            );

        private JsonSerializerSettings settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Serialize };

        public Task<Figure> SamplePlot() => Task.FromResult(
            new Figure
            {
                Traces = JsonConvert.SerializeObject(Plotly.NET.GenericChart.getTraces(plot), settings),
                Layout = JsonConvert.SerializeObject(Plotly.NET.GenericChart.getLayout(plot), settings),
                Config = JsonConvert.SerializeObject(Plotly.NET.GenericChart.getConfig(plot), settings)
            }
        );
    }
}
