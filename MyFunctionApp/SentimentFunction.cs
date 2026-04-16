using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.ML; // Required for the Pool

namespace MyFunctionApp
{
    public class SentimentFunction
    {
        private readonly PredictionEnginePool<SentimentModel.ModelInput, SentimentModel.ModelOutput> _predictionPool;

        // Constructor Injection: The system gives us the pool we registered in Program.cs
        public SentimentFunction(PredictionEnginePool<SentimentModel.ModelInput, SentimentModel.ModelOutput> predictionPool)
        {
            _predictionPool = predictionPool;
        }

        [Function("AnalyzeSentiment")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "post","get")] HttpRequest req)
        {
            // 1. Get the news text from the query string or body
            string newsHeadline = req.Query["news"];

            if (string.IsNullOrEmpty(newsHeadline))
            {
                return new BadRequestObjectResult("Please pass a news headline in the query string.");
            }

            // 2. Create the input object
            var input = new SentimentModel.ModelInput { News = newsHeadline };

            // 3. Use the THREAD-SAFE pool to get a prediction
            var prediction = _predictionPool.Predict(input);

            // 4. Return the result (Scalable & Robust!)
            return new OkObjectResult(new
            {
                Text = newsHeadline,
                Sentiment = prediction.PredictedLabel,
                Confidence = prediction.Score
            });
        }
    }
}
